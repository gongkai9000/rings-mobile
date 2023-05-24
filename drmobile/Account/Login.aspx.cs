using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;
using DRM.BLL;
using DRM.Common;
using drmobile.master;
using NetDimension.Weibo;
using System.Configuration;

namespace drmobile.Account
{
    public partial class Login : System.Web.UI.Page
    {
        public string ReturnUrl { get; set; }

        OAuth oauth = new OAuth(ConfigurationManager.AppSettings["sinaAppKey"], ConfigurationManager.AppSettings["sinaAppSecret"], ConfigurationManager.AppSettings["sinaCallbackUrl"]);
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