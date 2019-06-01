using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog.Models
{
    public class Poll
    {
        public int PollId { get; set; }

        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required]
        [DisplayName("О вас")]
        public string About { get; set; }
        [Required]
        [DisplayName("18+")]
        public bool CheckAge { get; set; }
        [Required]
        [DisplayName("Языки к изучению")]
        public string Languages { get; set; }

    }
}