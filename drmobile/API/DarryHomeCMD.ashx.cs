using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DRM.Common;
using DRM.Entity;
using DRM.BLL;
using System.Web.Script.Serialization;

namespace drmobile.API
{
    /// <summary>
    /// DarryHomeCMD 的摘要说明
    /// </summary>
    public class DarryHomeCMD : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            T_Cart cart = SessionHelper.GetSession("temp_cart") as T_Cart;
            //SessionHelper.SetSession("temp_cardId", context.Request.QueryString["cardId"]);

            CartBLL cartbll = new CartBLL();
            ResultMsg msg = new ResultMsg();
            if (cartbll.AddCartData(cart) > 0)
            {
                msg.Result = true;
                msg.Msg = "添加成功。";
            }
            else
            {
                msg.Result = false;
                msg.Msg = "添加失败。";
            }

            //SessionHelper.ClearSession("temp_cart");
            //SessionHelper.ClearSession("temp_cardId");
            
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CommonFun.ResponseJSON(serializer.Serialize(msg), false);
            //if (msg.Result)
            //{
            //    //context.Response.Redirect("/Cart.aspx");

            //    CommonFun.ResponseJSON(serializer.Serialize(msg);, false);
            //}
            //else
            //{
            //    CommonFun.ResponseJSON("{result:\"false\",msg:\"\"}", false);
            //    //context.Response.Write(string.Format("<script>alert('{0}');window.location.href='{1}';</script>", msg.Msg, returnUrl));
            //}
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