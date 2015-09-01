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
    public class InvoiceController : Controller
    {
		public ActionResult Invoice() {
			return View();
		}

		public ActionResult P1() {
			return View();
		}

		public ActionResult P5() {
			return View();
		}

		[HttpPost]
		public ActionResult Invoice_chk(InvoiceOrderViewModel orderForm) {
			InvoicePurchaseModel  invoiceCheck = new InvoicePurchaseModel() ;
			invoiceCheck.mainProdName = orderForm.mainProdName ;
			invoiceCheck.shopname = orderForm.shopname ;
			invoiceCheck.addr = orderForm.addr ;
			invoiceCheck.contactname = orderForm.contactname ;
			invoiceCheck.contacttel = orderForm.contacttel ;
			invoiceCheck.orderDetail = new List<OrderDetailModel>() ;
			for (int i = 0; i < orderForm.prodType.Length; i++) {
				if ((orderForm.qty[i] ?? 0) > 0) {
					OrderDetailModel orderDetail = new OrderDetailModel() ;
					orderDetail.prodType = orderForm.prodType[i] ;
					orderDetail.prodName = orderForm.prodName[i];
					orderDetail.prodPrice = orderForm.prodPrice[i]??0;
					orderDetail.qty = orderForm.qty[i]??0;
					orderDetail.freightRate = 0;
					if (orderDetail.prodType == "熱感紙" && orderForm.Islands == "Y") {
						orderDetail.freightRate = 200 * orderDetail.qty;
					}
					orderDetail.subtotal += orderDetail.prodPrice * orderDetail.qty + orderDetail.freightRate;
					invoiceCheck.total += orderDetail.subtotal;

					invoiceCheck.orderDetail.Add(orderDetail);
				}
			}
			return View(invoiceCheck);
		}

		public ActionResult ConfirmPurchase(InvoicePurchaseModel invoiceCheck) {
			// call XOrder submit Invoice purchasing

			return View("Invoice");
		}

		//public ActionResult ConfirmPurchase() {
		//	return View("Invoice");
		//}

	}
}