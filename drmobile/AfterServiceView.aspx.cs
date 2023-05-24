using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using DRM.Entity;
using drmobile.master;
using DRM.Common;

namespace drmobile
{
    public partial class AfterServiceView : System.Web.UI.Page
    {
        public string NickName { get {
            return CurrentUser.Member.nickname;
        } }
        public int UserId { get {
            return CurrentUser.CurrentUid;
        } }

        public tb_AfterService CurrentService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "查看售后";
            Title = "查看售后";
            AfterServiceBLL asbll = new AfterServiceBLL();
            CurrentService = asbll.GetAfterServiceByid(Convert.ToInt32(Request.QueryString["asid"]));
            
        }
    }
}