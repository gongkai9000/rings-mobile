using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL.Order;
using DRM.Common;
using DRM.Entity;
using drmobile.master;

namespace drmobile
{
    public partial class MyAfterService : System.Web.UI.Page
    {
        public string OrderId {
            get {
                return Request.QueryString["OrderId"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "我的售后";
            this.Title = "我的售后";
            OrderBLL obll = new OrderBLL();
            int datacount = 0;
            if (string.IsNullOrEmpty(OrderId))
            {
                var data = obll.GetOAfterByMember(CurrentUser.CurrentUid);
                datacount = data.Count;
                rpOrderDetail.DataSource = data;
                rpOrderDetail.DataBind();
            }
            else
            {
                var data = obll.GetOAfterByOrderId(OrderId);
                datacount = data.Count;
                rpOrderDetail.DataSource = data;
                rpOrderDetail.DataBind();
            }
            if (datacount == 0)
            {
                Server.Transfer("EmptyAfterService.aspx");
            }
        }

        public string getBtnText(view_orderdetailAfterservice oda)
        {
            if (oda.AfterServiceId.HasValue)
            {
                return "查看售后";
            }
            else
            {
                return "申请售后";
            }
        }

        public string getBtnUrl(view_orderdetailAfterservice oda)
        {
            if (oda.AfterServiceId.HasValue)
            {
                return "AfterServiceView.aspx?asid=" + oda.AfterServiceId;
            }
            else
            {
                return "AfterService.aspx?odid="+oda.Id;
            }
        }

    }
}