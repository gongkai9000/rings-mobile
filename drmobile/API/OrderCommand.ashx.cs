using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL.Order;
using DRM.BLL;
using DRM.Common;
using System.Web.SessionState;
using DRM.Entity;
using System.Transactions;
using System.Web.Script.Serialization;
using System.IO;
using RSACrypto;

namespace drmobile.API
{
    /// <summary>
    /// OrderCommand 的摘要说明
    /// </summary>
    public class OrderCommand : IHttpHandler, IRequiresSessionState
    {
        public OrderBLL orderBll = new OrderBLL();
        public RSASecurity rsa = new RSASecurity();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            string orderId = context.Request.QueryString["orderid"];
            string ajax = context.Request.QueryString["ajax"];
            ResultMsg msg;
            switch (action)
            {
                //确认收货
                case "changeStatusOver":
                    int memberId = CurrentUser.CurrentUid;
                    msg = orderBll.ChangeOrderOver(orderId, memberId);

                    //将更新后的信息返回给客户端
                    //T_Order order = orderBll.GetOrderById(memberId);
                    //OrderBtn btn = orderBll.ChangeBtnView(OrderStatus.GetStatusByString(order.status), orderId);
                    //StatusInfo sInfo = new StatusInfo(btn);
                    //sInfo.Status = order.status;
                    //JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    //CommonFun.ResponseJSON(jsSerializer.Serialize(sInfo), true);
                    //context.Response.Redirect("~/OrderList.aspx");
                    break;
                //删除订单
                case "deleteOrder":
                    msg = orderBll.DeleteOrderByOrderId(orderId, CurrentUser.CurrentUid);
                    //context.Response.Redirect("~/OrderList.aspx");
                    break;
                //开通专属页
                case "OpenExclusivePage":
                    msg = orderBll.OpenExclusivePage(orderId, CurrentUser.CurrentUid);
                    //context.Response.Redirect("~/OrderList.aspx");
                    try
                    {
                        Uri uri = new Uri("http://www.ctloves.com/Exclusive/IProduct.aspx?userid=" + CurrentUser.CurrentUid.ToString() + "&type=update");
                        System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
                        request.Method = "get";
                        request.ContentLength = 0;
                        request.Timeout = 500;
                        request.ContentType = "text/html";
                        Stream stream = request.GetResponse().GetResponseStream();
                        StreamReader readStream = new StreamReader(stream, System.Text.Encoding.UTF8);
                        string retext = readStream.ReadToEnd().ToString();
                        readStream.Close();
                    }
                    catch (Exception ex)
                    {
                        //result.Msg = "专属空间数据同步失败。";
                    }
                    break;
                //创建订单和相关信息，入口：购物车结算
                case "CreateOrder":
                    CartBLL cartbll = new CartBLL();
                    T_Cart darry = cartbll.getDarryInCart(cartbll.GetCartByMemberId(CurrentUser.CurrentUid));
                    string darryHomeMemberName = string.Empty;
                    string darryHomeIDCard = string.Empty;
                    if (darry != null)
                    {
                        darryHomeMemberName = darry.sirName;
                        darryHomeIDCard = darry.sirCode;
                    }
                    if (!string.IsNullOrEmpty(darryHomeIDCard))
                    {
                        darryHomeIDCard = rsa.Encrypt(darryHomeIDCard, rsa.publickey);
                    }

                    string darryHomeMsName = CookieHelper.GetCookie("ladyName");
                    string txtBirthday = CookieHelper.GetCookie("sheBirthday");
                    string txtMemorial1 = CookieHelper.GetCookie("sheDate1");
                    string txtMemorial2 = CookieHelper.GetCookie("sheDate2");
                    string txtOrderNote = context.Request.Form["txtOrderNote"];
                    string paytype = context.Request.Form["paytype"];
                    string returnOrderId = string.Empty;
                    msg = CreateOrder(darryHomeMemberName, darryHomeIDCard, darryHomeMsName, txtBirthday, txtMemorial1, txtMemorial2, txtOrderNote, context, out returnOrderId);
                    if (msg.Result)
                    {
                        string url = choosePayType(paytype, returnOrderId);
                        CommonFun.ResponseJSON("{\"msg\":\"" + url + "\",\"result\":\"OK\",\"orderid\":\"" + returnOrderId + "\"}", true);
                    }
                    else
                    {
                        CommonFun.ResponseJSON("{\"msg\":\"" + msg.Msg + "\",\"result\":\"fail\"}", true);
                    }
                    break;
                //作废订单
                case "CancelOrder":
                    OrderBLL obll = new OrderBLL();
                    obll.CancelOrder(context.Request.QueryString["orderid"]);
                    break;
                case "choosePayType":
                    string pt = context.Request.QueryString["paytype"];
                    string od = context.Request.QueryString["orderid"];
                    CommonFun.ResponseData(choosePayType(pt, od), true);
                    break;
            }
        }

