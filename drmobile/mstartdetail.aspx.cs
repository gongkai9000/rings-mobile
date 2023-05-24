using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.BLL;

namespace drmobile
{
    public partial class mstartdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            (Master as nSite).CurrentHeader = "明星见证详情页";

            (Master as nSite).IsGray = false;

            this.Title = ProposeBLL.GetProposeById(Convert.ToInt32(Request["id"] ?? "1")).ProposeNewsTitle + "_CTloves官网";
        }
    }
}