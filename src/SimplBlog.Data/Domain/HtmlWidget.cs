using System;
using System.Collections.Generic;
using System.Text;

namespace SimplBlog.Data.Domain
{
    public class HtmlWidget : BaseEntity
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
