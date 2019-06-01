using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Access;
using Blog.Models;
using DAL.DbControl;
using Newtonsoft.Json;

namespace Blog.Controllers
{
    public class PollController : Controller
    {
        PollControl pollControl = new PollControl();

        // GET: Poll
        public ActionResult Index()
        {
            // Get all polls from DB
            return View(pollControl.GetAllPolls());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Poll poll, string[] languages)
        {
            // Checks if model is valid and add poll to DB
            if (ModelState.IsValid && languages != null)
            {
                List<string> langs = new List<string>(languages);

                // Serialize list of languages to Json string
                string json = JsonConvert.SerializeObject(langs);

                poll.Languages = json;

                // Deserialize Json string to List<string>
                // var listLang = JsonConvert.DeserializeObject <List<string>>(json);

                pollControl.AddPoll(poll);

                return RedirectToAction("Result", new { pollId = poll.PollId });
            }

            return View(poll);

        }

        public ActionResult Result(int pollId)
        {
            // Get poll model from DB by poll ID

            Poll poll = pollControl.GetPollById(pollId);

            return View(poll);
        }


    }
}