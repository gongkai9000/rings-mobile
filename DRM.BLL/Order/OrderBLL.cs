using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;


namespace DRM.BLL.Order
{
    public class OrderBLL
    {
        private OrderDAL _orderDal = new OrderDAL();

        //暂时不使用分页功能
        public int PageSize { get { return int.MaxValue; } }
        //默认订单号排序
        public string OrderSort { get { return "orderid"; } }

        public const string OrderCommandPage = "/API/OrderCommand.ashx";


        /// <summary>
        /// 根据会员id,查询订单列表
        /// </summary>
        /// <param name="pageSize">一页多少行</param>
        /// <param name="pageIndex">当前页下标</param>
        /// <param name="pageCount">总页数</param>
        /// <param name="orderBy">排序(字段)</param>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public List<T_Order> GetOrderByPage(int pageIndex, out int pageCount, int memberId)
        {
            return _orderDal.GetOrderByPage(PageSize, pageIndex, out pageCount, OrderSort, memberId);
        }

        /// <summary>
        /// 根据状态和用户id获取订单
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<T_Order> GetOrderByStatus(int memberId, Order.OrderStatus.Status status)
        {
            return _orderDal.GetOrderByStatus(memberId, Order.OrderStatus.GetStateByValue(status));
        }

        public List<view_mOrder> GetOrder(int memberid)
        {
            return _orderDal.GetOrder(memberid);
        }

        public int GetOrderCountByMember(int memberid)
        {
            return _orderDal.GetOrderCountByMember(memberid);
        }



        /// <summary>
        /// 根据id获取获取订单
        /// </summary>
        /// <param name="id">订单的主键id</param>
        /// <returns></returns>
        public T_Order GetOrderById(int id)
        {
            return _orderDal.GetOrderById(id);
        }

        /// <summary>
        /// 根据orderid获取订单
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        public T_Order GetOrderByOrderId(string orderId)
        {
            return _orderDal.GetOrderByOrderId(orderId);
        }

        /// <summary>
        /// 删除订单,先删详情,再删订单.
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        public ResultMsg DeleteOrderByOrderId(string orderId,int memberId)
        {
            ResultMsg rMsg = new ResultMsg();

            //检查当前用户是否具有权限操作该订单
            rMsg = CheckMember(orderId, memberId);
            if (!rMsg.Result)
            {
                return rMsg;
            }

            List<int> list = new List<int>();
            list.Add(Order.OrderStatus.GetStateByValue(OrderStatus.Status.未处理));
            list.Add(Order.OrderStatus.GetStateByValue(OrderStatus.Status.已作废));

            //判断
            if (_orderDal.CheckOrderStatus(orderId, list))
            {
                 _orderDal.DeleteOrderByOrderId(orderId);
            }
            else
            {
                rMsg.Result = false;
                rMsg.Msg = "该订单的状态，无法进行删除。";
            }
            return rMsg;
        }


        /// <summary>
        /// 根据id返回订单详情
        /// </summary>
        /// <param name="id">订单详情的主键id</param>
        /// <returns></returns>
        public view_orderdetail GetOrderDetailById(int id)
        {
            return _orderDal.GetOrderDetailById(id);
        }

        public List<view_orderdetailAfterservice> GetOAfterByMember(int memberid)
        {
            return _orderDal.GetOAfterByMember(memberid,OrderStatus.GetStateByValue(OrderStatus.Status.已作废));
        }

        public List<view_orderdetailAfterservice> GetOAfterByOrderId(string orderid)
        {
            return _orderDal.GetOAfterByOrderId(orderid);
        }

        /// <summary>
        /// 根据订单号删除订单详情
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns></returns>
        public ResultMsg DeleteOrderDetailByOrderId(string orderId,int memberId)
        {
            ResultMsg rMsg = new ResultMsg();

            //检查当前用户是否具有权限操作该订单
            rMsg = CheckMember(orderId, memberId);
            if (!rMsg.Result)
            {
                return rMsg;
            }

            rMsg.Result = _orderDal.DeleteOrderDetailByOrderId(orderId);
            return rMsg;
        }

        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <returns></returns>
        public ResultMsg AddOrder(T_Order order,T_Member member)
        {
            ResultMsg rMsg = new ResultMsg();

            rMsg.Result = _orderDal.AddOrder(order);

            //录入订单日志
            if (rMsg.Result)
            {
                T_Order_Log log = new T_Order_Log();
                log.orderid = order.orderid;
                log.addtime = DateTime.Now;
                log.log_text = "订单创建";
                log.op_id = member.Id;
                log.op_name = member.email;
                log.op_type = OrderStatus.UserType.前台账号.ToString();

                OrderLogDAL orderLogDal = new OrderLogDAL();
                orderLogDal.AddOrderLog(log);

            }
            return rMsg;
        }

