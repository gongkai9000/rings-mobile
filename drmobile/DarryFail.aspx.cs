using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drmobile
{
    public partial class DarryFail : System.Web.UI.Page
    {
        public string Name { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Name = Request.QueryString["Name"];
        }
    }
}