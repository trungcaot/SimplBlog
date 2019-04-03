using System;
using System.Collections.Generic;
using System.Text;
using SimplBlog.Data.Enums;

namespace SimplBlog.Data.Domain
{
    public class Notification : BaseEntity
    {
        public int AuthorId { get; set; }

        public  AlertType AlertType { get; set; }

        public string Content { get; set; }

        public string Notifier { get; set; }

        public bool Acitve { get; set; }
    }
}
