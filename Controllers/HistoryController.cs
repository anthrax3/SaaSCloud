using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaaSCloud.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using XOrderInterface;
using SaaSCloud.Common;

namespace SaaSCloud.Controllers {
	public class HistoryController:Controller {
		public ActionResult History() {
			return View();
		}

		[HttpPost]
		public ActionResult GetOrderHistory([DataSourceRequest] DataSourceRequest request) {
			//QueryProductOrderAPI  queryProductOrderAPI = new QueryProductOrderAPI() ;
			//List<ProductOrderInfo> orderList = queryProductOrderAPI.QueryCustomerProductOrder("", "");

			List<OrderInfoModel> orderList = new List<OrderInfoModel>();
			SessionInfo session = new SessionInfo();
			SaaSCloudInfoModel saasCloudInfo = session.SaaSCloudInfo;
			orderList = saasCloudInfo.orderInfoList;

			//IQueryable<OrderHistoryModel> queryOrderList = orderList.AsQueryable();

			//return Json(queryOrderList.ToDataSourceResult(request));
			return Json(orderList);
		}

		[HttpPost]
		public ActionResult CancelOrder(string orderNo) {
			return Json(new { Success = true, Message = "成功" });
		}
	}
}
