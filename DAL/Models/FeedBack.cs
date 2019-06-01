using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog.Models
{
    public class FeedBack
    {
        public int FeedBackId { get; set; }
        public int ArticleID { get; set; }
        [DisplayName("Ваше имя")]
        [Required]
        public string AuthorName { get; set; }
        public string AddTime { get; set; }
        [Required]
        [DisplayName("Отзыв")]
        public string Content { get; set; }

        public virtual Article Article { get; set; }
    }
}