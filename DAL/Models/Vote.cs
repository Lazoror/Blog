using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public enum VoteStatus
    {
        Active,
        Deleted
    }

    public class Vote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid VoteId { get; set; }
        [Required]
        public string VoteName { get; set; }
        [Required]
        public string VoteResults { get; set; }
        public VoteStatus VoteStatus { get; set; }
    }
}
