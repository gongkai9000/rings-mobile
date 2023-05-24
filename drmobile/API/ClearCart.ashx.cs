using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL;
using DRM.Common;

namespace drmobile.API
{
    /// <summary>
    /// ClearCart 的摘要说明
    /// </summary>
    public class ClearCart : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Request.QueryString["action"] == "clear")
            {
                CartBLL cbll = new CartBLL();
                context.Response.Clear();
                try
                {
                    int count = cbll.GetCartCount(CurrentUser.CurrentUid);
                    int result = cbll.DeleteCartByMemberId(CurrentUser.CurrentUid);

                    if (result == count)
                    {
                        context.Response.Write("true");
                    }
                    else
                    {
                        context.Response.Write("清空失败！");
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write(ex.Message);
                }
                context.Response.End();
            }
            else if (context.Request.QueryString["action"] == "delete")
            {
                CartBLL cbll = new CartBLL();
                int cartid = Convert.ToInt32(context.Request.QueryString["cartid"]);
                cbll.DeleteCartById(cartid, CurrentUser.CurrentUid);
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