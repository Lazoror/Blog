using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Access;
using Blog.Models;
using DAL.DbControl;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ArticleControl ArticleDb = new ArticleControl();

        // GET: Blog
        public ActionResult Index()
        {
            // Get all articles from DB
            return View(ArticleDb.GetAllArticles());
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

                ArticleDb.AddArticle(article);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Article(int articleId)
        {
            Article article = ArticleDb.GetArticle(articleId);

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
                Article article = ArticleDb.GetArticle(articleId);

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

                ArticleDb.UpdateArticle(article);

                return RedirectToAction("Article", new { articleId });
            }

            return RedirectToAction("AddTag", new { articleId });
        }
    }
}