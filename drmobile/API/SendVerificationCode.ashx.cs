using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.Common;
using System.Configuration;
using System.Web.SessionState;
using DRM.BLL;

namespace drmobile.API
{
    public class Verification
    {
        public static readonly string RegVerification = "RegVerification";
        public static readonly string FindPwdVerification = "FindPwdVerification";
    }

    /// <summary>
    /// SendSmsRecord 的摘要说明
    /// </summary>
    public class SendVerificationCode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mobile = context.Request.QueryString["mobile"];

            Random r = new Random();
            string code = string.Empty;
            for(int i = 0; i < 6;i++)
            {
                code += r.Next(0,10).ToString();
            }

            string type = string.Empty;
            switch (context.Request.QueryString["type"])
            { 
                case "reg":
                    type = Verification.RegVerification;
                    if (MemberBLL.IsRegByMobile(mobile))
                    {
                        context.Response.Write("该手机已注册");
                        context.Response.End();
                    }
                    break;
                case "findpwd":
                    type = Verification.FindPwdVerification;
                    if (!MemberBLL.IsRegByMobile(mobile))
                    {
                        context.Response.Write("该手机号未注册");
                        context.Response.End();
                    }
                    break;
            }
            SessionHelper.SetSession(type, code, 5);

            Mobile.GetHtmlFromUrl(mobile, string.Format(ConfigurationManager.AppSettings[type], DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss"), code), ConfigurationManager.AppSettings["SMSUserID"], ConfigurationManager.AppSettings["SMSAccount"], ConfigurationManager.AppSettings["SMSPwd"]);
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