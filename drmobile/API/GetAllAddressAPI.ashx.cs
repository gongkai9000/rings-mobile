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
    /// GetAllAddressAPI 的摘要说明
    /// </summary>
    public class GetAllAddressAPI : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            List<T_SpAddress> list = SpAddressBLL.GetAlladderssByUid(CurrentUser.CurrentUid);
            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var data = jsSerializer.Serialize(list);
            context.Response.Write(data);
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