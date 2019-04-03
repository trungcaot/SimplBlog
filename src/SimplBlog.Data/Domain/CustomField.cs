using System;
using System.Collections.Generic;
using System.Text;

namespace SimplBlog.Data.Domain
{
    public class CustomField : BaseEntity
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
