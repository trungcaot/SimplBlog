using System;
using Microsoft.EntityFrameworkCore;

namespace SimplBlog.Core
{
    public class SimplBlogSettings
    {
        public static string Avatar { get; set; }

        public static Action<DbContextOptionsBuilder> DbOptions { get; set; }
    }
}
