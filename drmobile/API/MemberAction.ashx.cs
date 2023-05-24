using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL;
using System.Web.SessionState;
using DRM.Common;
using DRM.Entity;
using System.Configuration;

namespace drmobile.API
{
    /// <summary>
    /// MemberAction 的摘要说明
    /// </summary>
    public class MemberAction : IHttpHandler, IRequiresSessionState
    {
        public static readonly string Domain =  ConfigurationManager.AppSettings["crossdomain"];

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["action"] == "findpwd")
            {
                string mobile = context.Request.Form["mobile"];
                string vcode = context.Request.Form["code"];
                string pwd = context.Request.Form["pwd"];

                if (pwd.Length < 6 || pwd.Length > 20)
                {
                    context.Response.Write("密码长度必须在6到20个字符");
                    context.Response.End();
                }

                if (MemberBLL.IsRegByMobile(mobile))
                {
                    string v = Convert.ToString(SessionHelper.GetSession(Verification.FindPwdVerification));
                    if (v == vcode || vcode.Equals(v))
                    {
                        T_Member m = MemberBLL.GetMemberBy(mobile);
                        m.userpwd = pwd;
                        MemberBLL.Update(m);
                    }
                    else
                    {
                        context.Response.Write("验证码不正确。");
                    }
                }
                else
                {
                    context.Response.Write("手机号未注册。");
                }
            }
            else if(context.Request.QueryString["action"] == "changepwd")
            {
                string oldpwd = context.Request.Form["oldpwd"];
                string newpwd = context.Request.Form["newpwd"];

                T_Member m = MemberBLL.GetMemberById(CurrentUser.CurrentUid);
                if (m != null)
                {
                    if (m.userpwd == oldpwd)
                    {
                        m.userpwd = newpwd;
                        MemberBLL.Update(m);
                    }
                    else
                    {
                        context.Response.Write("旧密码不正确。");
                    }
                }
                else
                {
                    context.Response.Write("请先登录。");
                }
            }
            else if (context.Request.QueryString["action"] == "signout")
            {
                CookieHelper.ClearCookieByDomain("uid", Domain);
                CookieHelper.ClearCookieByDomain("email", Domain);
                CookieHelper.ClearCookieByDomain("mobile", Domain);
                CookieHelper.ClearCookieByDomain("uname", Domain);
                CookieHelper.ClearCookieByDomain("logintime", Domain);
                CookieHelper.ClearCookieByDomain("loginip", Domain);
                CookieHelper.ClearCookieByDomain("UserTypeId", Domain);
            }
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