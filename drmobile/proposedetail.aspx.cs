using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using DRM.Entity;

namespace drmobile
{
    public partial class proposedetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Server.Transfer("/news/detail.aspx?id=" + id);
        }
    }
}