        /// <summary>
        /// 添加订单详情
        /// </summary>
        /// <param name="detailList"></param>
        /// <returns></returns>
        public bool AddOrderDetail(List<T_OrderDetail> detailList)
        {
            return _orderDal.AddOrderDetail(detailList);
        }

        /// <summary>
        /// 将购物车实体转换为订单详情实体
        /// </summary>
        /// <param name="cartlList"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<T_OrderDetail> AddCartToOrderDetail(List<T_Cart> cartlList,string orderId)
        {
            List<T_OrderDetail> result = new List<T_OrderDetail>();
            foreach (T_Cart cart in cartlList)
            {
                //有钻石项
                if (cart.DiamondId.HasValue && cart.DiamondId.Value != 0)
                {
                    T_OrderDetail diamond = new T_OrderDetail { 
                        orderId = orderId,
                        ProductId = cart.DiamondId
                    };
                    result.Add(diamond);
                }
                T_OrderDetail detail = new T_OrderDetail { 
                    orderId = orderId,
                    ProductId = cart.ProductId,
                    Title = cart.Title,
                    Price = cart.MemberPrice,
                    memberprice = Convert.ToString(cart.MemberPrice),
                    Quantity = cart.Quantity,
                    protype = cart.type,
                    handsize = Convert.ToString(cart.handsize),
                    fontstyle = cart.fontstyle,
                    Material = cart.Material
                };
                result.Add(detail);
            }
            return result;
        }

        /// <summary>
        /// 根据订单编号，返回
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public List<view_orderdetail_product2> GetOrderDetail(string orderid)
        {
            return _orderDal.GetOrderDetail(orderid);
        }




        /// <summary>
        /// 根据订单编号，返回
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public List<view_orderdetail> GetOrderList(string orderid)
        {
            return _orderDal.GetOrderList(orderid);
        }
        /// <summary>
        /// 确认到货
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public ResultMsg ChangeOrderOver(string orderid,int memberId)
        {
            ResultMsg msg = new ResultMsg();

            T_Order order = _orderDal.GetOrderByOrderId(orderid);

            //检查当前用户是否具有权限操作该订单
            msg = CheckMember(order, memberId);
            if (!msg.Result)
            {
                return msg;
            }

            if (order.status == OrderStatus.GetStateByValue(OrderStatus.Status.已发货) || order.status == OrderStatus.GetStateByValue(OrderStatus.Status.已发货等待买家确认))
            {
                if (_orderDal.ChangeOrderStatus(orderid, OrderStatus.GetStateByValue(OrderStatus.Status.已完成)))
                {
                    msg.Result = true;
                }
                else
                {
                    msg.Result = false;
                }
            }
            else
            {
                msg.Result = false;
                msg.Msg = "操作失败，该订单的当前状态无法“确认到货”。";
            }
            return msg;
        }

        /// <summary>
        /// 开通定制页
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public ResultMsg OpenExclusivePage(string orderid,int memberId)
        {
            ResultMsg msg = new ResultMsg();

            //检查当前用户是否具有权限操作该订单
            msg = CheckMember(orderid, memberId);
            if (!msg.Result)
            {
                return msg;
            }

            if (_orderDal.OpenExclusivePage(orderid))
            {
                msg.Result = true;
            }
            else
            {
                msg.Result = false;
            }
            return msg;
        }

        /// <summary>
        /// 获取新的订单号
        /// </summary>
        /// <returns></returns>
        public string NewOrderId()
        {
            return DateTime.Now.ToString("yyyyMMddffffff");
        }


        #region 检查当前用户是否有权限操作该订单
        /// <summary>
        /// 检查当前用户是否有权限操作该订单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public ResultMsg CheckMember(T_Order order,int memberId)
        {
            ResultMsg msg = new ResultMsg();
            if (order != null)
            {
                msg.Result = order.userid == memberId ? true : false;
                msg.Msg = "该订单不属于当前用户。";
            }
            else
            {
                msg.Result = false;
                msg.Msg = "订单号无效。";
            }
            return msg;
        }

        /// <summary>
        /// 检查当前用户是否有权限操作该订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public ResultMsg CheckMember(string orderId, int memberId)
        {
            T_Order order = _orderDal.GetOrderByOrderId(orderId);
            return CheckMember(order, memberId);
        }
        #endregion

