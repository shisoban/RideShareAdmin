using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RideshareAdmin.WebUI.Service_Wrapper;

namespace RideshareAdmin.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                ServiceWrapper sw = new ServiceWrapper();
                if ( true)
                {

                }
                //if (login.IsValid(user.UserName, user.Password))
                //{
                //    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Login data is incorrect!");
                //}
            }
            return null;//View(user);
        }
        public ActionResult Logout()
        {
         //   FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}