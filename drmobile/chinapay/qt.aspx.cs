using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using ChinaPay_tsl;
using DRM.Common;

namespace drmobile.chinapay
{
    public partial class qt : System.Web.UI.Page
    {
        string status;
        string payid;
        string transdate;
        string amount;
        string currencycode;
        string checkvalue;
        public string strOrderid = "0";
        public string strPrice = "0";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}