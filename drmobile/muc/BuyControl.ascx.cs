using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Common;

namespace drmobile.muc
{
    public partial class BuyControl : System.Web.UI.UserControl
    {
        public string UserID {
            get {
                return CurrentUser.IsLogin ? CurrentUser.CurrentUid.ToString() : "";
            }
        }

        public string NickName {
            get {
                return CurrentUser.IsLogin ? CurrentUser.Member.nickname : "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}