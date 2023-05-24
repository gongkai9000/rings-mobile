using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.BLL;
using DRM.Common;

namespace drmobile.news
{
    public partial class center : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "资讯中心";
            Title = "钻石知识_钻石的专业知识_钻石珠宝知识大全 - CTloves唯爱诺珠宝官网";

            NewsBLL nbll = new NewsBLL();

            ucPinpai.NewsList = nbll.getNewsByType(nbll.getChild(WebConfig.Pinpai), ucPinpai.PageSize);
            ucQiuhun.NewsList = nbll.getNewsByType(nbll.getChild(WebConfig.Qiuhun), ucQiuhun.PageSize);
            ucZuanshi.NewsList = nbll.getNewsByType(nbll.getChild(WebConfig.ZuanshiBaike), ucZuanshi.PageSize);
            ucZhubao.NewsList = nbll.getNewsByType(nbll.getChild(WebConfig.ZhubaoBaike), ucZhubao.PageSize);
        }
    }
}