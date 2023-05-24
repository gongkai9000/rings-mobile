using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.Entity;
using DRM.BLL;
using DRM.Common;
using System.Web.SessionState;

namespace drmobile.API
{
    /// <summary>
    /// LoginAPI 的摘要说明
    /// </summary>
    public class LoginAPI : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string email = context.Request["email"];
            string pwd = context.Request["pwd"];
            email = email.ToLower();

            if (email == null)
            {
                context.Response.Write("email");
            }
            if (pwd == null)
            {
                context.Response.Write("pwd");
            }

            T_Member model = MemberBLL.GetMemberBy(email);

            if (model != null)
            {
                string password = model.userpwd;
                if (pwd == password)
                {
                    if (model.loginlock.ToString() == "0" || model.loginlock.ToString() == "")
                    {

                        CommonFun.UpdateUser(model, 0);
                    }
                    else
                    {
                        //账号已锁定！
                        context.Response.Write("lock");

                    }
                }
                else
                {
                    // "密码错误！";
                    context.Response.Write("wrong");

                }

            }
            else
            {
                //"账号不存在！请重新输入。";
                context.Response.Write("null");
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