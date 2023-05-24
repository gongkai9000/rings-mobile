using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using DRM.Entity;
using drmobile.master;
using System.Text.RegularExpressions;

namespace drmobile.news
{
    public partial class detail : System.Web.UI.Page
    {
        public T_ProposeNews CurrentNews { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentNews = ProposeBLL.GetProposeById(Convert.ToInt32(Request.QueryString["id"]));
            Context.Items["newsdetail"] = CurrentNews;

            string regexWidth = "width=\"(.*?)\"";
            string regexHeight = "height=\"(.*?)\""; 
            CurrentNews.ProposeNewsContent = Regex.Replace(CurrentNews.ProposeNewsContent, regexWidth, "");
            CurrentNews.ProposeNewsContent = Regex.Replace(CurrentNews.ProposeNewsContent, regexHeight, "");

            (Master as nSite).CurrentHeader = "资讯中心";
            Title = CurrentNews.ProposeNewsTitle + " - CTloves唯爱诺珠宝官网";

            (Master as nSite).IsGray = false;
            (Master as nSite).PanelClass = "thewhrite";
        }
    }
}