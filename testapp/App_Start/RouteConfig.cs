using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using testapp.Controllers;
using clientauth.Controllers;

namespace testapp
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				namespaces: new [] {typeof(HomeController).Namespace, typeof(OAuthController).Namespace}
			);
			/* *
			routes.MapRoute(
				name: "OAuth",
				url: "OAuth/{action}/{id}",
				defaults: new { action = "ExternalSignOn", id = UrlParameter.Optional },
				namespaces: new[] { "clientauth.Controllers" }
			);
			/* */
		}
	}
}
