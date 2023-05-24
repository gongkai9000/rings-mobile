using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DRM.Common;

namespace drmobile.other.weixin.valentine2015
{
    public partial class index : System.Web.UI.Page
    {
        public string appid { get; set; }
        public long timestamp { get; set; }
        public string nonceStr { get; set; }
        public string signature { get; set; }
        public string host { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            appid = ConfigurationManager.AppSettings["weixin_appid"];
            //MemcachedObject o = new MemcachedObject();
            //o.Remove("weixin_access_token");
            //o.Remove("weixin_jsapi_ticket");

            timestamp = DRM.Common.Weixin.CreatenTimestamp();
            nonceStr = DRM.Common.Weixin.CreatenNonce_str();
            string string1 = string.Empty;
            host = "http://" + HttpContext.Current.Request.Url.Host;
            signature = DRM.Common.Weixin.GetSignature(DRM.Common.Weixin.Weixin_Jsapi_Ticket(), nonceStr, timestamp, (host + Request.Url.PathAndQuery).ToLower(), out string1);
        }
    }
}