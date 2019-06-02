using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.DbControl;
using Newtonsoft.Json;

namespace Blog.Controllers
{
    public class VoteController : Controller
    {
        private readonly VoteControl voteControl = new VoteControl();


        public ActionResult Index()
        {

            return View(voteControl.GetVotes());
        }

        public ActionResult Details(Guid voteId)
        {
            Vote votFond = voteControl.GetVote(voteId);


            var dictVotes = JsonConvert.DeserializeObject<Dictionary<string, int>>(votFond.VoteResults);
            ViewBag.results = dictVotes;

            return View(votFond);
        }


        [HttpPost]
        public ActionResult Details(Vote vote, List<string> values)
        {
            string urlRaw = HttpContext.Request.UrlReferrer.LocalPath;
            Vote vot = voteControl.GetVote(vote.VoteId);

            if (values != null)
            {
                Dictionary<string, int> dictVotes = JsonConvert.DeserializeObject<Dictionary<string, int>>(vot.VoteResults);

                foreach (string item in values)
                {

                    if (dictVotes.ContainsKey(item))
                    {
                        dictVotes[item]++;
                    }
                }

                string jsonDictionart = JsonConvert.SerializeObject(dictVotes);
                ViewBag.results = dictVotes;
                vot.VoteResults = jsonDictionart;

                voteControl.UpdateVote(vot);
            }

            if (urlRaw == "/")
            {
                return RedirectToAction("Index", "Blog");
            }

            return View(vot);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vote vote)
        {

            if (ModelState.IsValid)
            {
                Dictionary<string, int> votes = new Dictionary<string, int>();
                var answersList = vote.VoteResults.Split(',');

                foreach (string item in answersList)
                {
                    votes.Add(item, 0);
                }

                string jsonDictionart = JsonConvert.SerializeObject(votes);
                vote.VoteResults = jsonDictionart;
                voteControl.CreatVote(vote);

                return RedirectToAction("Details", new { voteId = vote.VoteId });
            }

            return View(vote);

        }

        public ActionResult Delete(Guid voteId)
        {
            voteControl.UpdateStatusVote(voteId, VoteStatus.Deleted);

            return RedirectToAction("Index", "Vote");
        }

        public ActionResult Activate(Guid voteId)
        {
            voteControl.UpdateStatusVote(voteId, VoteStatus.Active);

            return RedirectToAction("Index", "Vote");
        }

    }
}