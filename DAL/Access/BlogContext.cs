using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Blog.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using DAL.Models;

namespace DAL.Access
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogContext") { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}