using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.DAL;


namespace DRM.BLL.Order
{
    public class OrderStatus
    {

        public enum Pay_Type
        {
            支付宝_担保交易,
            支付宝_即时到帐,
            支付宝手机支付_即时到帐,
            银联在线手机支付,
            微信手机支付_即时到帐,
        }

        public enum Status
        {
            未处理,
            已付款待发货,
            已发货,
            已发货等待买家确认,
            已完成,
            已退款,
            已退货,
            已作废,
            已付款制作中,
            支付失败,
        }
        public enum UserType
        {
            前台账号,
            后台账号,
        }

        
        ///// <summary>
        ///// 根据字符串返回枚举
        ///// </summary>
        ///// <returns></returns>
        //public static Status GetStatusByString(string s)
        //{
        //    List<KeyValuePair<string,Status>> list = new List<KeyValuePair<string,Status>>();
        //    list.Add(new KeyValuePair<string,Status>("未处理",Status.未处理));
        //    list.Add(new KeyValuePair<string,Status>("已付款待发货",Status.已付款待发货));
        //    list.Add(new KeyValuePair<string,Status>("已发货",Status.已发货));
        //    list.Add(new KeyValuePair<string,Status>("已发货等待买家确认",Status.已发货等待买家确认));
        //    list.Add(new KeyValuePair<string,Status>("已完成",Status.已完成));
        //    list.Add(new KeyValuePair<string,Status>("已退款",Status.已退款));
        //    list.Add(new KeyValuePair<string,Status>("已退货",Status.已退货));
        //    list.Add(new KeyValuePair<string,Status>("已作废",Status.已作废));
        //    list.Add(new KeyValuePair<string,Status>("已付款制作中",Status.已付款制作中));

        //    return list.Single(t => t.Key == s).Value;
        //}


        public static Status GetStatusByString(int s)
        {
            List<KeyValuePair<int, Status>> list = new List<KeyValuePair<int, Status>>();
            list.Add(new KeyValuePair<int, Status>(0, Status.未处理));
            list.Add(new KeyValuePair<int, Status>(1, Status.已付款待发货));
            list.Add(new KeyValuePair<int, Status>(2, Status.已发货));
            list.Add(new KeyValuePair<int, Status>(3, Status.已发货等待买家确认));
            list.Add(new KeyValuePair<int, Status>(4, Status.已完成));
            list.Add(new KeyValuePair<int, Status>(5, Status.已退款));
            list.Add(new KeyValuePair<int, Status>(6, Status.已退货));
            list.Add(new KeyValuePair<int, Status>(7, Status.已作废));
            list.Add(new KeyValuePair<int, Status>(8, Status.已付款制作中));
            list.Add(new KeyValuePair<int, Status>(10, Status.支付失败));
            return list.Single(t => t.Key == s).Value;
        }
        /// <summary>
        /// 根据状态值去获取状态码
        /// </summary>
        /// <param name="status">状态值</param>
        /// <returns></returns>
        public static int GetStateByValue(Status status)
        {
            List<KeyValuePair<Status, int>> list = new List<KeyValuePair<Status, int>>();
            list.Add(new KeyValuePair<Status, int>(Status.未处理, 0));
            list.Add(new KeyValuePair<Status, int>(Status.已付款待发货, 1));
            list.Add(new KeyValuePair<Status, int>(Status.已发货, 2));
            list.Add(new KeyValuePair<Status, int>(Status.已发货等待买家确认, 3));
            list.Add(new KeyValuePair<Status, int>(Status.已完成, 4));
            list.Add(new KeyValuePair<Status, int>(Status.已退款, 5));
            list.Add(new KeyValuePair<Status, int>(Status.已退货, 6));
            list.Add(new KeyValuePair<Status, int>(Status.已作废, 7));
            list.Add(new KeyValuePair<Status, int>(Status.已付款制作中, 8));
            list.Add(new KeyValuePair<Status, int>(Status.支付失败, 10));
            return list.Single(t => t.Key == status).Value;
        }


        /// <summary>
        /// 根据订单的状态码返回相应的订单状态
        /// </summary>
        /// <param name="status">状态码</param>
        /// <returns>状态值</returns>
        public static string GetOrderStatus(int status)
        {

            switch (status)
            {
                case 0:
                    return "未处理";

                case 1:
                    return "已付款待发货";

                case 2:
                    return "已发货";

                case 3:
                    return "已发货等待买家确认";

                case 4:
                    return "已完成";

                case 5:
                    return "已退款";

                case 6:
                    return "已退货";

                case 7:
                    return "已取消";

                case 8:
                    return "已付款制作中";

                default:
                    return "支付失败";

            }
        }

        /// <summary>
        /// 写订单日志
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="op_id"></param>
        /// <param name="op_name"></param>
        /// <param name="op_type"></param>
        /// <param name="log_text"></param>
        public static void WriteLog(string orderid, Int32 op_id, string op_name, UserType op_type, string log_text)
        {
            T_Order_Log log = new T_Order_Log
            {
                orderid = orderid,
                op_id = op_id,
                op_name = op_name,
                op_type = op_type.ToString(),
                log_text = log_text,
                addtime = DateTime.Now
            };
            OrderStatusDAL.WriteLog(log);
        }
    }
}
