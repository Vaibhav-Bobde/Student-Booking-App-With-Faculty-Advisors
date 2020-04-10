using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(WebApp.Models.User user)
        {
            if(this.IsValidUser(user.Uname, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.Uname, true);
                return RedirectToAction("Home");
            }
            @ViewBag.LoginStatus = false;
            return View();
        }
        private bool IsValidUser(string uname, string pwd)
        {
            return uname == "admin" && pwd == "admin";
        }
        [Authorize]
        public ActionResult Home()
        {
            string userName = User.Identity.Name;
            return View();
        }
        [Authorize]
        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
