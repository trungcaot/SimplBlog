using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SimplBlog.Data.Domain
{
    public class Author : BaseEntity
    {
        [StringLength(160)]
        public string AppUserId { get; set; }

        [StringLength(160)]
        public string AppUserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "User name")]
        public string DisplayName { get; set; }

        [Display(Name = "User bio")]
        public string Bio { get; set; }

        [StringLength(160)]
        public string Avatar { get; set; }

        public bool IsAdmin { get; set; }

    }
}
