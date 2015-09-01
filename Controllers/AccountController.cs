using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SaaSCloud.Models;

namespace SaaSCloud.Controllers {
	[Authorize]
	public class AccountController:BaseController {
		public AccountController()
			: this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()))) {
		}

		public AccountController(UserManager<ApplicationUser> userManager) {
			UserManager = userManager;
		}

		public UserManager<ApplicationUser> UserManager { get; private set; }

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login() {
			// 如果已經登入，直接跳入首頁
			if (UserSession.UserId != null && UserSession.OrgDomain != null) {
				return RedirectToAction("Index", "Home", null);
			}

			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public ActionResult Authenticate(LoginViewModel model) {
			if (ModelState.IsValid) {
				bool result;
				try {
					result = model.Authenticate(model.UserId, model.Password, model.OrgDomainName);
					if (!result) {
						TempData["ErrorMessage"] = "認證錯誤";
						return RedirectToAction("Index", "Home");
					}
				} catch (Exception ex) {
					//UserSession.ErrorLogging(this.Request.RequestContext, ex);
					TempData["ErrorMessage"] = "認證錯誤: " + ex.Message;
					return RedirectToAction("Index", "Home");
				}

				UserSession.UserId = model.UserId;
				UserSession.OrgDomain = model.OrgDomainName;

				//UserSession.UserLogging(model);
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		//
		// POST: /Account/LogOff
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff() {
			//AuthenticationManager.SignOut();
			//return RedirectToAction("Index", "Home");
			Session.Abandon();
			return RedirectToAction("Login", "Account");
		}

	}
}
