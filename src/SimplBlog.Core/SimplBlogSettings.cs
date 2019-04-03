using System;
using Microsoft.EntityFrameworkCore;

namespace SimplBlog.Core
{
    public class SimplBlogSettings
    {
        public static Action<DbContextOptionsBuilder> DbOptions { get; set; }
    }
}
