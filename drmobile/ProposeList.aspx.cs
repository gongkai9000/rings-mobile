using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drmobile
{
	public partial class proposelist : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string id = Request.QueryString["id"];
            Server.Transfer("/news/list.aspx?typeid=" + id);
		}
	}
}