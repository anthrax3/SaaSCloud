using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
//using log4net ;

namespace SaaSCloud.Models
{
    public class OrderInfoModel
    {
        [Display(Name = "訂單編號")]
        public string OrderNo { get; set; }

        [Display(Name = "訂購時間")]
        public string OrderDateTime { get; set; }

        [Display(Name = "商品名稱")]
        public string ProdName { get; set; }

        [Display(Name = "金額")]
        public string Price { get; set; }

        [Display(Name = "狀態")]
        public string Status { get; set; }

        [Display(Name = "雲端電子發票")]
		public InvoideInfoModel InvoiceInfo { get; set; }

        [Display(Name = "CRM資訊")]
		public CRMInfoModel CRMInfo { get; set; }
    }
	public class InvoideInfoModel {
		[Display(Name = "合約起日")]
		public string ContractStartDate { get; set; }

		[Display(Name = "合約迄日")]
		public string ContractEndDate { get; set; }

		[Display(Name = "合約年限")]
		public string ContractValidYear { get; set; }

		[Display(Name = "用戶號碼")]
		public string AccountId { get; set; }

		[Display(Name = "費用項目")]
		public string FeeItem { get; set; }

		[Display(Name = "門市名稱")]
		public string StoreName { get; set; }

		[Display(Name = "聯絡人/電話")]
		public string Contact { get; set; }

		[Display(Name = "裝機地址")]
		public string InstalledAddress { get; set; }
	}

	public class CRMInfoModel {
		[Display(Name = "用戶號碼")]
		public string AccountId { get; set; }

		[Display(Name = "費用項目")]
		public string FeeItem { get; set; }

		[Display(Name = "帳號數")]
		public int? AccountNumber { get; set; }

		[Display(Name = "空間大小")]
		public int? SpaceSize { get; set; }
	}

	public class InvoiceOrderViewModel {
		[Display(Name = "原始產品")]
		public string mainProdName { get; set; }

		[Display(Name = "產品種植")]
		public string[] prodType { get; set; }

		[Display(Name = "產品名稱")]
		public string[] prodName { get; set; }

		[Display(Name = "產品價格")]
		public int?[] prodPrice { get; set; }

		[Display(Name = "訂購數量")]
		public int?[] qty { get; set; }

		[Display(Name = "門市名稱")]
		public string shopname { get; set; }

		[Display(Name = "門市地址")]
		public string addr { get; set; }

		[Display(Name = "聯絡人姓名")]
		public string contactname { get; set; }

		[Display(Name = "聯絡人電話")]
		public string contacttel { get; set; }

		[Display(Name = "配送至離島")]
		public string Islands { get; set; }
	}

	public class InvoicePurchaseModel {
		[Display(Name = "原始產品")]
		public string mainProdName { get; set; }

		[Display(Name = "門市名稱")]
		public string shopname { get; set; }

		[Display(Name = "門市地址")]
		public string addr { get; set; }

		[Display(Name = "聯絡人姓名")]
		public string contactname { get; set; }

		[Display(Name = "聯絡人電話")]
		public string contacttel { get; set; }

		[Display(Name = "訂購明細")]
		public List<OrderDetailModel> orderDetail { get; set; }

		[Display(Name = "訂單金額")]
		public int total { get; set; }
	}

	public class CRMPurchaseModel {
		[Display(Name = "產品名稱")]
		public string mainProdName { get; set; }

		[Display(Name = "帳號數")]
		public int? accountNumber { get; set; }

		[Display(Name = "空間大小")]
		public int? spaceSize { get; set; }
	}

	public class OrderDetailModel {
		[Display(Name = "產品種類")]
		public string prodType { get; set; }

		[Display(Name = "產品名稱")]
		public string prodName { get; set; }

		[Display(Name = "產品價格")]
		public int prodPrice { get; set; }

		[Display(Name = "訂購數量")]
		public int qty { get; set; }

		[Display(Name = "運費")]
		public int freightRate { get; set; }

		[Display(Name = "小計")]
		public int subtotal { get; set; }
	}

	public class CRMOrderFormModel {
		[Display(Name = "產品名稱")]
		public string prodName { get; set; }

