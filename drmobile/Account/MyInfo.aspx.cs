using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.Common;
using DRM.BLL;
using DRM.Entity;

namespace drmobile.Account
{
    public partial class MyInfo : System.Web.UI.Page
    {
        public T_Member CurrentMember { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "个人信息";
            Title = "个人信息";
            CurrentMember = MemberBLL.GetMemberById(CurrentUser.CurrentUid);

            txtNickname.Value = CurrentMember.nickname;
            txtRealname.Value = CurrentMember.realname;
            if (CurrentMember.gender == "女")
            {
                woman.Checked = true;
            }
            else
            {
                man.Checked = true;
            }
            man.Value = "男";
            woman.Value = "女";

            if (!string.IsNullOrEmpty(CurrentMember.email))
            {
                txtEmail.Attributes.Add("readonly", "readonly");
            }
            txtEmail.Value = CurrentMember.email;

            if (!string.IsNullOrEmpty(CurrentMember.mobile))
            {
                txtMobile.Attributes.Add("readonly", "readonly");
            }
            txtMobile.Value = CurrentMember.mobile;
        }
    }
}