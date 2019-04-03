using System;
using System.Collections.Generic;
using System.Text;

namespace SimplBlog.Data.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