		[Display(Name = "加購帳號數")]
		public int? CRM_acct { get; set; }

		[Display(Name = "加購儲存空間")]
		public int? CRM_space { get; set; }
	}

	public class CRMCheckModel {
		[Display(Name = "產品名稱")]
		public string prodName { get; set; }

		[Display(Name = "帳號費用")]
		public int crm_acct_price { get; set; }

		[Display(Name = "加購帳號數")]
		public int CRM_acct { get; set; }

		[Display(Name = "加購帳號費用合計")]
		public int CRM_acct_total { get; set; }

		[Display(Name = "儲存空間費用")]
		public int crm_space_price { get; set; }

		[Display(Name = "加購儲存空間")]
		public int CRM_space { get; set; }

		[Display(Name = "加購帳號費用合計")]
		public int CRM_space_total { get; set; }

		[Display(Name = "總計")]
		public int crm_result_price { get; set; }
	}

	public class CRMProductModel {
		[Display(Name = "產品名稱")]
		public string ProdName { get; set; }
	}

	public class PostInfoModel {
		[Display(Name = "產品編號")]
		public string ENNumber { get; set; }

		[Display(Name = "產品名稱")]
		public string ProdName { get; set; }

		public List<CompanyInfoModel> CompanyInfoList { get; set; }
	}

	public class CompanyInfoModel {
		[Display(Name = "公司名稱")]
		public string CompanyName { get; set; }

		[Display(Name = "公司地址")]
		public string CompanyAddress { get; set; }

		[Display(Name = "訂單處理中")]
		public bool PendingOrder { get; set; }

		public List<StoreInfoModel> StoreInfoList { get; set; }
	}

	public class StoreInfoModel {
		[Display(Name = "門市名稱")]
		public string StoreName { get; set; }

		[Display(Name = "門市地址")]
		public string StoreAddress { get; set; }

		[Display(Name = "連絡人")]
		public string Contacts { get; set; }

		[Display(Name = "電話")]
		public string ContactsTel { get; set; }
	}

	public class MainProdPurchaseInfoModel {	// 原始產品資訊
		[Display(Name = "購買P1產品")]
		public bool PurchaseInvoiceP1 { get; set; }

		[Display(Name = "購買P5產品")]
		public bool PurchaseInvoiceP5 { get; set; }

		[Display(Name = "購買CRM行銷高手產品")]
		public CRMInfoModel PurchaseCRMStandard { get; set; }

		[Display(Name = "購買CRM豪華版產品")]
		public CRMInfoModel PurchaseCRMAdvance { get; set; }
	}

	public class SaaSCloudInfoModel {
		// properties
		[Display(Name = "客戶帳號")]
		public string customerId { get; set; }

		[Display(Name = "帳號類別")]
		public string idType { get; set; }

		[Display(Name = "客戶名稱")]
		public string customerName { get; set; }

		[Display(Name = "原始產品購買資訊")]
		public MainProdPurchaseInfoModel mainProdPurchaseInfo { get; set; }

		[Display(Name = "產品訂購資訊")]
		public List<OrderInfoModel> orderInfoList { get; set; }

		[Display(Name = "Invoice產品郵寄資訊")]
		public List<PostInfoModel> postInfoList { get; set; }

