using Blog.Models;
using DAL.DbControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ReviewController : Controller
    {
        ReviewControl reviewControl = new ReviewControl();

        // GET: Review
        public ActionResult Index(int articleId)
        {
            // Get all reviews from project
            return View(reviewControl.GetReviewsByArticleId(articleId));
        }

        public ActionResult Create(int articleId)
        {
            FeedBack feedBack = new FeedBack() { ArticleID = articleId };


            return View(feedBack);
        }

        [HttpPost]
        public ActionResult Create(FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                // adding review to DB
                feedBack.AddTime = DateTime.UtcNow.ToString("MM/dd/yyyy h:mm tt");

                reviewControl.AddReview(feedBack);
            }

            return RedirectToAction("Index", new { articleId = feedBack.ArticleID });
        }


    }
}