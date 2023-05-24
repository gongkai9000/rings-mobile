using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;
using DRM.BLL;
using System.Text.RegularExpressions;
using DRM.Common;
using drmobile.master;
using NetDimension.Weibo;
using System.Configuration;

namespace drmobile.Account
{
    public partial class Register : System.Web.UI.Page
    {
        OAuth oauth = new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], ConfigurationManager.AppSettings["CallbackUrl"]);
        protected string SinaURL { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();

            (Master as nSite).CurrentHeader = "注册用户";
            Title = "注册用户";

            SinaURL = oauth.GetAuthorizeURL();
        }

       

    }
}