        private string choosePayType(string paytype,string returnOrderId)
        {
            string url = string.Empty;
            if (paytype == "zhifubao")
            {
                url = "/pay/pay_default.aspx?orderid=" + returnOrderId + "&type=1";
            }
            else if (paytype == "weixin")
            {
                url = "/pay/pay_tenpay.aspx?orderid=" + returnOrderId + "&type=2"; ;
            }
            else if (paytype == "yinlian")
            {
                url = "/chinapay/default.aspx?orderid=" + returnOrderId;
            }
            return url;
        }

        public ResultMsg CreateOrder(string darryHomeMemberName, string darryHomeIDCard, string darryHomeMsName, string txtBirthday, string txtMemorial1, string txtMemorial2, string txtOrderNote, HttpContext context, out string returnOrderId )
        {
            ResultMsg result = new ResultMsg();
            result.Result = false;
             CartBLL cBll = new CartBLL();
             returnOrderId = string.Empty;
                List<T_Cart> cList = cBll.GetCartByMemberId(CurrentUser.CurrentUid);
                if (cList.Count == 0)
                {
                    result.Msg = "购物车为空无法进行提交";
                    return result;
                }
                using (TransactionScope ts = new TransactionScope())
                {
                    returnOrderId = AddOrderByCart(cList, context, darryHomeMemberName, darryHomeIDCard, darryHomeMsName, txtOrderNote);
                    if (cBll.IsHaveDarry(cList))
                    {
                        AddDarryHome(returnOrderId, cBll.getDarryImg(cList), darryHomeMemberName, darryHomeIDCard, darryHomeMsName);
                        AddSMSRemind(darryHomeMemberName, darryHomeMsName, txtBirthday, txtMemorial1, txtMemorial2);
                    }

                    cBll.DeleteCartByMemberId(CurrentUser.CurrentUid);

                    //CookieHelper.ClearCookie("sirName");
                    //CookieHelper.ClearCookie("sirCode");

                    ts.Complete();

                }
                try
                {
                    Uri uri = new Uri("http://www.ctloves.com/Exclusive/IProduct.aspx?userid=" + CurrentUser.CurrentUid.ToString() + "&type=update");
                    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
                    request.Method = "get";
                    request.ContentLength = 0;
                    request.Timeout = 500;
                    request.ContentType = "text/html";
                    Stream stream = request.GetResponse().GetResponseStream();
                    StreamReader readStream = new StreamReader(stream, System.Text.Encoding.UTF8);
                    string retext = readStream.ReadToEnd().ToString();
                    readStream.Close();
                }
                catch (Exception ex)
                {
                    result.Msg = "专属空间数据同步失败。";
                }

                ////粉钻信息
                //if (Request.QueryString["type"] == "fenzuan")
                //{
                //    Response.Clear();
                //    Response.Write(orderid);
                //    Response.End();
                //}

                result.Result = true;
                return result;
        }


        public string AddOrderByCart(List<T_Cart> cartList, HttpContext context, string darryHomeMemberName, string darryHomeIDCard, string darryHomeMsName, string ordernote)
        {
            T_Order order = new T_Order();
            
            int addressid = Convert.ToInt32(context.Request.QueryString["addressId"]);
            T_SpAddress address = SpAddressBLL.GetAddressById(addressid);
            T_Member m = MemberBLL.GetMemberById(CurrentUser.CurrentUid);

            CartBLL cBll = new CartBLL();

            order.realname = address.SpAddressName;
            order.gender = m.gender;
            order.address = address.SpAddressCity + address.SpAddressStreet;
            order.GName = darryHomeMemberName;
            //if (darryHomeIDCard.Length < 20)
            //{
            //    darryHomeIDCard = rsa.Encrypt(darryHomeIDCard, rsa.publickey);
            //}
            order.GCard = darryHomeIDCard;
            order.GMobile = "";
            order.GirlfriendName = darryHomeMsName;
            order.postcode = address.SpAddressCode;
            order.mobile = address.SpAddressMobile;
            order.SMSphone = address.SpAddressMobile;
            order.telephone = address.SpAddressPhone;
            order.ordertotal = cBll.GetTotal(m.Id);
            order.orderid = NewOrderId();
            order.status = OrderStatus.GetStateByValue(OrderStatus.Status.未处理);
            order.userid = m.Id;
            order.email = m.email;
            order.ordernote = ordernote;
            order.addtime = DateTime.Now;
            order.postip = CommonFun.GetIp();
            order.qq = m.qq;
            order.latetime = DateTime.Now;
            order.isNewWeb = true;
            order.appid = 1;

            List<T_OrderDetail> oDetailList = cBll.AddCartToOrderDetail(cartList, order.orderid);

            ////现货数量控制
            //List<int> spotDiamondIDList = new List<int>();
            //DiamondBLL dBll = new DiamondBLL();
            //foreach (T_OrderDetail od in oDetailList)
            //{
            //    if (od.diamondId.HasValue)
            //    {
            //        T_Diamonds diamond = dBll.getDiamondById(od.diamondId.Value);
            //        if (diamond.protype == ncs.WebConfig.SpotLZID)
            //        {
            //            spotDiamondIDList.Add(diamond.Id);
            //        }
            //    }
            //}

            using (TransactionScope ts = new TransactionScope())
            {
                cBll.AddOrder(order, m);
                cBll.AddOrderDetail(oDetailList);
                //dBll.updateDiamondCount(spotDiamondIDList);
                ts.Complete();
            }


            return order.orderid;
        }

