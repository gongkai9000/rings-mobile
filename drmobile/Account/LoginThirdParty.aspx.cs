using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetDimension.Weibo;
using System.Configuration;
using drmobile.master;

namespace drmobile.Account
{
    public partial class LoginThirdParty : System.Web.UI.Page
    {
        public string ReturnUrl { get; set; }

        OAuth oauth = new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], ConfigurationManager.AppSettings["CallbackUrl"]);
        protected string SinaURL { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //(Master as nSite).CurrentHeader = "用户登录";
            this.ReturnUrl = Request["returnUrl"];
            string url = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();
            if (ReturnUrl == null && !url.Contains("Register.aspx"))
            {
                this.ReturnUrl = url;
            }
            (Master as nSite).CurrentHeader = "用户登录";
            Title = "用户登录";

            SinaURL = oauth.GetAuthorizeURL();
        }
    }
}