using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile
{
	public partial class shop : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            (Master as nSite).CurrentHeader = "CTloves 实体店";
            this.Page.Title = "CTloves实体店地址_CTloves官网";
		}
	}
}