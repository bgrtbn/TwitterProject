using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterProject.Model.Option;
using TwitterProject.Service.Option;
using TwitterProject.UI.Areas.Member.Models.VM;

namespace TwitterProject.UI.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        TweetService _tweetService;
        AppUserService _appUserService;
        

        public HomeController()
        {
            _tweetService = new TweetService();
            _appUserService = new AppUserService();
        }
        public ActionResult Index()
        {

            TweetVM model = new TweetVM()
            {


                appUser = _appUserService.FindByUserName(HttpContext.User.Identity.Name),
                AppUsers = _appUserService.GetActive(),

                Tweets = _tweetService.GetActive().OrderByDescending(x => x.CreatedDate).Take(10).ToList(),

               

            };
            return View(model);
        
        }
        [HttpPost]
        public ActionResult Index(Tweet data)
        {
            _tweetService.Add(data);

            return Redirect("/Member/Home/Index");
        }
    }
}