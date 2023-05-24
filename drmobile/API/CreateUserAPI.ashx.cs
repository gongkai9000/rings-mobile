using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL;
using DRM.Entity;
using DRM.Common;
using System.Web.SessionState;

namespace drmobile.API
{
    /// <summary>
    /// CreateUserAPI 的摘要说明
    /// </summary>
    public class CreateUserAPI : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string email = context.Request["email"];
            string pwd = context.Request["pwd"];
            string pwd1 = context.Request["pwd1"];
            string code = context.Request["code"];
            string mobile = context.Request["mobile"];
            string nickname = context.Request["nickname"];
            string lbaWran = "";
            if (pwd != pwd1)
            {
                lbaWran = "两次密码输入不一致！";
            }
            string v = Convert.ToString(SessionHelper.GetSession(Verification.RegVerification));
            if (code != v && !code.Equals(v))
            {
                lbaWran += "验证码错误！";
            }
            if (MemberBLL.IsRegByMobile(mobile))
            {
                lbaWran += "手机号已被注册！";
            }
            if (pwd.Length < 6 || pwd.Length > 20)
            {
                lbaWran += "密码长度必须在6到20个字符。";
            }

            if (lbaWran.Length == 0)
            {
                
               bool r= AddUser(email,pwd,mobile,nickname);
               if (r)
               {
                   context.Response.Write("true");
               }
               else
               {
                   context.Response.Write("false");
               }
            }
            else
            {
                context.Response.Write(lbaWran);
            }

        }
        /// <summary>
        /// 用户注册
        /// </summary>
        private bool AddUser(string email,string pwd,string mobile,string nickname)
        {
            bool res = false;
            T_Member model = new T_Member();
            model.email = email;
            model.userpwd =pwd;
            model.mobile = mobile;
            model.nickname = nickname;
            model.addtime = DateTime.Now;
            model.regip = CommonFun.GetIp();
            model.loginlock = 0;
            model.appid = 1;

            int id = MemberBLL.GetAddId(model);
            if (id > 0)
            {
                res = true;
                T_Member meModel = MemberBLL.GetMemberById(id);

                CommonFun.UpdateUser(meModel, 0);
            }
            return res;
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