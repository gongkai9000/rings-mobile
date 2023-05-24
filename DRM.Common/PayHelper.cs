using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.BLL;
using System.Configuration;
using DRM.BLL.Order;
using System.IO;

namespace DRM.Common
{
    /// <summary>
    /// 功能：支付后，更新订单信息，订单日志
    /// 日期：2014-11-25
    /// 说明：以下代码为支付操作后需要对数据进行的统一操作；
    /// Programmer: 邵继星
    /// </summary>
   public  class PayHelper
    {

       public string CallBackPay(string trade_no, string order_no, string trade_status, string pay_type, string str_trade_status)
       {
           OrderBLL orderBll = new OrderBLL();
           T_Order order = orderBll.GetOrderByOrderId(order_no);
           string result = "";
           if (order != null)
           {
               string paytype = order.paytype;
               DateTime latetime = DateTime.Now;//更新时间，修改于2013-09-24 邵继星
               int UserId = Convert.ToInt32(order.userid.ToString());
               string LogUserName = "未注册用户";
               if (UserId > 0)
               {

                   LogUserName = MemberBLL.GetMemberById(UserId).email;
                   if (LogUserName == null)
                   {
                       LogUserName = "被删除会员";
                   }
               }
               if (trade_status == str_trade_status && order.status == OrderStatus.GetStateByValue(OrderStatus.Status.未处理))
               {
                   bool f = orderBll.UpdateOrder(order_no, trade_no, pay_type, OrderStatus.GetStateByValue(OrderStatus.Status.已付款待发货), latetime);
                   if (f)
                   {
                       orderBll.UpdateSellCount(order_no);
                       DarryHomeBLL dhbll = new DarryHomeBLL();
                       dhbll.UpdateHomeIsBit(order_no, UserId);
                       OrderStatus.WriteLog(order_no, UserId, LogUserName, OrderStatus.UserType.前台账号, pay_type);
                       MemberBLL.GetHtmlFromUrl(order.SMSphone, ConfigurationManager.AppSettings["OrdersPayment"]);

                   }
                   result = "success";
               }

               else
               {
                   result = trade_status;
               }
           }
           else
           {
               result = "该订单不存在！";
           }
           return result;
       }



       public string NotifyPay(string trade_no, string order_no, string trade_status, string pay_type)
       {
           OrderBLL orderBll = new OrderBLL();
           T_Order order = orderBll.GetOrderByOrderId(order_no);
           string result = "";
           if (order != null)
           {
               string paytype = order.paytype;
               DateTime latetime = DateTime.Now;//更新时间，修改于2013-09-24 邵继星
               int UserId = Convert.ToInt32(order.userid.ToString());
               string LogUserName = "未注册用户";
               if (UserId > 0)
               {

                   LogUserName = MemberBLL.GetMemberById(UserId).email;
                   if (LogUserName == null)
                   {
                       LogUserName = "被删除会员";
                   }
               }
               if (order.status == OrderStatus.GetStateByValue(OrderStatus.Status.未处理))
               {
                   bool f = orderBll.UpdateOrder(order_no, trade_no, pay_type, OrderStatus.GetStateByValue(OrderStatus.Status.已付款待发货), latetime);
                   if (f)
                   {
                       orderBll.UpdateSellCount(order_no);
                       DarryHomeBLL dhbll = new DarryHomeBLL();
                       dhbll.UpdateHomeIsBit(order_no, UserId);
                       OrderStatus.WriteLog(order_no, UserId, LogUserName, OrderStatus.UserType.前台账号, pay_type);
                       MemberBLL.GetHtmlFromUrl(order.SMSphone, ConfigurationManager.AppSettings["OrdersPayment"]);

                   }
                   result = "success";
               }

               else
               {
                   result = trade_status;
               }
           }
           else
           {
               result = "该订单不存在！";
           }
           return result;
       }

       //public string ChinaBackPay()
       //{ 
       
       //}

       public string ChinaNotifyPay(string payid, string trade_no)
       {
           try
           {
              // OrderStatus.WriteLog("20150124360281", 15487, "接收数据_订单支付成功", OrderStatus.UserType.前台账号, OrderStatus.Pay_Type.银联在线手机支付.ToString());

               OrderBLL orderBll = new OrderBLL();
               T_Order order = orderBll.GetOrderByPayId(payid);
               string result = "";
               if (order != null)
               {
                 //  OrderStatus.WriteLog(order.orderid, 15487, "接收数据_订单支付成功", OrderStatus.UserType.前台账号, OrderStatus.Pay_Type.银联在线手机支付.ToString() + order.orderid + order.payid);
                   string orderid = order.orderid;
                   DateTime latetime = DateTime.Now;//更新时间，修改于2013-09-24 邵继星
                   int UserId = Convert.ToInt32(order.userid.ToString());
                   if (order.status == OrderStatus.GetStateByValue(OrderStatus.Status.未处理))
                   {
                       bool f = orderBll.UpdateOrder(orderid, payid, OrderStatus.Pay_Type.银联在线手机支付.ToString(), OrderStatus.GetStateByValue(OrderStatus.Status.已付款待发货), latetime);
                       int i = 0;
                       bool r = false;
                       if (f)
                       {
                           i = orderBll.UpdateSellCount(orderid);
                           DarryHomeBLL dhbll = new DarryHomeBLL();
                           r = dhbll.UpdateHomeIsBit(orderid, UserId);
                           OrderStatus.WriteLog(orderid, UserId, order.email, OrderStatus.UserType.前台账号, OrderStatus.Pay_Type.银联在线手机支付.ToString());
                           MemberBLL.GetHtmlFromUrl(order.SMSphone, ConfigurationManager.AppSettings["OrdersPayment"]);

                       }
                     
                       result = "success";
                   }

                   else
                   {
                       result = "已处理订单";
                   }
               }
               else
               {
                   result = "该订单不存在！";
               }
               return result;
           }
           catch(Exception ex)
           {
               //日志
               using (StreamWriter fs = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("/chinapay/") + "/PayUniWapNotifyLog.txt", true))
               {
                   fs.Write(DateTime.Now.ToString() + "\r\n" +
                       "\r\n" + ex.Source + "\r\n" + ex.Message);
                   fs.Close();
               }
               return "";
           }
       }
   

       //public string GetPayId(string orderid)
       //{
       //    OrderBLL bll = new OrderBLL();
       //    string _payId = DateTime.Now.ToString("yyyymmddhhmmss");
       //    _payId = IsOnlyPayId(_payId);

       //    return _payId;
       //}

       public string GetPayId(string payId)
       {
           OrderBLL bll = new OrderBLL();
        //   int[] num = {0,1,2,3,4,5,6,7,8,9 };
           Random r = new Random();
           string num = r.Next(10000000, 99999999).ToString();
           if (bll.GetOrderByPayId(payId)==null)
           {
               return payId;
           }

           else
           {
               payId =num+ DateTime.Now.ToString("hhmmss");
               return GetPayId(payId);
           }
       }

    }
}
