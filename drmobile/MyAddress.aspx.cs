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
    public partial class MyAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "收货地址";
            this.Title = "收货地址";

            var addressList = SpAddressBLL.GetAlladderssByUid(CurrentUser.CurrentUid);
            if (addressList.Count == 0)
            {
                Server.Transfer("EmptyAddress.aspx");
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