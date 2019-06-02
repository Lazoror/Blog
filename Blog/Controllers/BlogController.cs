using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Access;
using Blog.Models;
using DAL.DbControl;
using Newtonsoft.Json;
using DAL.Models;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ArticleControl articleDb = new ArticleControl();
        private readonly VoteControl voteControl = new VoteControl();

        // GET: Blog
        public ActionResult Index()
        {
            // Get all votes
            var votes = voteControl.GetVotes();

            // create seed for random
            Random rnd = new Random();

            // get random number from 0 to vote length
            int randNum = rnd.Next(0, votes.Count());

            // Get random vote at random position
            Vote randVote = votes.ElementAt(randNum);

            ViewBag.vote = randVote;

            // deserialize results to dictionary
            Dictionary<string, int> dictVotes = JsonConvert.DeserializeObject<Dictionary<string, int>>(randVote.VoteResults);

            ViewBag.results = dictVotes;

            // Get all articles from DB
            return View(articleDb.GetAllArticles());
        }

        [HttpPost]
        public ActionResult Index(Guid voteId)
        {
            return Content("lol");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Article article)
        {
            //Checks if model is valid and adds to Db
            if (ModelState.IsValid)
            {
                article.CreateDate = DateTime.UtcNow.Date.ToShortDateString();

                articleDb.AddArticle(article);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Article(int articleId)
        {
            Article article = articleDb.GetArticle(articleId);

            return View(article);
        }

        public ActionResult AddTag(int articleId)
        {
            ViewBag.articleId = articleId;

            return View();
        }

        [HttpPost]
        public ActionResult AddTag(int articleId, string tags)
        {

            if (!String.IsNullOrEmpty(tags))
            {
                Article article = articleDb.GetArticle(articleId);

                var oldTags = article.Tags.Split(',').ToList();
                var newTags = tags.Split(',').ToList();

                foreach (var item in newTags)
                {
                    if (!oldTags.Contains(item))
                    {
                        oldTags.Add(item);
                    }
                }

                article.Tags = string.Join(",", oldTags.ToArray());

                articleDb.UpdateArticle(article);

                return RedirectToAction("Article", new { articleId });
            }

            return RedirectToAction("AddTag", new { articleId });
        }

        public ActionResult UpdVote()
        {
            return Content($"lol");
        }
    }
}