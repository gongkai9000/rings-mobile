using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Common;
using DRM.BLL;

namespace drmobile.muc
{
    public partial class header : System.Web.UI.UserControl
    {
        public string UserID
        {
            get
            {
                return CurrentUser.IsLogin ? CurrentUser.CurrentUid.ToString() : "";
            }
        }
        public int CartCount
        {
            get;
            set;
        }

        public string NickName
        {
            get
            {
                return CurrentUser.IsLogin ? CurrentUser.Member.nickname : "";
            }
        }
        public string UrlStr { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UrlStr = "/MemberCenter.aspx";
            if (CurrentUser.IsLogin)
            {
                CartBLL cbll = new CartBLL();
                CartCount = cbll.GetCartCount(CurrentUser.CurrentUid);
            }
        }
    }


}