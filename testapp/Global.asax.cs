using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace testapp
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			clientauth.globals.Init("http://oauth.naumenko.biz",
				"c32c606064ca0f4aca748d3bd3d0f2739f0c4a85e7433f938157e06b204257",
				"1ec83b1fb3f4625e70d1e682672ea6a100");
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
		protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
		{
			clientauth.globals.sso();
		}
	}
}
