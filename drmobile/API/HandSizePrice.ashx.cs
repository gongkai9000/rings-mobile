using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using DRM.Entity;
using DRM.BLL;

namespace drmobile.API
{
    /// <summary>
    /// HandSizePrice 的摘要说明
    /// </summary>
    public class HandSizePrice : IHttpHandler
    {
        JavaScriptSerializer jsSerializ = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            switch (action)
            {
                case "darry":
                    GetdarryPricre(context);
                    break;
                default:
                    GetPrice(context);
                    break;
            }
        }

        private void GetdarryPricre(HttpContext context)
        {
            int pid = 0;
            int pidc = 0;
            int sizec = 0;
            int size = 0;

            string martrial = context.Request["mart"];

            decimal? price = 0;
            if (int.TryParse(context.Request["pid"], out pidc))
            {
                pid = pidc;
                if (int.TryParse(context.Request["size"], out sizec))
                {
                    size = sizec;
                    T_HandSize model = new HandSizeBll().GetSize(pid, size, martrial);

                    if (model != null)
                    {
                        price = model.price;
                    }
                    else
                    {
                        price = 0;
                    }
                }
                else
                {
                    price = 0;
                }
            }

            context.Response.Clear();
            context.Response.Write(jsSerializ.Serialize(new { Price = price }));
            context.Response.End();

        }

        private void GetPrice(HttpContext context)
        {
            context.Response.Clear();
            context.Response.Write(jsSerializ.Serialize(new { Price = 0 }));
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