using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile
{
    public partial class dryz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "真爱验证";
            Title = "CTloves钻戒真爱验证_唯爱诺珠宝官网\r\n";

            (Master as nSite).IsGray = false;
            (Master as nSite).PanelClass = "dy_whrite";
            (Master as nSite).IsBGImg = true;
            (Master as nSite).BGImgUrl = "/mimages/dr_yz/bk.jpg";
        }            
    }
}