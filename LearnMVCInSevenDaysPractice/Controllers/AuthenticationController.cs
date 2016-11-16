using LearnMVCInSevenDaysPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnMVCInSevenDaysPractice.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult DoLogin(UserDetails u)
		{
			if (ModelState.IsValid)
			{
				var bal = new EmployeeBusinessLayer();
				if (bal.IsValidUser(u))
				{
					FormsAuthentication.SetAuthCookie(u.UserName, false);
					return RedirectToAction("Index", "Employee");
				}

				ModelState.AddModelError("CredentialError", "Invalid Username or Password");
				return View("Login");
			}
			else
			{
				return View("Login");
			}
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Login");
		}
    }
}