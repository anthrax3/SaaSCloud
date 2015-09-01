
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SaaSCloud.Authenticate;
using SaaSCloud.Common;

namespace SaaSCloud.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "帳號")]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

		[Display(Name = "組織名稱")]
		public string OrgDomainName { get; set; }

        public bool Authenticate(string _username, string _pwd, string _orgname)
        {
            bool result = true;

			//string fullAccount = string.Format("{0}@{1}.hisales.hinet.net", _username, _orgname);

			////呼叫 hinet 的 web service 驗證
			//ServiceSoapClient wsClient = new ServiceSoapClient("ServiceSoap");
			//if (wsClient.IsAuthenticated(fullAccount, _pwd)) {
			//	result = (int) LoginValidation.pass;
			//} else {
			//	return (int) LoginValidation.PasswordError;
			//}

			SessionInfo session = new SessionInfo();

			SaaSCloudInfoModel  saasCloudInfo = new SaaSCloudInfoModel() ;
			saasCloudInfo.mainProdPurchaseInfo = saasCloudInfo.getMainProdPurchaseInfo();
			saasCloudInfo.orderInfoList = saasCloudInfo.getOrderInfoList();
			saasCloudInfo.postInfoList = saasCloudInfo.getPostInfoList();

			session.SaaSCloudInfo = saasCloudInfo;

            return result;
        }

	}
}
