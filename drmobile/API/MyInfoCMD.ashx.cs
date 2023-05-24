using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.Entity;
using DRM.Common;
using DRM.BLL;
using System.Web.SessionState;

namespace drmobile.API
{
    /// <summary>
    /// MyInfoCMD 的摘要说明
    /// </summary>
    public class MyInfoCMD : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            int memberId = CurrentUser.CurrentUid;
            T_Member member = MemberBLL.GetMemberById(memberId);

            member.nickname = context.Request.Form["nickname"];
            member.realname = context.Request.Form["realname"];
            member.gender = context.Request.Form["gender"];
            //member.birthday = context.Request.Form["birthday"];
            //member.address = context.Request.Form["address"];
            //member.postcode = context.Request.Form["postcode"];
            member.mobile = context.Request.Form["mobile"];
            member.email = context.Request.Form["email"];

            if (!string.IsNullOrEmpty(member.email) && MemberBLL.IsRegByEmail(member.email) && MemberBLL.GetMemberBy(member.email).Id != memberId)
            {
                context.Response.Clear();
                context.Response.Write("邮箱已存在");
                context.Response.End();
            }
            if (!string.IsNullOrEmpty(member.mobile) && MemberBLL.IsRegByMobile(member.mobile) && MemberBLL.GetMemberBy(member.mobile).Id != memberId)
            {
                context.Response.Clear();
                context.Response.Write("手机号已存在");
                context.Response.End();
            }

            MemberBLL.Update(member);

            context.Response.Clear();
            context.Response.Write("");
            context.Response.End();
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