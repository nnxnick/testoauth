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
				clientauth.globals.secsetuser(sgn.login);
				System.Web.Security.FormsAuthentication.SetAuthCookie(sgn.login, false);
			}

			return Redirect("/");
		}

		/* *
		[HttpGet]
		public ActionResult ExternalSignOn()
		{
			ViewBag.formsso =
				@"
<html>
<head>
</head>
<body>
<form action=""/Profile/SignOn"" method=""post"" id=""form1"" enctype=""application/x-www-form-urlencoded"" accept-charset=""UTF-8"">
<textarea id=""jsonstr"" name=""jsonstr"">
{
""returnurl"":""http://local/Profile/Register"",
""token"":""1ec83b1fb3f4625e70d1e682672ea6a100c32c606064ca0f4aca748d3bd3d0f2"",
""clientkey"":""739f0c4a85e7433f938157e06b204257""
}
</textarea>
<script type=""text/javascript"">
form1.submit();
</script>
</form>
</body>
</html>
";

			return View();
		}
		/* */
	}
}