using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DRM.Entity;
using DRM.DAL;
using System.Net;
using System.IO;

/// <summary>
/// 用户登陆 注册
/// 作者：聂广强
/// 日期：2014年5月22日
/// </summary>
namespace DRM.BLL
{
    public class MemberBLL
    {
        public const string MyInfoCmd = "/API/MyInfoCMD.ashx";
        /// <summary>
        /// 判断用户表中是否有被注册的Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsRegByEmail(string email)
        {
            return MemberDal.IsRegByEmail(email);
        }

        /// <summary>
        /// 判断用户表中是否有被注册的Mobile
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsRegByMobile(string mobile)
        {
            return MemberDal.IsRegByMobile(mobile);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(T_Member model)
        {
            model.appid = 1;
            return MemberDal.Add(model);
        }
        /// <summary>
        /// 添加用户 返回 添加后的用户Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int GetAddId(T_Member model)
        {
            model.appid = 1;
            return MemberDal.GetAddId(model);
        }
        /// <summary>
        /// 跟新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(T_Member model)
        {
            return MemberDal.Update(model);
        }
        /// <summary>
        /// 通过Id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T_Member GetMemberById(int id)
        {
            return MemberDal.GetMemberById(id);
        }
        /// <summary>
        /// 通过邮箱或者手机号查询用户信息
        /// </summary>
        /// <param name="email">邮箱或者手机号</param>
        /// <returns></returns>
        public static T_Member GetMemberBy(string email)
        {
            return MemberDal.GetMemberBy(email);
        }

        //手机验证码发送函数
        public static string GetHtmlFromUrl(string mobile, string strcon)
        {
            string url = "http://inter.ueswt.com/smsGBK.aspx?action=send&userid=3925&account=darry&password=123456&mobile=" + mobile + "&content=" + System.Web.HttpUtility.UrlEncode(strcon, System.Text.Encoding.GetEncoding("GB2312"));
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
            //List<Field> oList = new List<Field>();
            //oList.Add(new Field("SMSPhone", Phone));
            //oList.Add(new Field("SMSReturn", StrReturn));
            //oList.Add(new Field("SMSIp", Framework.Common.WebRequest.GetIP()));
            //bool res = DbHelper.ExcuteInsert("SMSId", "Tb_SMSRecord", "SMSPhone, SMSReturn, SMSIp", "@SMSPhone,@SMSReturn,@SMSIp", oList);
            SMSRecordBLL smsRecordBll = new SMSRecordBLL();
            Tb_SMSRecord r = new Tb_SMSRecord { 
                SMSPhone = Phone,
                SMSReturn = StrReturn,
                SMSIp = getIp()
            };

            bool res = smsRecordBll.AddSmsRecord(r);
            if (res)
            { }
            else
            {
                SMSPostRecord(Phone, StrReturn);
            }
        }

        private static string getIp()
        {
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                return System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(new char[] { ',' })[0];
            else
                return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static T_Member GetMemberbyQQid(string qqid)
        {
            return MemberDal.GetMemberbyQQid(qqid);
        }
        public static T_Member GetMemberbySineid(string sineid)
        {
            return MemberDal.GetMemberbySineid(sineid);
        }

        public T_DarryHome YzDarry(Expression<Func<T_DarryHome, bool>> where)
        {
            return new MemberDal().YzDarry(where);
        }
    }
}
