using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterProject.Service.Option;

namespace TwitterProject.UI.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        TweetService _tweetService;
        public HomeController()
        {
            _tweetService = new TweetService();
        }
        public ActionResult Index()
        {

            var model = _tweetService.GetActive().OrderByDescending(x => x.CreatedDate).Take(5);
            return View(model);
        }
    }
}