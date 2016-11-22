using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnMVCInSevenDaysPractice.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
		[AllowAnonymous]
        public ActionResult Index()
        {
			var e = new Exception("Invalid Controller or/and Action Name");
			var eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
    }
}