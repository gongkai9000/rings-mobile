using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.Common;

namespace drmobile.CustomerService
{
    public partial class Center : System.Web.UI.Page
    {
        public string NickName
        {
            get
            {
                return CurrentUser.IsLogin ? CurrentUser.Member.nickname : "";
            }
        }
        public string UserID
        {
            get
            {
                return CurrentUser.IsLogin ? CurrentUser.CurrentUid.ToString() : "";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "客服中心";
            Title = "客服中心";
        }
    }
}