using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using DAL.Access;

namespace DAL.DbControl
{
    public class ArticleControl
    {
        private BlogContext db = new BlogContext();

        public IEnumerable<Article> GetAllArticles()
        {
            var articles = db.Articles.ToList();

            return articles;
        }

        public bool AddArticle(Article article)
        {
            bool isArticleExist = db.Articles.Any(a => a.Content == article.Content);

            if (!isArticleExist)
            {
                db.Articles.Add(article);
                db.SaveChanges();

                return true;
            }

            return false;
        }

        public Article GetArticle(int id)
        {
            return db.Articles.FirstOrDefault(a => a.ArticleID == id);
        }

        public void UpdateArticle(Article article)
        {
            db.Entry(article).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }

    }
}