		// *************************************************************************************
		// methods
		public MainProdPurchaseInfoModel getMainProdPurchaseInfo() {
			MainProdPurchaseInfoModel purchaseInfo = new MainProdPurchaseInfoModel() ;

			purchaseInfo.PurchaseInvoiceP1 = true;
			purchaseInfo.PurchaseInvoiceP5 = true;

			CRMInfoModel  CRMStandard = new CRMInfoModel() ;
			CRMStandard.AccountNumber = 2 ;
			CRMStandard.SpaceSize = 3 ;
			purchaseInfo.PurchaseCRMStandard = CRMStandard;

			CRMInfoModel CRMAdvance = new CRMInfoModel();
			CRMAdvance.AccountNumber = 3;
			CRMAdvance.SpaceSize = 2;
			purchaseInfo.PurchaseCRMAdvance = CRMAdvance;

			return purchaseInfo;
		}
		public List<OrderInfoModel> getOrderInfoList() {
			List<OrderInfoModel> orderList = new List<OrderInfoModel>();
			OrderInfoModel orderHistory1 = new OrderInfoModel() {
				OrderNo = "000000239",
				OrderDateTime = Convert.ToDateTime("2015/6/11 下午 05:55:00").ToString("yyyy/MM/dd HH:mm:ss"),
				ProdName = "雲端電子發票",
				Price = 11500.ToString("C0"),
				Status = "處理中",
			};
			InvoideInfoModel invoiceInfo = new InvoideInfoModel() {
				ContractStartDate = Convert.ToDateTime("2015/06/17").ToString("yyyy/MM/dd"),
				ContractEndDate = Convert.ToDateTime("2017/06/17").ToString("yyyy/MM/dd"),
				ContractValidYear = "兩年",
				AccountId = "EN09000001",
				FeeItem = "月租",
				StoreName = "XXX中和店",
				Contact = "王先生<BR>0987654321",
				InstalledAddress = "台北市文山區XX路XX街X樓X號-X"
			};
			orderHistory1.InvoiceInfo = invoiceInfo;
			orderList.Add(orderHistory1);

			OrderInfoModel orderHistory2 = new OrderInfoModel() {
				OrderNo = "000000240",
				OrderDateTime = Convert.ToDateTime("2015/6/11 下午 05:55:00").ToString("yyyy/MM/dd HH:mm:ss"),
				ProdName = "CRM行銷高手",
				Price = 11500.ToString("C0"),
				Status = "處理中",
			};
			CRMInfoModel crmStdInfo = new CRMInfoModel() {
				AccountId = "EN09000002",
				FeeItem = "月租",
				AccountNumber = 2,
				SpaceSize = 3,
			};
			orderHistory2.CRMInfo = crmStdInfo;
			orderList.Add(orderHistory2);

			OrderInfoModel orderHistory3 = new OrderInfoModel() {
				OrderNo = "000000241",
				OrderDateTime = Convert.ToDateTime("2015/6/11 下午 05:55:00").ToString("yyyy/MM/dd HH:mm:ss"),
				ProdName = "CRM豪華版",
				Price = 11500.ToString("C0"),		// momey mask
				Status = "註銷中",
			};
			CRMInfoModel crmAdvInfo = new CRMInfoModel() {
				AccountId = "EN09000003",
				FeeItem = "月租",
				AccountNumber = 2,
				SpaceSize = 3,
			};
			orderHistory3.CRMInfo = crmAdvInfo;
			orderList.Add(orderHistory3);

			return orderList ;
		}


