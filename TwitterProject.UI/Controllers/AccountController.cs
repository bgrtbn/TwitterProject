using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TwitterProject.Model.Option;
using TwitterProject.Service.Option;
using TwitterProject.UI.Models.VM;

namespace TwitterProject.UI.Controllers
{
    public class AccountController : Controller
    {
        AppUserService appUserService;
        public AccountController()
        {
            appUserService = new AppUserService();
        }
        [HttpPost]
        public ActionResult Register(AppUser data)
        {
            appUserService.Add(data);
            return Redirect("/Account/Login");
        }





        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {

                Redirect("/Member/Home/Index");

            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credentials)
        {
            if (ModelState.IsValid)
            {
                if (appUserService.CheckCredentials(credentials.UserName, credentials.Password , credentials.Mail))
                {
                    AppUser user = appUserService.FindByUserName(credentials.UserName);

                    string cookie = user.UserName;
                    FormsAuthentication.SetAuthCookie(cookie, true);

                    return Redirect("/Member/Home/Index");

                }
                else
                {
                    ViewData["error"] = "Kullanıcı Adı/Mail veya Şifre Hatalı";
                    return View();
                }
            }

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}