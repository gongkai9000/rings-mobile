using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile.helpCenter
{
    public partial class HandsizeHelp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "测量手寸";
            Title = "测量手寸";
        }
    }
}