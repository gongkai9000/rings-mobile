using System.Linq;
using System.Net;
using System;
using System.Text;
using System.Web;
using System.Xml;
using DRM.Common;
using DRM.BLL;
using System.IO;
using DRM.BLL.Order;
using DRM.Entity;

namespace drmobile.chinapay
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderid = Request.QueryString["orderid"];
            OrderBLL orderBll = new OrderBLL();
            T_Order order = orderBll.GetOrderByOrderId(orderid);
            if (order != null)
            {

                string status = order.status.ToString();
                if (status == OrderStatus.GetStateByValue(OrderStatus.Status.未处理).ToString())
                {
                    try
                    {
                        PayHelper phelper = new PayHelper();
                        Random r = new Random();
                        string num = r.Next(10000000, 99999999).ToString();
                        string _payid = num + DateTime.Now.ToString("hhmmss");

                        _payid = phelper.GetPayId(_payid);
                        if (orderBll.UpdateOrderPayId(order.orderid, _payid))
                        {
                            order = orderBll.GetOrderByOrderId(orderid);
                            OrderStatus.WriteLog(orderid, (int)order.userid, order.email.ToString(), OrderStatus.UserType.前台账号, "手机银在线支付_成功生成支付单号_" + order.payid);
                            GetPayUrl(order);
                        }


                    }
                    catch (Exception ex)
                    {
                        Response.Clear();
                        Response.Write("发生未处理异常!" + ex.Message);

                    }
                }

            }
        }

        private bool _isOk = false;
        /// <summary>
        /// 执行是否成功
        /// </summary>
        private bool IsOK
        {
            get { return _isOk; }
        }
        private string _errorStr = "";
        /// <summary>
        /// 执行出错时的错误信息
        /// </summary>
        private string ErrorStr
        {
            get { return _errorStr; }
        }
        private void GetPayUrl(T_Order order)
        {
            string payUrl = "";
            string pDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            PayConfigHelper config = new PayConfigHelper();
            config._backUrl = "http://m.darryring.com/chinapay/notify.ashx";
            config._frontUrl = "http://m.darryring.com/OrderList.aspx";
            config._merchantId = "898440350940269";
            config._privatekeyurl = "\\898510148990028.cer";
            config._publickeyurl = "\\898440350940269.pfx";
            config._title = "手机银联订单";
            config._orderid = order.payid;
            try
            {
                string data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                        "<upbp application=\"MGw.Req\" version =\"1.0.0\" sendTime =\"" + pDate + "\" sendSeqId =\"" + DateTime.Now.ToString("0MMddHHmmssfff") + "\">" +
                        "<frontUrl>" + HttpUtility.HtmlEncode(config._frontUrl) + "</frontUrl><merchantOrderDesc>" + HttpUtility.HtmlEncode(config._title) + "</merchantOrderDesc><misc></misc>" +
                        "<gwType>01</gwType><transTimeout>ssssss</transTimeout><backUrl>" + HttpUtility.HtmlEncode(config._backUrl) + "</backUrl>" +
                        "<merchantOrderCurrency>156</merchantOrderCurrency><merchantOrderAmt>" + order.ordertotal*100 + "</merchantOrderAmt>" +
                        "<merchantId>" + config._merchantId + "</merchantId><merchantOrderTime>" + pDate + "</merchantOrderTime>" +
                        "<merchantOrderId>" + config._orderid+"</merchantOrderId><msgExt></msgExt><merchantUserId></merchantUserId>" +
                        "<mobileNum>" + order.mobile + "</mobileNum>" +
                        "<cardNum></cardNum></upbp>";
                string merchantIdBase64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(config._merchantId));
                string mm = Encrypt.MD5Java("R0HSDVY3R80BVY62VTRFOEJRLBEBNYE8").ToLower().Substring(0, 24);

                string desKey = EncryptDes3.EncryptRSA(mm);
                byte[] keyiv = { 1, 2, 3, 4, 5, 6, 7, 8 };
                byte[] key = Encoding.ASCII.GetBytes(mm);
                byte[] bodyb = EncryptDes3.Des3EncodeECB(key, keyiv, Encoding.UTF8.GetBytes(data));
                //byte[] bodyb = RunTripleDes(Encoding.UTF8.GetBytes(data),key, keyiv ,true);

                String miBody = Convert.ToBase64String(bodyb);
                String xml = merchantIdBase64 + "|" + desKey + "|" + miBody;

                using (System.Net.WebClient wc = new WebClient())
                {
                    
                    string result = wc.UploadString("http://upwap.bypay.cn/gateWay/gate.html", xml);
                   
                    string[] strArr = result.Split('|');
                    byte[] de = Convert.FromBase64String(strArr[1]);
                    byte[] b = EncryptDes3.Des3DecodeECB(key, keyiv, de);
                    if (b != null)
                    {
                        string c = (Encoding.UTF8.GetString(b));
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(c.Replace("\0", ""));
                        string respCode = xmlDoc.SelectSingleNode("//respCode").InnerText;
                        if (respCode == "0000")
                        {
                            _isOk = true;
                            
                            payUrl = xmlDoc.SelectSingleNode("//gwInvokeCmd").InnerText;
                        }
                        else
                        {
                            _isOk = false;
                            _errorStr = xmlDoc.SelectSingleNode("//respDesc").InnerText;
                        }
                    }
                    else
                    {
                        string pmsg = strArr[0];
                        if (pmsg == "0")
                        {
                            Response.Write(Base64Helper.Base64Decrypt(strArr[2]));
                          
                        }
                    }
                }
                if (_isOk)
                {
                    Response.Redirect(payUrl);
                }
                else {
                    Response.Write(_errorStr);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                //_isOk = false;
                //_errorStr = ex.Message;
            }

           
        }
    }
}