        #region 页面订单状态更改时，更新操作按钮显示方式
        /// <summary>
        /// 页面订单状态更改时，更新操作按钮显示方式
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<OrderBtn> ChangeBtnView(Order.OrderStatus.Status status,string orderid,bool isDarry)
        {
            List<OrderBtn> btnList = new List<OrderBtn>();
            if (status == OrderStatus.Status.未处理)
            {
                OrderBtn btn1 = new OrderBtn();
                btn1.Text = "立即支付";
                btn1.Url = "/paylist.aspx?orderid=" + orderid;

                OrderBtn btn2 = new OrderBtn();
                btn2.Text = "取消订单";
                btn2.Url = "javascript:CancelOrder(" + orderid + ")";

                btnList.Add(btn1);
                btnList.Add(btn2);
            }
            else if (status == OrderStatus.Status.已付款待发货 || status == OrderStatus.Status.已付款制作中)
            {
                //OrderBtn btn1 = new OrderBtn();
                //btn1.Text = "发起售后";
                //btn1.Url = "MyAfterService.aspx?OrderId=" + orderid;

                //btnList.Add(btn1);
            }
            else if (status == OrderStatus.Status.已发货 || status == OrderStatus.Status.已发货等待买家确认)
            {
                //OrderBtn btn1 = new OrderBtn();
                //btn1.Text = "发起售后";
                //btn1.Url = "MyAfterService.aspx?OrderId=" + orderid;

                OrderBtn btn2 = new OrderBtn();
                btn2.Text = "确认收货";
                btn2.Url = "javascript:changeStatusOver(" + orderid + ")";

                //btnList.Add(btn1);
                btnList.Add(btn2);
            }
            else if (status == OrderStatus.Status.已完成)
            {
                if (isDarry)
                {
                    OrderBtn btn1 = new OrderBtn();
                    btn1.Text = "开通专属页";
                    btn1.Url = "javascript:OpenExclusivePage(" + orderid + ")";
                    btnList.Add(btn1);
                }

                OrderBtn btn2 = new OrderBtn();
                btn2.Text = "评价";
                btn2.Url = "/Comment/MyComment.aspx?orderid=" + orderid;
                btnList.Add(btn2);
            }
            else if (status == OrderStatus.Status.已退款 || status == OrderStatus.Status.已退货)
            {

            }
            else if (status == OrderStatus.Status.已作废)
            {
                //opButton.IsDisplay = true;
                //opButton.Text = "取消订单";
                //opButton.Url = OrderCommandPage + "?action=deleteOrder&orderid=" + orderid;
            }
            return btnList;
        }
        #endregion


                /// <summary>
        /// 更改订单信息
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="payid"></param>
        /// <param name="paytype"></param>
        /// <param name="status"></param>
        /// <param name="latetime"></param>
        /// <returns></returns>
        public bool UpdateOrder(string orderid, string payid, string paytype, int status, DateTime latetime)
        {
            return _orderDal.UpdateOrder(orderid, payid, paytype, status, latetime);
        }

        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="status"></param>
        /// <param name="latetime"></param>
        /// <returns></returns>
        public bool UpdateOrderStatus(string orderid, int status, DateTime latetime)
        {
            return _orderDal.UpdateOrderStatus(orderid, status, latetime);
        }

        
        /// <summary>
        /// 更新产品销量
        /// </summary>
        /// <param name="orderid"></param>
        public int UpdateSellCount(string orderid)
        {
            return _orderDal.UpdateSellCount(orderid);
        }

        /// <summary>
        /// 作废订单
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public bool CancelOrder(string orderid)
        {
            _orderDal.ChangeOrderStatus(orderid, OrderStatus.GetStateByValue(OrderStatus.Status.已作废));
            DarryHomeDAL dhDal = new DarryHomeDAL();
            return dhDal.DeleteDarryHome(orderid);
        }

        public List<T_OrderDetail> GetOrderDetailList(string orderid)
        {
            return _orderDal.GetOrderDetailList(orderid);
        }
        public T_Order GetOrderByPayId(string payid)
        {
            return _orderDal.GetOrderByPayId(payid);
        }
        public bool UpdateOrderPayId(string orderid, string payid)
        {
            return _orderDal.UpdateOrderPayId(orderid,payid);
        }
    }

    #region 操作按钮显示类
    /// <summary>
    /// 操作按钮显示类
    /// </summary>
    public class OrderBtn
    {
        private bool _isDisplay = true;
        public bool IsDisplay
        {
            get { return _isDisplay; }
            set
            {
                _isDisplay = value;
                if (value)
                {
                    Display = string.Empty;
                }
                else
                {
                    Display = "none";
                }
            }
        }
        public string Url { get; set; }
        public string Text { get; set; }
        public string Display { get; set; }
        public string OnClick { get; set; }
    }
    #endregion
}
