using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.Common;

namespace drmobile.API
{
    /// <summary>
    /// truelove 的摘要说明
    /// </summary>
    public class truelove : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //CookieHelper.ClearCookie("sirName");
            CookieHelper.ClearCookie("ladyName");
            //CookieHelper.ClearCookie("sirCode");
            CookieHelper.ClearCookie("sheBirthday");
            CookieHelper.ClearCookie("sheDate1");
            CookieHelper.ClearCookie("sheDate2");

            //CookieHelper.setCookie("sirName", context.Request.Form["sirName"],1);
            CookieHelper.setCookie("ladyName", context.Request.Form["ladyName"], 1);
            //CookieHelper.setCookie("sirCode", context.Request.Form["sirCode"], 1);

            CookieHelper.setCookie("sheBirthday", context.Request.Form["sheBirthday"], 1);
            CookieHelper.setCookie("sheDate1", context.Request.Form["sheDate1"], 1);
            CookieHelper.setCookie("sheDate2", context.Request.Form["sheDate2"], 1);
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