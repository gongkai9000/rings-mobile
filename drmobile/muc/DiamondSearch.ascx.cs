using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drmobile.muc
{
    public partial class DiamondSearch : System.Web.UI.UserControl
    {
        public int ProductID
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["id"]);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}