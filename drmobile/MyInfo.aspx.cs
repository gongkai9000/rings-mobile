using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;
using DRM.BLL;
using DRM.Common;

namespace drmobile
{
    public partial class MyInfo : System.Web.UI.Page
    {
        public T_Member Member { get; set; }
        public string MyInfoCmd = MemberBLL.MyInfoCmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.Action = MyInfoCmd;
            Member = MemberBLL.GetMemberById(CurrentUser.CurrentUid);
        }

        public string Gender(string g,string radioType)
        {
            return g == radioType ? "checked='checked'" : "";
        }
    }
}