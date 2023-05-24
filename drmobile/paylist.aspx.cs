using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile
{
    public partial class paylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "支付方式";
            Title = "支付方式";
            
        }
    }
}