using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile
{
    public partial class yzsb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "真爱验证查询";
            (Master as nSite).IsGray = false;
            this.Page.Title = "尚未购买过CTloves戒指-CTloves官网";
        }
    }
}