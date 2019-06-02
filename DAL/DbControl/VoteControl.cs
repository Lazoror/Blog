using DAL.Access;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbControl
{
    public class VoteControl
    {
        private readonly BlogContext db = new BlogContext();

        public void CreatVote(Vote vote)
        {
            db.Votes.Add(vote);
            db.SaveChanges();
        }

        public Vote GetVote(Guid voteId)
        {
            return db.Votes.FirstOrDefault(a => a.VoteId == voteId);
        }

        public Vote GetVote(Guid? voteId)
        {
            return db.Votes.FirstOrDefault(a => a.VoteId == voteId);
        }

        public IEnumerable<Vote> GetVotes()
        {
            return db.Votes.ToList();
        }

        public void UpdateVote(Vote vote)
        {
            db.Entry(vote).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateStatusVote(Guid voteId, VoteStatus status)
        {
            Vote vote = GetVote(voteId);
            vote.VoteStatus = status;

            db.Entry(vote).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    }
}
