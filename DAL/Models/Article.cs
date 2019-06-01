using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Article
    {
        public int ArticleID { get; set; }
        [Required]
        public string Name { get; set; }
        public string CreateDate { get; set; }
        [Required]
        [StringLength(4000, MinimumLength = 100)]
        public string Content { get; set; }
        public string Tags { get; set; }

        public virtual ICollection<FeedBack> FeedBacks { get; set; }
    }
}