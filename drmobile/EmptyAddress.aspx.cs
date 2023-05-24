using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile
{
    public partial class EmptyAddress : System.Web.UI.Page
    {
        public string ReturnUrl { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnUrl = Request.QueryString["returnUrl"];
            (Master as nSite).CurrentHeader = "收货地址（空）";
            Title = "收货地址（空）";
        }
    }
}