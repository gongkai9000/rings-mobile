using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile
{
    public partial class brand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "品牌理念";
            Title = "CTloves品牌理念：一生只能买一次的钻戒_CTloves官网";
            (Master as nSite).IsGray = false;
        }
    }
}