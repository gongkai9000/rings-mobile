using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.BLL;
using DRM.Common;
using DRM.Entity;
using System.Web.SessionState;

namespace drmobile.API
{
    /// <summary>
    /// buycheck 的摘要说明
    /// </summary>
    public class buycheck : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Clear();
            //购买darry
            #region 购买darry
            if (context.Request.QueryString["action"] == "dr")
            {
                CartBLL cbll = new CartBLL();
                ResultMsg msg = new ResultMsg();
                string caizhi = context.Request.Form["caizhi"];

                if (string.IsNullOrEmpty(caizhi))
                {
                    msg.Result = false;
                    msg.Msg = "尚未选择材质";
                }
                else
                {
                    msg = cbll.DarryCheckMember(CurrentUser.CurrentUid);
                }

                if (msg.Result)
                {
                    //CookieHelper.ClearCookie("material");
                    //CookieHelper.ClearCookie("diamondid");
                    //CookieHelper.ClearCookie("handsize");
                    //CookieHelper.ClearCookie("font");

                    //CookieHelper.setCookie("material", context.Server.UrlEncode(context.Request.Form["caizhi"]), 1);
                    //CookieHelper.setCookie("diamondid", context.Request.Form["diamondId"],1);
                    //CookieHelper.setCookie("handsize", context.Request.Form["handsize"],1);
                    //CookieHelper.setCookie("font", context.Server.UrlEncode(context.Request.Form["font"]), 1);

                    context.Response.Write("true");
                    context.Response.End();
                }
                else
                {
                    context.Response.Write(msg.Msg);
                    context.Response.End();
                }
            }
            else if (context.Request.QueryString["action"] == "drcard")
            {
                string sirName = context.Request.Form["sirName"];
                string sirCard = context.Request.Form["sirCard"];
                if (sirCard.Length < 30)
                {
                    sirCard = new MD5Encrypt().MD5Enc(sirCard);
                }
                string pid = context.Request.Form["pid"];
                string did = context.Request.Form["did"];
                //string material = context.Request.Form["material"];
                //string handsize = context.Request.Form["handsize"];
                //string font = context.Request.Form["font"];

                DarryHomeBLL darryHome = new DarryHomeBLL();
                if (!darryHome.IsBuyDarry2(sirCard) && !darryHome.IsBuyDarry(CurrentUser.CurrentUid))
                {
                    ////设置session指示此次会话,不用再验证该身份证是否购买过Darry
                    //SessionHelper.SetSession("DarryCheck", "OK");
                    //CookieHelper.setCookie("sirName", name, 30);
                    //CookieHelper.setCookie("sirCode", cardId, 30);

                    AddCartAPI api = new AddCartAPI();
                    context.Items.Add("cmd", "AddCartDR");
                    context.Items.Add("isEnd", "false");
                    api.ProcessRequest(context);

                    if (context.Request.QueryString["type"] == "addcart")
                    {
                        context.Response.Write("{\"code\":\"url\",\"result\":\"true\",\"data\":\"/ctring_detail.aspx?id=" + pid + "&did=" + did + "\"}");
                    }
                    else
                    {
                        context.Response.Write("{\"code\":\"url\",\"result\":\"true\",\"data\":\"/Cart.aspx\"}");
                    }
                }
                else
                {
                    DarryHomeBLL dhbll = new DarryHomeBLL();
                    T_DarryHome model = dhbll.getByCardMd5(sirCard);
                    string json = string.Format("\"code\":\"url\",\"result\":\"false\",\"data\":\"/ctcg.aspx?name={0}&gName={1}&date={2}&id={3}\"", context.Server.UrlEncode(model.DarryHomeMemberName), context.Server.UrlEncode(model.DarryHomeMsName), context.Server.UrlEncode(DateTime.Parse(model.DarryHomeDate.ToString()).ToLongDateString()), context.Server.UrlEncode(Convert.ToString(model.DarryHomeMemberId)));
                    CommonFun.ResponseData("{" + json + "}", true);
                }
            }
            else
            {
                CartBLL cBll = new CartBLL();
                List<T_Cart> cList = cBll.GetCartByMemberId(CurrentUser.CurrentUid);
                DarryHomeBLL dhBll = new DarryHomeBLL();
                if (cBll.IsHaveDarry(cList))
                {
                    context.Response.Write("true");
                    context.Response.End();
                }
                if (dhBll.IsBuyDarry(CurrentUser.CurrentUid))
                {
                    context.Response.Write("true");
                    context.Response.End();
                }
            }
            #endregion

            //购买对戒


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
