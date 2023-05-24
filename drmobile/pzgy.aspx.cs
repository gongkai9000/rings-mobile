using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile
{
    public partial class pzgy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "品质工艺";
            (Master as nSite).IsGray = false;
            this.Page.Title = "CTloves钻戒品质工艺_唯爱诺珠宝官网";
        }
    }
}