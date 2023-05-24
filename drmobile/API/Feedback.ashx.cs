using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL;

namespace drmobile.API
{
    /// <summary>
    /// Feedback 的摘要说明
    /// </summary>
    public class Feedback : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            FeedbackBLL fbll = new FeedbackBLL();
            fbll.addfeedback(new DRM.Entity.Feedback() { 
                content = context.Request.Form["content"],
                mobile = context.Request.Form["mobile"],
                ip = DRM.Common.CommonFun.GetIp(),
                addtime = DateTime.Now
            });
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