using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL.Order;
using drmobile.master;
using DRM.Entity;
using DRM.BLL;
using DRM.Common;

namespace drmobile
{
    public partial class SubmitOrder : System.Web.UI.Page
    {
        //public string OrderID { get; set; }
        public decimal TotalPrice { get; set; }
        public T_SpAddress CurrentAddress { get; set; }
        public List<view_cart> CurrentCart { get; set; }

        public string AddressCallbackUrl
        {
            get
            {
                return Server.UrlEncode("SubmitOrder.aspx?addressid=");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CartBLL cbll = new CartBLL();
            CurrentCart = cbll.GetViewCartByMemberId(CurrentUser.CurrentUid);

            rpProduct.DataSource = CurrentCart;
            rpProduct.DataBind();
            TotalPrice = cbll.GetTotal(CurrentCart);
            
            //if(string.IsNullOrEmpty(Request.QueryString["orderid"]))
            //{
            //    OrderID = new OrderBLL().NewOrderId();
            //}
            //else
            //{
            //    OrderID = Request.QueryString["orderid"];
            //}

            if (string.IsNullOrEmpty(Request.QueryString["addressid"]))
            {
                var defaultAddress = SpAddressBLL.GetDefaultAddress(CurrentUser.CurrentUid);
                var newestAddress = defaultAddress == null ? SpAddressBLL.GetAlladderssByUid(CurrentUser.CurrentUid).OrderByDescending(t => t.SpAddressId).FirstOrDefault() : defaultAddress;
                CurrentAddress = newestAddress == null ? new T_SpAddress() : newestAddress;
                if (newestAddress == null)
                {
                    addressDiv.Visible = false;
                }
            }
            else
            {
                CurrentAddress = SpAddressBLL.GetAddressById(Convert.ToInt32(Request.QueryString["addressid"]));
                if (CurrentAddress == null)
                {
                    Response.Redirect("SubmitOrder.aspx");
                }
            }

            ucWorkflow.CartList = CurrentCart;
            ucWorkflow.CurrentProcess = muc.Process.Order;
            (Master as nSite).CurrentHeader = "填写订单";
            Title = "填写订单";
        }

       
    }
}