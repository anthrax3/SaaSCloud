using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaaSCloud.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using XOrderInterface;

namespace SaaSCloud.Controllers
{
    public class CRMController : Controller
    {
		public ActionResult Advance() {
			CRMProductModel prodModel = new CRMProductModel();
			prodModel.ProdName = "CRM豪華版" ;
			return View("Index", prodModel);
		}

		public ActionResult Standard() {
			CRMProductModel prodModel = new CRMProductModel();
			prodModel.ProdName = "CRM行銷高手" ;
			return View("Index", prodModel);
		}

		[HttpPost]
		public ActionResult CRM_check(CRMOrderFormModel orderForm) {
			CRMCheckModel crmCheck = new CRMCheckModel() ;
			crmCheck.prodName = orderForm.prodName ;
			crmCheck.crm_acct_price = 900 ;
			crmCheck.CRM_acct = orderForm.CRM_acct ?? 0 ;
			crmCheck.CRM_acct_total = crmCheck.crm_acct_price * crmCheck.CRM_acct ;
			crmCheck.crm_space_price = 3000 ;
			crmCheck.CRM_space = orderForm.CRM_space ?? 0 ;
			crmCheck.CRM_space_total = crmCheck.crm_space_price * crmCheck.CRM_space;
			crmCheck.crm_result_price = crmCheck.CRM_acct_total + crmCheck.CRM_space_total ;

			return View(crmCheck);
		}

		public ActionResult ConfirmPurchase(CRMPurchaseModel CRMPurchaseInfo) {
			// call XOrder submit CRM purchasing

			return RedirectToAction("Index", "Home");
		}

	}
}