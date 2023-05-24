using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;
using DRM.BLL;
using DRM.Common;
using DRM.BLL.Order;
using drmobile.master;

namespace drmobile
{
    public partial class AfterService : System.Web.UI.Page
    {

        public int OrderDetailId
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["odid"]);
            }
        }

        public string OrderID
        {
            get {
                return CurrentOrderDetail.orderId;
            }
        }

        public T_SpAddress CurrentAddress
        {
            get;
            set;
        }

        public view_orderdetail CurrentOrderDetail { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "申请售后";
            Title = "申请售后";

            OrderBLL obll = new OrderBLL();
            CurrentOrderDetail = obll.GetOrderDetailById(OrderDetailId);
            T_Order o = obll.GetOrderByOrderId(CurrentOrderDetail.orderId);

            if(string.IsNullOrEmpty(Request.QueryString["addressid"]))
            {
                //CurrentAddress = new T_SpAddress();
                //CurrentAddress.SpAddressName = o.realname;
                //CurrentAddress.SpAddressMobile = o.mobile;
                //CurrentAddress.SpAddressStreet = o.address;
                var defaultAddress = SpAddressBLL.GetDefaultAddress(CurrentUser.CurrentUid);
                var newestAddress = defaultAddress == null ? SpAddressBLL.GetAlladderssByUid(CurrentUser.CurrentUid).OrderByDescending(t => t.SpAddressId).FirstOrDefault() : defaultAddress;
                CurrentAddress = newestAddress == null ? new T_SpAddress() : newestAddress;
            }
            else
            {
                CurrentAddress = SpAddressBLL.GetAddressById(Convert.ToInt32(Request.QueryString["addressid"]));
            }
            
        }

        public string getUrl(view_orderdetail f)
        {
            return DRM.Common.ProductUrl.getUrl(f);
        }
    }
}