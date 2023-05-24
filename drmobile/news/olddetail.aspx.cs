using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using System.Text.RegularExpressions;
using DRM.BLL;
using DRM.Entity;

namespace drmobile.news
{
    public partial class olddetail : System.Web.UI.Page
    {
        public T_Page CurrentDetail { get; set; }
        //珠宝资讯的兼容详情页
        protected void Page_Load(object sender, EventArgs e)
        {
            NewsBLL nbll = new NewsBLL();
            CurrentDetail = nbll.getOldDetail(Convert.ToInt32(Request.QueryString["id"]));


            string regexWidth = "width=\"(.*?)\"";
            string regexHeight = "height=\"(.*?)\"";
            CurrentDetail.content = Regex.Replace(CurrentDetail.content, regexWidth, "");
            CurrentDetail.content = Regex.Replace(CurrentDetail.content, regexHeight, "");

            (Master as nSite).CurrentHeader = "资讯中心";
            Title = CurrentDetail.title + " - CTloves唯爱诺珠宝官网";

            (Master as nSite).IsGray = false;
            (Master as nSite).PanelClass = "thewhrite";
        }
    }
}