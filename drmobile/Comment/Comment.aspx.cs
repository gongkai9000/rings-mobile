using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.Entity;
using DRM.BLL.Order;
using DRM.Common;

namespace drmobile.Comment
{
    public partial class Comment : System.Web.UI.Page
    {
        public int OrderDetailID
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["odid"]);
            }
        }

        public string OrderId { get {
            return CurrentDetail.orderId;
        } }

        public int PID {
            get {
                return CurrentDetail.ProductId.Value;
            }
        }

        public view_orderdetail CurrentDetail { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "发表评价";
            Title = "发表评价";
            OrderBLL obll = new OrderBLL();
            int userid = CurrentUser.CurrentUid;
            CurrentDetail = obll.GetOrderDetailById(OrderDetailID);
        }
    }
}