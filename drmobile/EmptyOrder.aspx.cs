using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile
{
    public partial class EmptyOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "我的订单（空）";
            this.Title = "我的订单（空）";
        }
    }
}