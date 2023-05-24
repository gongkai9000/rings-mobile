using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Text;
using DRM.Common;
using System.IO;
using DRM.BLL.Order;

namespace drmobile.chinapay
{
    /// <summary>
    /// notify 的摘要说明
    /// </summary>
    public class notify : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            byte[] InputBytes = context.Request.BinaryRead(context.Request.TotalBytes);
            string result = Encoding.UTF8.GetString(InputBytes);
            //string msglog = "";
            ////test
            ////result = "MzAxMzEwMDQ4OTkwMTgy|A2xlrIdR58ZAB6KlS5/pwZkP4sjMv0l18MO05HZO3q4CosJ9+8KrqgGt4iyL7A49JSaQlLWhf/GqAdOvVpaCja6kjszX8Nw4VozsLP7FdoPXpjua356RYXjEZ0EoRnDhMpBz28kxIPD3m9GJAe49UFigFlBIHbP1ZhVnepIxU/Q=|LntMVOkt5wgfz652cz8QtPZ9HbYHW0Ti41LQJfL+jxOYxG99714mSerzg/FIoVvf0oCfXnX0/MCw6N4NhZObq8x0lxREuvo8gvK73qAgQMY2BXJjJpb3AoUZ3CqJds3n7eVE8SrH+n/7Ct6nb/SDLE7Jzdjhex7fpVDj4nCT2Ewkt8AAH6zEPgy5Wajpd/vbbQKDF1koThKzXB33jbdLl2TrojMiEbrjezmeNQe7DGQd8VpM3R9Dz106h6+O+o5+xP/2eVRetONmNHQ0Akf47zDP0qsmQEiUHfFaTN0fQ8+Zc56Ht4wyczmRq8EuECTrqhVPrkD4gG1QUWTlDfuV+9CFL521jTPR1lNvANA3Y88jjL1lveRIjbshfM6yvl9WlfAGHPTQewbCsC8+64+MxE1PQA5ZWITf+VFHDGLiNigXk3AxdfQXTOUKEETM/yaOyyBlRiy7eW2QWs1IjAQhPBcf0t7hqB+G6B8vode8Uy4pv4T6pAuPVGw/O+dzOa7X4H5DrfYZQ7r49QeEZSHwy707Q7PVZ0SskFg2eB2SNiz7Ct6nb/SDLOZ2XPAkPUQd9sW17dguHWmjddx/RKkWkdDkFB2TRXYwcv1gj0W0KsfhRs0GQixxX4FAYBWqxjtXDTfS/SpUFULfH1TstD91paU1mDxg79qm7gdkaFAzipV4Se4BO56OX+ok8AP0QQPZjeymASA8Y2h2jl8I0P8B8mNM9jdlTcMBhZhw5sLjVNITzyZl65yFhSZbtX5H7bOrgCqakCgZlpoYH789DpvV2g==";
            //if (result.Length == 0)
            //{
            //    context.Response.Write("0");
            //    msglog += "0";
            //    return;
            //}
            try
            {
                String[] strArr = result.Split('|');
                byte[] rsab = Convert.FromBase64String(strArr[1]);
                string mm = EncryptDes3.DecryptRSA(strArr[1]);
                byte[] de = Convert.FromBase64String(strArr[2]);
                byte[] key = Encoding.ASCII.GetBytes(mm.Substring(0, 24));
                byte[] keyiv = Encoding.ASCII.GetBytes(mm.Substring(24, 8));
                byte[] b = EncryptDes3.Des3DecodeECB(key, keyiv, de);
                string xml = Encoding.UTF8.GetString(b);
                context.Response.Write("1|0000|OK");
                //using (StreamWriter fs = new StreamWriter(context.Server.MapPath("/chinapay/") + "/NotifyLog.txt", true))
                //{
                //    //日志
                //    fs.Write(DateTime.Now.ToString() + "\r\n" + context.Request.Url.AbsolutePath +
                //        "\r\n" + result + "\r\n" + xml);
                //    fs.Close();
                //}

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml((Encoding.UTF8.GetString(b).Replace("\0", "")));
                string cupsRespCode = xmlDoc.SelectSingleNode("//cupsRespCode").InnerText;
                if (cupsRespCode == "00")
                {
                    //商家内部订单号
                    string merchantOrderId = xmlDoc.SelectSingleNode("//merchantOrderId").InnerText;
                    //支付网关流水号
                    string cupsQid = xmlDoc.SelectSingleNode("//cupsQid").InnerText;
               //     OrderStatus.WriteLog("20150124360281", 15487, "接收数据_订单支付成功_" + merchantOrderId + cupsRespCode, OrderStatus.UserType.前台账号, OrderStatus.Pay_Type.银联在线手机支付.ToString());
                    PayHelper payhelper = new PayHelper();
                    payhelper.ChinaNotifyPay(merchantOrderId, cupsQid);

                }
            }
            catch (Exception ex)
            {
                ////日志
                //using (StreamWriter fs = new StreamWriter(context.Server.MapPath("/chinapay/") + "/PayUniWapNotifyLog.txt", true))
                //{
                //    fs.Write(DateTime.Now.ToString() + "\r\n" + context.Request.Url.AbsolutePath +
                //        "\r\n" + result + "\r\n" + ex.Message);
                //    fs.Close();
                //}
            }
            /*
             * <?xml version="1.0" encoding="UTF-8"?>
             * <upbp application="MTransNotify.Req" version ="1.0.0" sendTime ="20131127224134" sendSeqId ="13112722413425286">
             * <transType>01</transType>
             * <merchantId>630056832596</merchantId>
             * <merchantOrderId>bypayzhuitest635211887299674432</merchantOrderId>
             * <merchantOrderAmt>1</merchantOrderAmt>
             * <settleDate>1127</settleDate>
             * <setlAmt>1</setlAmt>
             * <setlCurrency>156</setlCurrency>
             * <converRate>null</converRate>
             * <cupsQid>201311272238544433802</cupsQid>
             * <cupsTraceNum>443380</cupsTraceNum>
             * <cupsTraceTime>1127223854</cupsTraceTime>
             * <cupsRespCode>00</cupsRespCode>
             * <cupsRespDesc></cupsRespDesc>
             * </upbp>
             */
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}