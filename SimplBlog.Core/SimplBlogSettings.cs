using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplBlog.Core
{
    public class SimplBlogSettings
    {
        public static Action<DbContextOptionsBuilder> DbOptions { get; set; }
    }
}
