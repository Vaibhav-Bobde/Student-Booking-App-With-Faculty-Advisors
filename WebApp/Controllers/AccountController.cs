using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Models;
using ServiceLayer.Interface;
using AutoMapper;
using WebApp.Common;
using System.Web.Script.Serialization;
using System.Web.Configuration;

namespace WebApp.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService, IMapper mapper)
            : base(mapper)
        {
            this._userService = userService;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if(User != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home");
            }
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(WebApp.Models.User userDetails)
        {
            ServiceLayer.Models.User user = _userService.GetUser(userDetails.EmailId, userDetails.Pwd);
            if (user != null)
            {
                CustomPrincipalSerializedModel serializeModel = new CustomPrincipalSerializedModel();
                serializeModel.Id = user.Uid;
                serializeModel.FirstName = user.Fname;
                serializeModel.LastName = user.Lname;
                serializeModel.Role = user.UserRole.RoleName;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string userDataSerialized = serializer.Serialize(serializeModel);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                         1,
                         user.EmailId,
                         DateTime.Now,
                         DateTime.Now.AddMinutes(30),
                         false,
                         userDataSerialized);
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);
                return RedirectToAction("Home");
            }
            @ViewBag.LoginStatus = false;
            return View();
        } 
        private bool IsValidUser(string emailId, string pwd)
        {
            User user = _mapper.Map<Models.User>(_userService.GetUser(emailId, pwd));            
            return user != null;
        }
        public ActionResult Home()
        {
            ActionResult redirectResult = RedirectToAction("Home"); ;
            string userName = User.Identity.Name;
            switch(User.Role)
            {
                case "Admin":
                    redirectResult = View("Home");
                    break;
                case "Faculty":
                    redirectResult =  RedirectToAction("GetFacultySchedule", "Faculty");
                    break;
                case "Student":
                    redirectResult = RedirectToAction("StudentAppointment", "Student");
                    break;
            }
            return redirectResult;
        }
        public void LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            FormsAuthentication.RedirectToLoginPage();
        }
    }
}
