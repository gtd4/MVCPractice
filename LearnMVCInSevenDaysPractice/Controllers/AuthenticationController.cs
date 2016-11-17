using LearnMVCInSevenDays.Models;
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
				var status = bal.GetUserValidity(u);
				var isAdmin = false;
				if (status == UserStatus.AuthenticatedAdmin)
				{
					isAdmin = true;
				}else if(status == UserStatus.AuthenticatedUser)
				{
					isAdmin = false;
				}
				else
				{
					ModelState.AddModelError("CredentialError", "Invalid Username or Password");
					return View("Login");
				}

				FormsAuthentication.SetAuthCookie(u.UserName, false);
				Session["IsAdmin"] = isAdmin;
				return RedirectToAction("Index", "Employee");
				
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