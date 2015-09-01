using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SaaSCloud.Models;
using Newtonsoft.Json;

namespace SaaSCloud.Common {
	public class SessionInfo {
		public const string SK_ORG_DOMAIN = "OrgDomain";
		public const string SK_USER_ID = "UserId";
		public const string SK_ACCESS_TOKEN = "AccessToken";
		public const string SK_SaaSCloud_INFO = "SaaSCloudInfo";

		public string OrgDomain {
			get { return GetSessionString(SK_ORG_DOMAIN); }
			set { SetSession(SK_ORG_DOMAIN, value); }
		}

		public string UserId {
			get { return GetSessionString(SK_USER_ID); }
			set { SetSession(SK_USER_ID, value); }
		}

		public string AccessToken {
			get { return GetSessionString(SK_ACCESS_TOKEN); }
			set { SetSession(SK_ACCESS_TOKEN, value); }
		}

		public SaaSCloudInfoModel SaaSCloudInfo {
			get { return (SaaSCloudInfoModel) GetSession(SK_SaaSCloud_INFO); }
			set { SetSession(SK_SaaSCloud_INFO, value); }
		}

		#region Session操作 ==========
		/// <summary>
		/// 根據sessionKey取得Session值
		/// </summary>
		/// <param name="sessionKey"></param>
		/// <returns></returns>
		private object GetSession(string sessionKey) {
			if (sessionKey == null) {
				return  null ;
			}

			object sessionObj = null;
			var session = HttpContext.Current.Session;
			if (session != null) {
				sessionObj = session[sessionKey];
			}

			return sessionObj ;
		}

		private string GetSessionString(string sessionKey) {
			object sessionObj = GetSession(sessionKey);

			return (sessionObj != null ? Convert.ToString(sessionObj) : null);
		}

		private bool GetSessionBool(string sessionKey) {
			object sessionObj = GetSession(sessionKey);

			return (sessionObj != null ? Convert.ToBoolean(sessionObj) : false);
		}

		/// <summary>
		/// 設定Session值
		/// </summary>
		/// <param name="sessionKey"></param>
		/// <param name="value"></param>
		private void SetSession(string sessionKey, object value) {
			var session = HttpContext.Current.Session;
			if (session != null)
				session[sessionKey] = value;
		}

		/// <summary>
		/// 根據sessionKey刪除Session
		/// </summary>
		/// <param name="sessionKey"></param>
		private void DeleteSession(string sessionKey) {
			var session = HttpContext.Current.Session;
			if (session != null)
				session.Remove(sessionKey);
		}
		#endregion

		public string GetServerIP() {
			return Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
		}
	}
}