		public List<PostInfoModel> getPostInfoList() {
			List<PostInfoModel> postInfoList = new List<PostInfoModel>();
			PostInfoModel postInfo1 = new PostInfoModel();
			postInfo1.ENNumber = "EN09000001";
			postInfo1.ProdName = "P1";
			postInfo1.CompanyInfoList = new List<CompanyInfoModel>();

			CompanyInfoModel companyInfo1 = new CompanyInfoModel();
			companyInfo1.CompanyName = "A公司";
			companyInfo1.CompanyAddress = "台北市大安區信義路四段88號5樓";
			companyInfo1.PendingOrder = false;
			companyInfo1.StoreInfoList = new List<StoreInfoModel>();

			StoreInfoModel storeInfo1 = new StoreInfoModel();
			storeInfo1.StoreName = "A1門市";
			storeInfo1.StoreAddress = "台北市大安區信義路四段88號5樓";
			storeInfo1.Contacts = "王小明";
			storeInfo1.ContactsTel = "02-23445961";
			companyInfo1.StoreInfoList.Add(storeInfo1);

			StoreInfoModel storeInfo2 = new StoreInfoModel();
			storeInfo2.StoreName = "A2門市";
			storeInfo2.StoreAddress = "台北市大安區信義路四段74巷11號5樓";
			storeInfo2.Contacts = "王大明";
			storeInfo2.ContactsTel = "02-23267891";
			companyInfo1.StoreInfoList.Add(storeInfo2);

			postInfo1.CompanyInfoList.Add(companyInfo1);

			CompanyInfoModel companyInfo2 = new CompanyInfoModel();
			companyInfo2.CompanyName = "B公司";
			companyInfo2.CompanyAddress = "台北市中正區信義路一段21-3樓1202室";
			companyInfo2.PendingOrder = false;
			companyInfo2.StoreInfoList = new List<StoreInfoModel>();

			StoreInfoModel storeInfo3 = new StoreInfoModel();
			storeInfo3.StoreName = "B1門市";
			storeInfo3.StoreAddress = "台北市中正區杭州南路一段26號7樓";
			storeInfo3.Contacts = "王中明";
			storeInfo3.ContactsTel = "0910-111213";
			companyInfo2.StoreInfoList.Add(storeInfo3);

			StoreInfoModel storeInfo4 = new StoreInfoModel();
			storeInfo4.StoreName = "B2門市";
			storeInfo4.StoreAddress = "台北市信義區松德路168巷20號2樓";
			storeInfo4.Contacts = "王又明";
			storeInfo4.ContactsTel = "02-87447509";
			companyInfo2.StoreInfoList.Add(storeInfo4);

			postInfo1.CompanyInfoList.Add(companyInfo2);
			postInfoList.Add(postInfo1);

			List<PostInfoModel> postInfoList2 = new List<PostInfoModel>();
			PostInfoModel postInfo2 = new PostInfoModel();
			postInfo2.ENNumber = "EN09000002";
			postInfo2.ProdName = "P5";
			postInfo2.CompanyInfoList = new List<CompanyInfoModel>();

			CompanyInfoModel companyInfo3 = new CompanyInfoModel();
			companyInfo3.CompanyName = "A公司";
			companyInfo3.CompanyAddress = "台北市大安區信義路四段88號5樓";
			companyInfo3.PendingOrder = true;
			companyInfo3.StoreInfoList = new List<StoreInfoModel>();

			StoreInfoModel storeInfo5 = new StoreInfoModel();
			storeInfo5.StoreName = "A1門市";
			storeInfo5.StoreAddress = "台北市大安區信義路四段88號5樓";
			storeInfo5.Contacts = "王小明";
			storeInfo5.ContactsTel = "02-23445961";
			companyInfo3.StoreInfoList.Add(storeInfo5);

			StoreInfoModel storeInfo6 = new StoreInfoModel();
			storeInfo6.StoreName = "A2門市";
			storeInfo6.StoreAddress = "台北市大安區信義路四段74巷11號5樓";
			storeInfo6.Contacts = "王大明";
			storeInfo6.ContactsTel = "02-23267891";
			companyInfo3.StoreInfoList.Add(storeInfo6);

			postInfo2.CompanyInfoList.Add(companyInfo3);

			CompanyInfoModel companyInfo4 = new CompanyInfoModel();
			companyInfo4.CompanyName = "B公司";
			companyInfo4.CompanyAddress = "台北市中正區信義路一段21-3樓1202室";
			companyInfo4.PendingOrder = false;
			companyInfo4.StoreInfoList = new List<StoreInfoModel>();

			StoreInfoModel storeInfo7 = new StoreInfoModel();
			storeInfo7.StoreName = "B1門市";
			storeInfo7.StoreAddress = "台北市中正區杭州南路一段26號7樓";
			storeInfo7.Contacts = "王中明";
			storeInfo7.ContactsTel = "0910-111213";
			companyInfo4.StoreInfoList.Add(storeInfo7);

			StoreInfoModel storeInfo8 = new StoreInfoModel();
			storeInfo8.StoreName = "B2門市";
			storeInfo8.StoreAddress = "台北市信義區松德路168巷20號2樓";
			storeInfo8.Contacts = "王又明";
			storeInfo8.ContactsTel = "02-87447509";
			companyInfo4.StoreInfoList.Add(storeInfo8);

			postInfo2.CompanyInfoList.Add(companyInfo4);
			postInfoList.Add(postInfo2);

			return postInfoList ;
		}
	}

}
