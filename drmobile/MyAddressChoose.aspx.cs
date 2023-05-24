using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.Entity;
using DRM.BLL;
using DRM.Common;

namespace drmobile
{
    public partial class MyAddressChoose : System.Web.UI.Page
    {
        public int OrderDetailId {
            get { return Convert.ToInt32(Request.QueryString["odid"]); }
        }

        public string ReturnUrl {
            get {
                if (string.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                {
                    return "AfterService.aspx?odid=" + OrderDetailId + "&addressid=";
                }
                else
                {
                    return Request.QueryString["returnUrl"];
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "选择地址";
            this.Title = "选择地址";

            var addressList = SpAddressBLL.GetAlladderssByUid(CurrentUser.CurrentUid);
            if (addressList.Count == 0)
            {
                Server.Transfer("EmptyAddress.aspx?returnUrl=" + ReturnUrl);
            }
            

            rpAddress.DataSource = addressList;
            rpAddress.DataBind();
        }

        public string isDefaultClass(bool isDefault)
        {
            if (isDefault)
            {
                return " mrad_click";
            }

            return string.Empty;
        }
    }
}