using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.Entity;
using DRM.BLL;

namespace drmobile.API
{
    /// <summary>
    /// DeleteAddressAPI 的摘要说明
    /// </summary>
    public class DeleteAddressAPI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //地址列表 Id
            string id = "";
            id = context.Request["id"];
            if (id == "")
            {
                context.Response.Write("noid");
            }
            else
            {
                bool res = SpAddressBLL.Delete(int.Parse(id));
                if (res)
                {
                    context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("wrong");
                }
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