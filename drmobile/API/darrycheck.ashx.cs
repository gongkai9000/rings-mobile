using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using DRM.BLL;
using DRM.Entity;
using RSACrypto;
using DRM.Common;

namespace drmobile.API
{
    /// <summary>
    /// darrycheck 的摘要说明
    /// </summary>
    public class darrycheck : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request["action"])
            {
                case "yz":
                    SelectYz(context);
                    break;
            }
        }

        private static void SelectYz(HttpContext context)
        {
            string name = context.Request["name"];
            string card = context.Request["card"];

            card = new MD5Encrypt().MD5Enc(card);

            T_DarryHome model = new MemberBLL().YzDarry(t => t.DarryHomeIDCardMd5 == card);

            var ulr = string.Empty;
            if (model != null)
            {
                bool istrue = bool.Parse(model.DarryHomeIsBit.ToString());
                if (istrue)
                {
                    ulr = string.Format("/ctcg.aspx?name={0}&gName={1}&date={2}&id={3}", HttpUtility.HtmlEncode(model.DarryHomeMemberName), HttpUtility.HtmlEncode(model.DarryHomeMsName), HttpUtility.HtmlEncode(DateTime.Parse(model.DarryHomeDate.ToString()).ToLongDateString()), HttpUtility.HtmlEncode(model.DarryHomeMemberId));
                    context.Response.Clear();
                    context.Response.Write(ulr);
                    context.Response.End();
                }
                else
                {
                    ulr = string.Format("/yzsb.aspx?name={0}", HttpUtility.HtmlEncode(name));
                    context.Response.Clear();
                    context.Response.Write(ulr);
                    context.Response.End();
                }
            }
            else
            {

                ulr = string.Format("/yzsb.aspx?name={0}", HttpUtility.HtmlEncode(name));
                context.Response.Clear();
                context.Response.Write(ulr);
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