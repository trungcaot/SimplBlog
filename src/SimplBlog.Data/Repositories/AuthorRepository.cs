using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SimplBlog.Core;
using SimplBlog.Data.Domain;
using SimplBlog.Data.Helpers;

namespace SimplBlog.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly SimplBlogDbContext _db;
        public AuthorRepository(SimplBlogDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Author> GetItem(Expression<Func<Author, bool>> predicate)
        {
            var author = _db.Authors.SingleOrDefault(predicate);
            if (author == null) return null;

            author.Avatar = author.Avatar ?? SimplBlogSettings.Avatar;

            return await Task.FromResult(author);
        }

        public async Task<IEnumerable<Author>> GetList(Expression<Func<Author, bool>> predicate, PageHelper pageHelper)
        {
            var take = pageHelper.ItemsPerPage == 0 ? 10 : pageHelper.ItemsPerPage;
            var skip = pageHelper.CurrentPage * take - take;

            var authors = _db.Authors.Where(predicate).OrderBy(a => a.DisplayName).ToList();
            pageHelper.Configure(authors.Count);

            var result = authors.Skip(skip).Take(take).ToList();
            return await Task.FromResult(result);
        }

        public async Task Remove(int id)
        {
            var blogPosts = _db.BlogPosts.Where(b => b.AuthorId == id).ToList();
            if (blogPosts != null && blogPosts.Any())
                _db.BlogPosts.RemoveRange(blogPosts);

            var author = _db.Authors.SingleOrDefault(a => a.Id == id);
            if (author != null)
                _db.Authors.Remove(author);

            await _db.SaveChangesAsync();
        }

        public async Task Save(Author author)
        {
            if (author.CreatedDate == DateTime.MinValue)
            {
                author.DisplayName = author.AppUserName;
                author.Avatar = SimplBlogSettings.Avatar;
                author.CreatedDate = author.UpdatedTime = DateTime.Now;
                await _db.Authors.AddAsync(author);
            }
            else
            {
                var dbAuthor = _db.Authors.SingleOrDefault(a => a.Id == author.Id);
                if (dbAuthor != null)
                {
                    dbAuthor.DisplayName = author.DisplayName;
                    dbAuthor.Avatar = author.Avatar;
                    dbAuthor.Email = author.Email;
                    dbAuthor.Bio = author.Bio;
                    dbAuthor.IsAdmin = author.IsAdmin;
                    dbAuthor.UpdatedTime = DateTime.Now;

                    _db.Authors.Update(dbAuthor);
                }
            }

            await _db.SaveChangesAsync();
        }
    }
}
