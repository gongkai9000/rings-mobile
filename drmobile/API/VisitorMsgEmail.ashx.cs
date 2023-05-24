using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL;
using DRM.Entity;

namespace drmobile.API
{
    /// <summary>
    /// VisitorMsgEmail 的摘要说明
    /// </summary>
    public class VisitorMsgEmail : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            if (action == "add")
            {
                VisitorMsgEmailBLL bll = new VisitorMsgEmailBLL();
                T_QxEmail email = new T_QxEmail();
                email.mailfrom = context.Request.Form["from"];
                email.mailto = context.Request.Form["to"];
                email.mailcontent = context.Request.Form["content"];
                email.addtime = DateTime.Now;
                email.senderip = DRM.Common.CommonFun.GetIp();

                bll.AddVisitorMsgEmail(email);

                context.Response.Clear();
                context.Response.Write(email.id);
                context.Response.End();
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