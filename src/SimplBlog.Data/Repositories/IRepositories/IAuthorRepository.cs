using SimplBlog.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SimplBlog.Data.Helpers;

namespace SimplBlog.Data.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetItem(Expression<Func<Author, bool>> predicate);
        Task<IEnumerable<Author>> GetList(Expression<Func<Author, bool>> predicate, PageHelper pageHelper);
        Task Save(Author author);
        Task Remove(int id);
    }
}
