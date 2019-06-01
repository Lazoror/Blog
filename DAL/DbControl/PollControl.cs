using Blog.Models;
using DAL.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbControl
{
    public class PollControl
    {
        private BlogContext db = new BlogContext();

        public IEnumerable<Poll> GetAllPolls()
        {
            var polls = db.Polls.ToList();

            return polls;
        }

        public void AddPoll(Poll poll)
        {
            db.Polls.Add(poll);
            db.SaveChanges();
        }

        public Poll GetPollById(int id)
        {
            Poll poll = db.Polls.FirstOrDefault(a => a.PollId == id);

            return poll;
        }

    }
}