        protected void AddDarryHome(string orderid, string productImg, string darryHomeMemberName, string darryHomeIDCard, string darryHomeMsName)
        {
            T_DarryHome dHome = new T_DarryHome();
            dHome.DarryHomeMemberId = CurrentUser.CurrentUid;
            dHome.DarryHomeMemberName = darryHomeMemberName;
            dHome.DarryHomeNationality = string.Empty;
            dHome.DarryHomeIDCard = darryHomeIDCard;
            dHome.DarryHomeOrderId = orderid;
            dHome.DarryHomeIsBit = false;
            dHome.DarryHomeDate = DateTime.Now;
            dHome.DarryHomeMemberTitle = string.Empty;
            dHome.DarryHomeMsName = darryHomeMsName;
            dHome.DarryHomeContent = string.Empty;
            dHome.DarryHomeProductImg = productImg;
            Random ro = new Random();
            dHome.DarryHomeCode = "D" + ro.Next(9999999);
            string shenfenzheng = rsa.Decrypt(darryHomeIDCard, rsa.privatekey);
            dHome.DarryHomeIDCardMd5 = new MD5Encrypt().MD5Enc(shenfenzheng);
            DarryHomeBLL dHomeBll = new DarryHomeBLL();
            dHomeBll.AddDarryHome(dHome);
        }

        protected void AddSMSRemind(string darryHomeMemberName, string darryHomeMsName, string sheBirthday, string sheDate1, string sheDate2)
        {

            #region 生成SmsRemind实体列表
            List<Tb_SMSRemind> smsRemindList = new List<Tb_SMSRemind>();
            DateTime result;
            if (!string.IsNullOrEmpty(sheBirthday))
            {
                if (DateTime.TryParse(sheBirthday, out result))
                {
                    smsRemindList.Add(newSmsRemind(CurrentUser.CurrentUid, darryHomeMemberName, result, darryHomeMsName + "生日！"));
                }
            }
            if (!string.IsNullOrEmpty(sheDate1))
            {
                if (DateTime.TryParse(sheDate1, out result))
                {
                    smsRemindList.Add(newSmsRemind(CurrentUser.CurrentUid, darryHomeMemberName, result, darryHomeMsName + "纪念日1！"));
                }
            }
            if (!string.IsNullOrEmpty(sheDate2))
            {
                if (DateTime.TryParse(sheDate2, out result))
                {
                    smsRemindList.Add(newSmsRemind(CurrentUser.CurrentUid, darryHomeMemberName, result, darryHomeMsName + "纪念日2！"));
                }
            }
            #endregion

            SMSRemindBLL smsRemindBll = new SMSRemindBLL();
            smsRemindBll.AddSmsRemind(smsRemindList);

        }

        private Tb_SMSRemind newSmsRemind(int memberId, string darryHomeMemberName, DateTime datetime, string con)
        {
            DateTime PostDate;
            PostDate = datetime.Date.AddDays(-1);
            Tb_SMSRemind smsRemind = new Tb_SMSRemind
            {
                SMSReminUserId = memberId,
                SMSRemindName = darryHomeMemberName,
                SMSRemindTime = datetime,
                SMSRemindPostTime = PostDate,
                SMSRemindCon = con,
                SMSRemindDay = "1"
            };

            return smsRemind;
        }

        /// <summary>
        /// 获取新的订单号
        /// </summary>
        /// <returns></returns>
        public string NewOrderId()
        {
            return DateTime.Now.ToString("yyyyMMddffffff");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 更改状态,对页面元素的影响
    /// </summary>
    public class StatusInfo : OrderBtn
    {
        public StatusInfo(OrderBtn btn)
        {
            this.IsDisplay = btn.IsDisplay;
            this.Text = btn.Text;
            this.Url = btn.Url;
        }
        public string Status { get; set; }

    }

}