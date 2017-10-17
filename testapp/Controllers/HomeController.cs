using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testapp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[HttpPost]
		public ActionResult ExternalSignOn(clientauth.SignOnJson model)
		{
			clientauth.UserInfo sgn = null;
			try
			{
				sgn = Newtonsoft.Json.JsonConvert.DeserializeObject<clientauth.UserInfo>(model.jsonstr);
			}
			catch { }
			if (sgn != null && (string.IsNullOrEmpty(sgn.login) == false))
			{
				{
					System.Security.Principal.GenericIdentity newUser =
						new System.Security.Principal.GenericIdentity(sgn.login);
					System.Threading.Thread.CurrentPrincipal =
						new System.Security.Principal.GenericPrincipal(newUser, clientauth.globals.brl);
					if (System.Web.HttpContext.Current != null)
					{
						System.Web.HttpContext.Current.User =
							System.Threading.Thread.CurrentPrincipal;
					}
				}
				System.Web.Security.FormsAuthentication.SetAuthCookie(sgn.login, false);
			}

			return Redirect("/");
		}

	}
}