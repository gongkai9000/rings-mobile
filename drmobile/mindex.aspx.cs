using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.muc;
using drmobile.master;
using DRM.Common;

namespace drmobile
{
    public partial class mindex : System.Web.UI.Page
    {
        public bool isShowInfo { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as mSite).CurrentClass = Current.Brand;
            this.Title = "CTloves(CT真爱戒指)唯爱诺珠宝官方网站 | 求婚钻戒领导品牌";

            //首页弹框
            if (string.IsNullOrEmpty(CookieHelper.GetCookie("__indexShow")))
            {
                isShowInfo = true;
                CookieHelper.setCookie("__indexShow", "true");
            }
            
        }
    }
}