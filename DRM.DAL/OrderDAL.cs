using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;

namespace DRM.DAL
{
    public class OrderDAL
    {

        /// <summary>
        /// 根据会员id,查询订单列表
        /// </summary>
        /// <param name="pageSize">一页多少行</param>
        /// <param name="pageIndex">当前页下标</param>
        /// <param name="pageCount">总页数</param>
        /// <param name="orderBy">排序(字段)</param>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public List<T_Order> GetOrderByPage(int pageSize,int pageIndex,out int pageCount,string orderBy,int memberId)
        {
            List<T_Order> orderList = new List<T_Order>();
            using (var db = new DarryJewelryEntities())
            {
                var data = from _data in db.T_Order where _data.userid == memberId orderby orderBy descending select _data;
                pageCount = data.Count();
                if(pageCount > 0)
                {
                    orderList = data.Skip(pageSize * pageIndex).Take(pageSize).ToList();
                }
            }
            return orderList;
        }

        /// <summary>
        /// 根据状态和用户id获取订单
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<T_Order> GetOrderByStatus(int memberId, int status)
        {
            List<T_Order> orderList = new List<T_Order>();
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Order.Where(t => t.userid == memberId && t.status == status).ToList();
            }
        }

        /// <summary>
        /// 根据id获取获取订单
        /// </summary>
        /// <param name="id">订单的主键id</param>
        /// <returns></returns>
        public T_Order GetOrderById(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Order.SingleOrDefault(t => t.id == id);
            }
        }

        public List<view_mOrder> GetOrder(int memberid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_mOrder.Where(t => t.userid == memberid).OrderByDescending(t => t.id).ToList();
            }
        }

        public int GetOrderCountByMember(int memberid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Order.Count(t=>t.userid == memberid);
            }
        }

        /// <summary>
        /// 根据orderid获取订单
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        public T_Order GetOrderByOrderId(string orderId)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Order.SingleOrDefault(t => t.orderid == orderId);
            }
        }

        public List<view_orderdetailAfterservice> GetOAfterByMember(int memberid,int nostatus)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_orderdetailAfterservice.Where(t=>t.userid == memberid && t.status != nostatus).ToList();
            }
        }

        public List<view_orderdetailAfterservice> GetOAfterByOrderId(string orderid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_orderdetailAfterservice.Where(t => t.orderId == orderid).ToList();
            }
        }

        /// <summary>
        /// 删除订单,先删详情,再删订单.
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        public bool DeleteOrderByOrderId(string orderId)
        {
            using (var db = new DarryJewelryEntities())
            {
                if (DeleteOrderDetailByOrderId(orderId))
                {
                    db.T_Order.DeleteObject(db.T_Order.SingleOrDefault(t => t.orderid == orderId));
                }
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        /// <summary>
        /// 检查该订单状态,是否存在list中
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="statusList">状态List</param>
        /// <returns></returns>
        public bool CheckOrderStatus(string orderId, List<int> statusList)
        {
            using (var db = new DarryJewelryEntities())
            {
                T_Order order = db.T_Order.SingleOrDefault(t => t.orderid == orderId);
                return statusList.Contains(order.status);
            }
        }


        /// <summary>
        /// 根据id返回订单详情
        /// </summary>
        /// <param name="id">订单详情的主键id</param>
        /// <returns></returns>
        public T_OrderDetail GetOrderDetail(int id)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_OrderDetail.SingleOrDefault(t=>t.Id == id);
            }

        }

        /// <summary>
        /// 根据订单号删除订单详情
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns></returns>
        public bool DeleteOrderDetailByOrderId(string orderId)
        {
            using (var db = new DarryJewelryEntities())
            {
                var data = db.T_OrderDetail.Where(t => t.orderId == orderId);
                foreach (T_OrderDetail d in data)
                {
                    db.T_OrderDetail.DeleteObject(d);
                }
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool AddOrder(T_Order order)
        {
            using (var db = new DarryJewelryEntities())
            {
                db.T_Order.AddObject(order);
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        /// <summary>
        /// 添加订单详情
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool AddOrderDetail(List<T_OrderDetail> detailList)
        {
            using (var db = new DarryJewelryEntities())
            {
                foreach (T_OrderDetail d in detailList)
                {
                    db.T_OrderDetail.AddObject(d);
                }
                return db.SaveChanges() > 0 ? true : false;
            }
        }


        /// <summary>
        /// 根据订单编号，返回
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public List<view_orderdetail_product2> GetOrderDetail(string orderid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_orderdetail_product2.Where(t => t.orderId == orderid).ToList();
            }
        }
        /// <summary>
        /// 根据订单编号，返回
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public List<view_orderdetail> GetOrderList(string orderid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_orderdetail.Where(t => t.orderId == orderid).ToList();
            }
        }

        public view_orderdetail GetOrderDetailById(int odid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.view_orderdetail.Single(t=>t.Id == odid);
            }
        }

        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public bool ChangeOrderStatus(string orderid, int status)
        {
            using (var db = new DarryJewelryEntities())
            {
                T_Order o = db.T_Order.Single(t=>t.orderid == orderid);
                o.status = status;
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        public bool UpdateOrderPayId(string orderid, string payid)
        {
            using (var db = new DarryJewelryEntities())
            {
                T_Order o = db.T_Order.Single(t => t.orderid == orderid);
                o.payid = payid;
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        /// <summary>
        /// 开通专属页
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public bool OpenExclusivePage(string orderid)
        {
            using (var db = new DarryJewelryEntities())
            {
                T_DarryHome h = db.T_DarryHome.SingleOrDefault(t => t.DarryHomeOrderId == orderid);
                if (h != null)
                {
                    h.DarryHomeIsBit = true;
                }
                return db.SaveChanges() > 0 ? true :false;
            }
        }

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
            using (var db = new DarryJewelryEntities())
            {
                T_Order o = db.T_Order.SingleOrDefault(t=>t.orderid == orderid);
                if (o != null)
                {
                    o.payid = payid;
                    o.paytype = paytype;
                    o.status = status;
                    o.latetime = latetime;
                }
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="status"></param>
        /// <param name="lasttime"></param>
        /// <returns></returns>
        public bool UpdateOrderStatus(string orderid, int status, DateTime latetime)
        {
            using (var db = new DarryJewelryEntities())
            {
                T_Order o = db.T_Order.Single(t=>t.orderid == orderid);
                o.status = status;
                o.latetime = latetime;
                return db.SaveChanges() > 0 ? true : false;
            }
        }

        /// <summary>
        /// 更新产品销量
        /// </summary>
        /// <param name="orderid"></param>
        public int UpdateSellCount(string orderid)
        {
            using (var db = new DarryJewelryEntities())
            {
                var list = db.view_orderdetail_product2.Where(t => t.orderId == orderid);
                foreach (view_orderdetail_product2 v in list)
                {
                    int sellCount = v.sellcount.Value + 1;
                    int productId = v.ProductId.Value;
                    var p = db.T_Product.Single(t=>t.ProductId == productId);
                    p.sellcount = sellCount;
                }
                return db.SaveChanges();
            }
        }

        public List<T_OrderDetail> GetOrderDetailList(string orderid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_OrderDetail.Where(t=>t.orderId == orderid).ToList();
            }
        }

        public T_Order GetOrderByPayId(string payid)
        {
            using (var db = new DarryJewelryEntities())
            {
                return db.T_Order.Where(t => t.payid == payid).FirstOrDefault();
            }
        }

    }
}
