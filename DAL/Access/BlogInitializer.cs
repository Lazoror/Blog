using Blog.Models;
using DAL.Access;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Access
{
    class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var articles = new List<Article>
            {
                new Article{Tags = "Article,Best,Pamparam",CreateDate = DateTime.UtcNow.Date.ToShortDateString(), Name= "Iterating a React Design with Styled Components", Content = "In a perfect world, our projects would have unlimited resources and time. Our teams would begin coding with well thought out and highly refined UX designs. There would be consensus among developers about the best way to approach styling. There’d be one or more CSS gurus on the team who could ensure that functionality and style could roll out simultaneously without it turning into a train-wreck. I’ve actually seen this happen in large enterprise environments. It’s a beautiful thing. This article is not for those people. On the flip side of the coin is the tiny startup that has zero funding, one or two front-end developers, and a very short timeline to demonstrate some functionality. It doesn’t have to look perfect, but it should at least render reasonably well on desktop, tablet, and mobile. This gets them to a point where it can be shown to advisors and early users; maybe even potential investors who’ve expressed an interest in the concept. Once they get some cashflow from sales and/or investment, they can get a dedicated UX designer and polish the interface. What follows is for this latter group." },
                new Article{CreateDate = DateTime.UtcNow.Date.ToShortDateString(), Name = "The new evergreen Googlebot", Content = "Googlebot is the crawler that visits web pages to include them within Google Search index. The number one question we got from the community at events and social media was if we could make Googlebot evergreen with the latest Chromium. Today, we are happy to announce that Googlebot now runs the latest Chromium rendering engine (74 at the time of this post) when rendering pages for Search. Moving forward, Googlebot will regularly update its rendering engine to ensure support for latest web platform features."},
                new Article{CreateDate = DateTime.UtcNow.Date.ToShortDateString(), Name = "A Deep Dive into Native Lazy-Loading for Images and Frames", Content = "Today's websites are packed with heavy media assets like images and videos. Images make up around 50% of an average website's traffic. Many of them, however, are never shown to a user because they're placed way below the fold. What’s this thing about images being lazy, you ask? Lazy-loading is something that’s been covered quite a bit here on CSS-Tricks, including a thorough guide with documentation for different approaches using JavaScript. In short, we’re talking about a mechanism that defers the network traffic necessary to load content when it’s needed — or rather when trigger the load when the content enters the viewport. The benefit? A smaller initial page that loads faster and saves network requests for items that may not be needed if the user never gets there. If you read through other lazy-loading guides on this or other sites, you’ll see that we’ve had to resort to different tactics to make lazy-loading work. Well, that’s about to change when lazy-loading will be available natively in HTML as a new loading attribute… at least in Chrome which will hopefully lead to wider adoption. Chrome has already merged the code for native lazy-loading and is expected to ship it in Chrome 75, which is slated to release June 4, 2019."},
                new Article{CreateDate = DateTime.UtcNow.Date.ToShortDateString(), Name = "A Better Approach for Using Purgecss with Tailwind", Content = "A number of us at Viget have been using TailwindCSS recently, and -- at least for the converted -- it’s been simply awesome. We’ve already written about some lessons learned, and this is another take on improving your Tailwind workflow. If you’ve already decided to disavow years of naming classes semantically and give Tailwind and utility-first CSS a chance, you may have heard of Purgecss. Another process for your build tools, Purgecss solves a big problem in a really straightforward way: Eliminating unused CSS classes through predictable regex matching. After comparing your markup files with your CSS, it weeds out any unused classes for a smaller file. While not a Tailwind-specific tool, there’s a good reason Tailwind’s docs specifically mention how to configure Purgecss. Tailwind, by intention, is aiming to equip you with an arsenal of utility classes by generating more than you need. There are some best practices which will help keep this overall build size down, like limiting your colors and breakpoints or turning off the modules by default before adding them as necessary. Still, you’ll inevitably generate classes that go unused. And honestly, approaching your configuration with an unrelenting miserly attitude will slow you down and make development less fun. By leaning on Purgecss, there’s no worry that the CSS your users download will only include classes that are ultimately needed. Well… almost. There are still some gotchas that will crop up, so let’s dive into what these look like and some potential solutions."},
                new Article{CreateDate = DateTime.UtcNow.Date.ToShortDateString(), Name = "Integrating Third-Party Animation Libraries to a Project", Content = "Creating CSS-based animations and transitions can be a challenge. They can be complex and time-consuming. Need to move forward with a project with little time to tweak the perfect transition? Consider a third-party CSS animation library with ready-to-go animations waiting to be used. Yet, you might be thinking: What are they? What do they offer? How do I use them? Well, let’s find out. #A (sort of) brief history of :hover Once there was a time that the concept of a hover state was a trivial example of what is offered today. In fact, the idea of having a reaction to the cursor passing on top of an element was more-or-less nonexistent. Different ways to provide this feature were proposed and implemented. This small feature, in a way, opened the door to the idea of CSS being capable of animations for elements on the page. Over time, the increasing complexity possible with these features have led to CSS animation libraries. Macromedia’s Dreamweaver was introduced in December 1997 and offered what was a simple feature, an image swap on hover. This feature was implemented with a JavaScript function that would be embedded in the HTML by the editor. This function was named MM_swapImage() and has become a bit of web design folklore. It was an easy script to use, even outside of Dreamweaver, and it’s popularity has resulted in it still being in use even today. In my initial research for this article, I found a question pertaining to this function from 2018 on Adobe’s Dreamweaver (Adobe acquired Macromedia in 2005) help forum."},
                new Article{CreateDate = DateTime.UtcNow.Date.ToShortDateString(), Name = "Deploying a Client-Side Rendered create-react-app to Microsoft Azure", Content = "Deploying a React app to Microsoft Azure is simple. Except that... it isn’t. The devil is in the details. If you're looking to deploy a create-react-app — or a similar style front-end JavaScript framework that requires pushState-based routing — to Microsoft Azure, I believe this article will serve you well. We’re going to try to avoid the headaches of client and server side routing reconciliation. First, a quick story. Back in 2016, when Donovan Brown, a Senior DevOps Program Manager at Microsoft, had given a 'but it works on my machine speech' at Microsoft Connect that year, I was still in my preliminary stages as a web developer. His talk was about micro-services and containers. [...] Gone are the days when your manager comes running into your office and she is frantic and she has found a bug. And no matter how hard I try, I can't reproduce it and it works perfectly on my machine. She says: fine Donovan, then we are going to ship your machine because that is the only place where it works. But I like my machine, so I'm not going to let her ship it... I had a similar sort of challenge, but it had to do with routing. I was working on a website with a React front end and ASP.NET Core back end, hosted as two separate projects that were deployed to Microsoft Azure. This meant we could deploy both apps separately and enjoy the benefits that comes with separation of concern. We also know who to git blame if and when something goes wrong. But it had downsides as well, as front-end vs. back-end routing reconciliation was one of those downsides. One day I pushed some new code to our staging servers. I received a message shortly after telling me the website was failing on page refresh. It was throwing a 404 error. At first, I didn’t think it was my responsibility to fix the error. It had to be some server configuration issue. Turns out I was both right and wrong. I was right to know it was a server configuration issue (though at the time, I didn’t know it had to do with routing). I was wrong to deny it my responsibility. It was only after I went on a web searching rampage that I found a use case for deploying a create-react-app to Azure under the Deployment tab on the official documentation page."},
            };

            context.Articles.AddRange(articles);
            context.SaveChanges();

            var reviews = new List<FeedBack>
            {
                new FeedBack {ArticleID = 1, AuthorName = "Jake the dog", Content = "Bro, that' so cool!!!", AddTime = DateTime.UtcNow.ToString("MM/dd/yyyy h:mm tt")},
                new FeedBack {ArticleID = 1, AuthorName = "Finn the human", Content = "Yeah, bro!", AddTime = DateTime.UtcNow.ToString("MM/dd/yyyy h:mm tt")},
                new FeedBack {ArticleID = 1, AuthorName = "Bod9", Content = "Totally agreed.", AddTime = DateTime.UtcNow.ToString("MM/dd/yyyy h:mm tt")},
            };

            context.FeedBacks.AddRange(reviews);
            context.SaveChanges();

            var polls = new List<Poll>
            {
                new Poll {Name = "Bohdan", About = "I'm human", CheckAge = true, Languages = "[\"C#\",\"JS\",\"C++\"]" }
            };

            context.Polls.AddRange(polls);
            context.SaveChanges();

            var votes = new List<Vote>
            {
                new Vote {VoteName = "What year were you born in?", VoteResults = "{'< 2000':0,'> 2000':0, '2000':0}", VoteStatus = VoteStatus.Active},
                new Vote { VoteName = "How are you? ;)", VoteResults = "{'Good':0, 'The best':0}", VoteStatus = VoteStatus.Active}
            };

            context.Votes.AddRange(votes);
            context.SaveChanges();
        
        }
    }
}
