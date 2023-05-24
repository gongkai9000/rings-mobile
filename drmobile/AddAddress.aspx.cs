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

namespace drmobile
{
    public partial class AddAddress : System.Web.UI.Page
    {
        public string ReturnURL {
            get {
                if (string.IsNullOrEmpty(Request.QueryString["returnurl"]))
                {
                    return "MyAddress.aspx";
                }
                return Request.QueryString["returnurl"];
            }
        }

        public string Action { get {
            return string.IsNullOrEmpty(Request.QueryString["id"]) ? "add" : "save";
        } }

        public string pTitle { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            T_SpAddress CurrentAddress = new T_SpAddress();
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                (Master as nSite).CurrentHeader = "添加地址";
                pTitle = "添加地址";
                CurrentAddress = SpAddressBLL.GetAddressById(Convert.ToInt32(Request.QueryString["id"]));
            }
            else
            {
                (Master as nSite).CurrentHeader = "修改地址";
                pTitle = "修改地址";
            }
            Title = pTitle;
            int uid = CurrentUser.CurrentUid;
                                        
        }
    }
}