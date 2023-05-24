using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL.Order;
using DRM.Entity;
using drmobile.master;

namespace drmobile
{
    public partial class OrderCreateSuccess : System.Web.UI.Page
    {
        public string OrderID { get; set; }
        public T_Order Order { get; set; }
        public List<T_OrderDetail> DetailList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            OrderID = this.Request.QueryString["orderid"];
            if (!string.IsNullOrEmpty(OrderID))
            {
                OrderBLL orderBll = new OrderBLL();
                Order = orderBll.GetOrderByOrderId(OrderID);
                DetailList = orderBll.GetOrderDetailList(OrderID);
            }

            (Master as nSite).CurrentHeader = "订单完成";
            Title = "订单完成";
        }
    }
}
