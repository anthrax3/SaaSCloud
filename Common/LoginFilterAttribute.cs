using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaaSCloud.Common {
	public class LoginFilterAttribute:ActionFilterAttribute {
		private static readonly List<string> exceptionAction = new List<string>() { "Login", "LogOut", "TimeoutError", "Authenticate" }; //?????? 暫定

		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
			filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
			filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			filterContext.HttpContext.Response.Cache.SetNoStore();

			HttpSessionStateBase session = filterContext.HttpContext.Session;

			object user = null;
			if (session != null) {
				user = session[SessionInfo.SK_USER_ID];
			}

			if (user == null || session == null || session.IsNewSession) {
				//send them off to the login page

				var action = filterContext.RouteData.Values["action"].ToString();
				if (!exceptionAction.Contains(action)) {
					if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.HttpContext.Request.Files.Count > 0  /*Kendo UI Upload*/) {
						filterContext.HttpContext.Items["SessionNotFound"] = true;
					} else {
						UrlHelper url = new UrlHelper(filterContext.RequestContext);
						string loginUrl = url.Action("Login", "Account");

						filterContext.Result = new RedirectResult(loginUrl);
					}
				}
			}

			//UserSession userSession = new UserSession();
			//userSession.UserLogging(filterContext);

			base.OnActionExecuting(filterContext);
		}

		//public override void OnActionExecuted(ActionExecutedContext filterContext)
		//{
		//    base.OnActionExecuted(filterContext);
		//}
	}
}
