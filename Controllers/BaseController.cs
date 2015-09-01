using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaaSCloud.Common;
using System.Reflection;

namespace SaaSCloud.Controllers {
	[LoginFilter]
	public class BaseController:Controller {
		private SessionInfo _userSession = null;
		protected SessionInfo UserSession {
			get { return _userSession ?? new SessionInfo(); }
		}
		protected override void OnActionExecuted(ActionExecutedContext filterContext) {
			base.OnActionExecuted(filterContext);
		}

		public ActionResult DynamicView(object model = null) {
			if (HttpContext.Request.IsAjaxRequest()) {
				return PartialView(model);
			} else {
				return View(model);
			}
		}

		public ActionResult DynamicView(string viewName, object model) {
			if (HttpContext.Request.IsAjaxRequest()) {
				return PartialView(viewName, model);
			} else {
				return View(viewName, model);
			}
		}

		public ActionResult ErrorMessagePage(string errorMessgae) {
			ViewBag.ErrorMessage = errorMessgae;
			return PartialView("ErrorPage");
		}
	}
}
