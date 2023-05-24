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
    /// UpdateAddressStatusAPI 的摘要说明
    /// </summary>
    public class UpdateAddressStatusAPI : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = string.Empty;
            id = context.Request["id"];

            if (id == "")
            {
                context.Response.Write("wrong");
            }
            else
            {
                T_SpAddress model = SpAddressBLL.GetAddressById(int.Parse(id));
                model.SpAddressDefault = true;

                SpAddressBLL.UpdateStatus(CurrentUser.CurrentUid);
                bool res = SpAddressBLL.UpdateAddress(model);
                if (res)
                {
                    context.Response.Write("true");
                    //context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("false");
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