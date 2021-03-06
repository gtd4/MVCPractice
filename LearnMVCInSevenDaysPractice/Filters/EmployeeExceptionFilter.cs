﻿using LearnMVCInSevenDaysPractice.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnMVCInSevenDaysPractice.Filters
{
	public class EmployeeExceptionFilter : HandleErrorAttribute
	{
		public override void OnException(ExceptionContext filterContext)
		{
			var logger = new FileLogger();
			logger.LogException(filterContext.Exception);
			base.OnException(filterContext);
		}
	}
}