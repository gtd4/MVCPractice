using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LearnMVCInSevenDaysPractice
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapMvcAttributeRoutes();

			routes.MapRoute(
				name: "Upload",
				url: "Employee/BulkUpload",
				defaults: new { controller = "BulkUpload", action = "Index" }
				);

			routes.MapRoute(
				name: "Add-New",
				url: "Add-New/Employee",
				defaults: new { controller = "Employee", action = "AddNew" }


				);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
