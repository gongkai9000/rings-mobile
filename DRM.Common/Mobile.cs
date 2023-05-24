using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using DRM.BLL;

namespace DRM.Common
{
    public class Mobile
    {
        //手机验证码发送函数
        public static string GetHtmlFromUrl(string mobile, string strcon,string userid,string account,string pwd)
        {
            string url = "http://inter.ueswt.com/smsGBK.aspx?action=send&userid="+userid+"&account=" + account + "&password=" + pwd + "&mobile=" + mobile + "&content=" + System.Web.HttpUtility.UrlEncode(strcon, System.Text.Encoding.GetEncoding("GB2312"));
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)System.Net.WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.GetEncoding("GB2312"));
                strRet = ser.ReadToEnd();

                SMSPostRecord(mobile, strRet);//短信发送记录
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return strRet;
        }

        //短信发送记录
        public static void SMSPostRecord(string Phone, string StrReturn)
        {
            Entity.Tb_SMSRecord srecord = new Entity.Tb_SMSRecord();
            srecord.SMSPhone = Phone;
            srecord.SMSReturn = StrReturn;
            srecord.SMSIp = CommonFun.GetIp();

            SMSRecordBLL smsrBll = new SMSRecordBLL();

            if (smsrBll.AddSmsRecord(srecord))
            { }
            else
            {
                SMSPostRecord(Phone, StrReturn);
            }
        }
    }
}
