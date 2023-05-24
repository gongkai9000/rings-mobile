using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL;
using DRM.Common;
using System.Web.SessionState;
using DRM.Entity;

namespace drmobile.API
{
    /// <summary>
    /// CheckCart 的摘要说明
    /// </summary>
    public class CheckCart : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            CartBLL cbll = new CartBLL();
            context.Response.Clear();

            var data = cbll.GetCartByMemberId(CurrentUser.CurrentUid);
            if(data.Count == 0)
            {
                context.Response.Write("购物车为空，请刷新购物车");
            }

            T_Cart cart = cbll.getDarryInCart(data);
            if (cart != null && string.IsNullOrEmpty(cart.sirCode))
            {
                context.Response.Write("DR验证信息失效，请删除DR求婚钻戒，重新加入购物车");
            }
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
