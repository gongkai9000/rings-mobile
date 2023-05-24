using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.Common;

namespace drmobile.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = CurrentUser.CurrentUid;
            (Master as nSite).CurrentHeader = "修改密码";
            Title = "修改密码";
        }
    }
}
