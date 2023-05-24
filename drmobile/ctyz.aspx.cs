using drmobile.master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drmobile
{
    public partial class ctyz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master as nSite).CurrentHeader = "真爱验证";
            this.Title = "CTloves钻戒真爱验证_唯爱诺珠宝官网";
            (this.Master as nSite).IsGray = false;
            (this.Master as nSite).PanelClass = "dy_whrite";
            (this.Master as nSite).IsBGImg = true;
            (this.Master as nSite).BGImgUrl = "/mimages/dr_yz/bk.jpg";
        }
    }
}