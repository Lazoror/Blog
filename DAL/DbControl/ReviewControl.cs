using Blog.Models;
using DAL.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbControl
{
    public class ReviewControl
    {
        private BlogContext db = new BlogContext();

        public IEnumerable<FeedBack> GetReviewsByArticleId(int articleId)
        {
            var reviews = db.Articles.Where(a => a.ArticleID == articleId).SelectMany(a => a.FeedBacks).ToList();

            return reviews;
        }

        public bool AddReview(FeedBack review)
        {
            bool isReviewExist = db.FeedBacks.Any(a => a.Content == review.Content);
            bool isArticleExist = db.Articles.Any(a => a.ArticleID == review.ArticleID);

            if (!isReviewExist && isArticleExist)
            {
                db.FeedBacks.Add(review);
                db.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
