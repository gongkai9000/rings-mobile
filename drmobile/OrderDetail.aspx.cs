using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;
using DRM.BLL.Order;
using DRM.Common;
using drmobile.master;
using DRM.BLL;

namespace drmobile
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        #region 属性
        /// <summary>
        /// 当前订单
        /// </summary>
        private T_Order _order;
        public T_Order Order
        {
            get { return _order; }
            set
            {
                _order = value;
                //设置订单时，设置订单状态
                OStatus = OrderStatus.GetStatusByString(_order.status);
            }
        }
        /// <summary>
        /// 当前订单号
        /// </summary>
        private string _orderId = string.Empty;
        public string OrderID
        {
            get
            {
                return _orderId;
            }
            set {
            _orderId = value;
            this.ucOrder.OrderID = value;
        } }

        /// <summary>
        /// 当前订单状态
        /// </summary>
        private OrderStatus.Status _OStatus;
        public OrderStatus.Status OStatus
        {
            get {
                return _OStatus;
            }
            set
            {
                OrderStatusChangedEvent(Order, value);
                _OStatus = value;
            }
        }

        public OrderBtn OpButton { get; set; }
        #endregion

        #region 订单状态更改事件
        /// <summary>
        /// 状态更改时委托
        /// </summary>
        /// <param name="page"></param>
        /// <param name="order"></param>
        /// <param name="detail"></param>
        public delegate void OrderStatusChangedDelegate(T_Order order, OrderStatus.Status newStatus);

        public event OrderStatusChangedDelegate OrderStatusChangedEvent;
        #endregion

        public List<int> darryIdList = new List<int>();
        bool isDarry = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.OrderStatusChangedEvent += new OrderStatusChangedDelegate(OrderDetail_OrderStatusChangedEvent);

                OpButton = new OrderBtn();

                OrderID = Request.QueryString["orderid"];
                OrderBLL orderBll = new OrderBLL();
                Order = orderBll.GetOrderByOrderId(OrderID);

                ucOrder.OrderList = orderBll.GetOrderList(OrderID);

                (Master as nSite).CurrentHeader = "订单详情";
                this.Title = "订单详情";

                ProTypeBll ptbll = new ProTypeBll();
                darryIdList = ptbll.GetChidlTypeList(WebConfig.DarryRing).Select(t => t.id).ToList();

                foreach (view_orderdetail od in ucOrder.OrderList)
                {
                    if (darryIdList.Contains(od.productTypeId.Value))
                    {
                        isDarry = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        #region 状态更改事件
        protected void OrderDetail_OrderStatusChangedEvent(T_Order order, OrderStatus.Status status)
        {
            //OrderBLL orderBll = new OrderBLL();
            //OpButton = orderBll.ChangeBtnView(status, order.orderid);
        }
        #endregion

        public string getBtnHTML(T_Order m)
        {
            OrderBLL obll = new OrderBLL();

            List<OrderBtn> btnList = obll.ChangeBtnView((OrderStatus.Status)Enum.ToObject(typeof(OrderStatus.Status), m.status), m.orderid, isDarry);

            string html = string.Empty;
            int count = 1;
            foreach (OrderBtn btn in btnList)
            {
                string c = "";
                if (count % 2 == 0)
                {
                    c = "fr";
                }
                else
                {
                    c = "fl";
                }
                html += string.Format("<a href=\"{0}\" class=\"{2}\">{1}</a>", btn.Url, btn.Text, c);
                count++;
            }
            return html;
        }

        public string getDeliverytime(T_Order o)
        {
            if (o.status == OrderStatus.GetStateByValue(OrderStatus.Status.已发货) || o.status == OrderStatus.GetStateByValue(OrderStatus.Status.已发货等待买家确认) || o.status == OrderStatus.GetStateByValue(OrderStatus.Status.已付款待发货) || o.status == OrderStatus.GetStateByValue(OrderStatus.Status.已付款制作中) || o.status == OrderStatus.GetStateByValue(OrderStatus.Status.已完成))
            {
                //如果后台没有填写预计发货时间，在创建订单15天之后
                if (string.IsNullOrEmpty(o.deliverytime))
                {
                    //预计发货时间是N个工作日之后
                    int days = 15;
                    DateTime lasttime;
                    List<view_orderdetail> odList = ucOrder.OrderList;
                    
                    if (is20Day(odList))
                    {
                        days = 20;
                    }
                    //订单更新时间如果为空的话，就采用订单添加时间；
                    //更新于2014-12-06 邵继星
                    if (!o.latetime.HasValue)
                    {
                        lasttime = o.addtime.Value;
                    }
                    else
                    {
                        lasttime = o.latetime.Value;
                    }
                    var dt = WorkDayBLL.getWorkyDayAfter(lasttime, days);
                    o.deliverytime = dt.HasValue ? dt.Value.ToShortDateString() : "";
                }
            }

            return o.deliverytime;
        }

        public static bool is20Day(List<view_orderdetail> odList)
        {
            foreach (view_orderdetail od in odList)
            {
                if (CommonFun.Is20Day(od.productTypeId.Value, od.ProductId.Value))
                {
                    return true;
                }
            }
            return false;
        }

    }
    
}