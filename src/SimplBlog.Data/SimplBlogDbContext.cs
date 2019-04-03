using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimplBlog.Data.Domain;
using SimplBlog.Core;

namespace SimplBlog.Data
{
    public class SimplBlogDbContext : IdentityDbContext<AppUser>
    {
        public SimplBlogDbContext(DbContextOptions<SimplBlogDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<HtmlWidget> HtmlWidgets { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SimplBlogSettings.DbOptions(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
