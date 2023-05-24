using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL.Order;
using DRM.Entity;
using DRM.Common;
using drmobile.master;
using DRM.BLL;

namespace drmobile
{
    public partial class OrderList : System.Web.UI.Page
    {
        public List<int> darryIdList = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Title = "我的订单";
                (Master as nSite).CurrentHeader = "我的订单";
                OrderBLL orderBll = new OrderBLL();
                //暂时不使用分页功能
                List<view_mOrder> tList = orderBll.GetOrder(CurrentUser.CurrentUid);
                if (tList.Count == 0)
                {
                    Server.Transfer("EmptyOrder.aspx");
                }
                orderRepeater.DataSource = tList;
                orderRepeater.DataBind();

            }
            catch (Exception ex)
            {
                //Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "error", "alert('" + ex.Message + "');", true);
            }
        }

        protected void Page_Init(object sender, EventArgs args)
        {
            ProTypeBll ptbll = new ProTypeBll();
            darryIdList = ptbll.GetChidlTypeList(WebConfig.DarryRing).Select(t => t.id).ToList();
        }

        public string getOrderDetailCount(view_mOrder m)
        {
            if (m.odcount > 1)
            {
                return string.Format("<p>共计{0}个商品</p>", m.odcount);
            }
            return string.Empty;
        }

        public string getOrderStatus(int status)
        {
            return OrderStatus.GetOrderStatus(status);
        }

        List<KeyValuePair<string, List<OrderBtn>>> kvList = new List<KeyValuePair<string, List<OrderBtn>>>();

        public string getBtnHTML(view_mOrder m)
        {
            List<OrderBtn> btnList = kvList.Single(t => t.Key == m.orderid).Value;
            string html = string.Empty;

            int count =1;
            foreach (OrderBtn btn in btnList)
            {
                string c = "";
                if(count %2 == 0)
                {
                    c = "fr";
                }
                else
                {
                    c = "fl";
                }

                if (btnList.Count == 1)
                {
                    html += string.Format("<a href=\"{0}\">{1}</a>", btn.Url, btn.Text);
                }
                else
                {
                    html += string.Format("<a href=\"{0}\" class=\"{2}\">{1}</a>", btn.Url, btn.Text, c);
                }
                count ++;
            }
            return html;
        }

        public string getBtnCountClass(view_mOrder m)
        {
            OrderBLL obll = new OrderBLL();

            List<view_orderdetail> odList = obll.GetOrderList(m.orderid);

            bool isDarry = false;

            foreach (view_orderdetail od in odList)
            {
                if (darryIdList.Contains(od.productTypeId.Value))
                {
                    isDarry = true;
                    break;
                }
            }

            List<OrderBtn> btnList = obll.ChangeBtnView((OrderStatus.Status)Enum.ToObject(typeof(OrderStatus.Status), m.status), m.orderid, isDarry);
            kvList.Add(new KeyValuePair<string, List<OrderBtn>>(m.orderid, btnList));

            if (btnList.Count == 1)
            {
                return " detail_onebut";
            }
            return "";
        }
    }
}