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
    /// AddCartAPI 的摘要说明
    /// </summary>
    public class AddCartAPI : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string cmd = context.Request.QueryString["cmd"] ?? Convert.ToString(context.Items["cmd"]);

            string caizhi = getCaizhi(cmd, context);
            ProductBLL npBll = new ProductBLL();
            string pid = context.Request.Form["pid"];
            if (string.IsNullOrEmpty(caizhi))
            {
                context.Response.Clear();
                context.Response.Write("材质不能为空");
                context.Response.End();
            }

            CartBLL cbll = new CartBLL();
            ResultMsg msg;
            switch (cmd)
            {
                case "AddCartDR":
                    if (!npBll.GetMaterial(caizhi, Convert.ToInt32(pid)))
                    {
                        context.Response.Clear();
                        context.Response.Write("该产品不能匹配该材质");
                        context.Response.End();
                    }
                    AddCartDR(context);
                    break;
                case "AddCartPh":
                    msg = cbll.CheckOther(CurrentUser.CurrentUid);
                    if (msg.Result)
                    {
                        AddCartPh(context);
                    }
                    else
                    {
                        context.Response.Write(msg.Msg);
                        context.Response.End();
                    }
                    break;
                case "AddCartJl":
                    msg = cbll.CheckOther(CurrentUser.CurrentUid);
                    if (msg.Result)
                    {
                        AddCartJewelry(context);
                    }
                    else
                    {
                        context.Response.Write(msg.Msg);
                        context.Response.End();
                    }
                    break;
                case "AddCartMan":
                    msg = cbll.CheckOther(CurrentUser.CurrentUid);
                    if (msg.Result)
                    {
                        AddCartmandarry(context);
                    }
                    else
                    {
                        context.Response.Write(msg.Msg);
                        context.Response.End();
                    }
                    break;
            }

            if (string.IsNullOrEmpty(Convert.ToString(context.Items["isEnd"])))
            {
                context.Response.Clear();
                context.Response.Write("true");
                context.Response.End();
            }
        }

        private string getCaizhi(string type,HttpContext context)
        {
            if (type == "AddCartDR")
            {
                return context.Request.Form["material"];
            }
            else
            {
                return context.Request.Form["caizhi"];
            }
        }

        private void AddCartPh(HttpContext context)
        {
            CartBLL cbll = new CartBLL();

            AddCartPhonics(context);

        }

        public void AddCartDR(HttpContext context)
        {
            CartBLL cbll = new CartBLL();

            string sirCard = context.Request.Form["sirCard"];

            ResultMsg msg = cbll.DarryCheckMember(CurrentUser.CurrentUid, sirCard);

            if (!msg.Result)
            {
                context.Response.Clear();
                context.Response.Write(msg.Msg);
                context.Response.End();
            }

            if (string.IsNullOrEmpty(context.Request.Form["sirCard"]))
            {
                context.Response.Clear();
                context.Response.Write("数据失效，请从商品详情页中重新购买。");
                context.Response.End();
            }

            AddCart(context);

            //CookieHelper.ClearCookie("material");
            //CookieHelper.ClearCookie("diamondid");
            //CookieHelper.ClearCookie("handsize");
            //CookieHelper.ClearCookie("font");

        }



        /// <summary>
        /// Darry Ring
        /// </summary>
        private void AddCart(HttpContext context)
        {
            string productid = context.Request.Form["pid"];
            string did = context.Request.Form["did"];
            string material = context.Request.Form["material"];
            string handsize = context.Request.Form["handsize"];
            string font = context.Request.Form["font"];
            string sirName = context.Request.Form["sirName"];
            string sirCard = context.Request.Form["sirCard"];

            int pid = Convert.ToInt32(productid);
            int diamondId = Convert.ToInt32(did);

            ProductBLL pBll = new ProductBLL();
            view_product2 vp = pBll.GetProduct(pid);

            int zdiamondid = Convert.ToInt32(did);
            DiamondBLL dbll = new DiamondBLL();
            T_Diamonds zdiamond = dbll.getDiamondById(zdiamondid);
            ResultMsg msg= pBll.checkDiamond(zdiamond, vp);
            if (!msg.Result)
            {
                context.Response.Clear();
                context.Response.Write(msg.Msg);
                context.Response.End();
            }

            int memberid = CurrentUser.CurrentUid;
            //SessionHelper.GetSession("handsize"
            //string handsize = Convert.ToString(CookieHelper.GetCookie("handsize") ?? "");
            //string material = Convert.ToString(context.Server.UrlDecode(CookieHelper.GetCookie("material") ?? ""));
            //string font = Convert.ToString(context.Server.UrlDecode(CookieHelper.GetCookie("font") ?? ""));
            font = font.Replace("♥", "&hearts;");
            //int diamondId = Convert.ToInt32(CookieHelper.GetCookie("diamondid"));

            CartBLL cBll = new CartBLL();
            cBll.AddCartByProduct(vp, memberid, handsize, font, material, diamondId, vp.fDiamondId, "Darry Ring", sirName, sirCard);
        }

        /// <summary>
        /// 男戒
        /// </summary>
        private void AddCartmandarry(HttpContext context)
        {
            int pid = Convert.ToInt32(context.Request.Form["pid"]);
            ProductBLL pBll = new ProductBLL();
            view_product2 vp = pBll.GetProduct(pid);

            int memberid = CurrentUser.CurrentUid;
            string handsize = context.Request.Form["handsize"];
            string material = context.Request.Form["caizhi"];
            string font = context.Request.Form["font"];
            font = font.Replace("♥", "&hearts;");
            //int diamondId = Convert.ToInt32(Request.Form["diamondId"]);

            CartBLL cBll = new CartBLL();
            cBll.AddCartByProduct(vp, memberid, handsize, font, material, vp.DiamondId, vp.fDiamondId, "男戒", null, null);
        }

        /// <summary>
        /// 珠宝
        /// </summary>
        private void AddCartJewelry(HttpContext context)
        {
            int pid = Convert.ToInt32(context.Request.Form["pid"]);
            ProductBLL pBll = new ProductBLL();
            view_product2 vp = pBll.GetProduct(pid);
            int memberid = CurrentUser.CurrentUid;
            string material = context.Request.Form["caizhi"];
            CartBLL cBll = new CartBLL();
            cBll.AddCartByProduct(vp, memberid, "", "", material, vp.DiamondId, vp.fDiamondId, "珠宝", null, null);
        }

        /// <summary>
        /// 对戒
        /// </summary>
        private void AddCartPhonics(HttpContext context)
        {
            int pid = Convert.ToInt32(context.Request.Form["pid"]);// Convert.ToInt32(context.Request.Form["pid"]);
            ProductBLL pBll = new ProductBLL();
            view_product2 p = pBll.GetProduct(pid);
            view_product2 manvp = pBll.GetProduct(Convert.ToInt32(p.CollectionId.Split(',')[0]));
            view_product2 womanvp = pBll.GetProduct(Convert.ToInt32(p.CollectionId.Split(',')[1]));

            int memberid = CurrentUser.CurrentUid;
            string manhandsize = Convert.ToString(context.Request.Form["manhandsize"]);// SessionHelper.GetSession("manhandsize");
            string womanhandsize = Convert.ToString(context.Request.Form["womanhandsize"]);//context.Request.Form["womanhandsize"];
            string handsize = string.IsNullOrEmpty(manhandsize + womanhandsize) ? "" : "男【" + manhandsize + "】,女【" + womanhandsize + "】";

            string material = Convert.ToString(context.Request.Form["caizhi"]); //context.Request.Form["caizhi"];

            string manfont = Convert.ToString(context.Request.Form["manfont"]).Replace("♥", "&hearts;");//context.Request.Form["manfont"];
            string womanfont = Convert.ToString(context.Request.Form["womanfont"]).Replace("♥", "&hearts;");//context.Request.Form["womanfont"];
            string font = string.IsNullOrEmpty(manfont + womanfont) ? "" : "男【" + manfont + "】,女【" + womanfont + "】";

            CartBLL cBll = new CartBLL();
            cBll.AddCartByProduct(p, manvp.id, womanvp.id, memberid, handsize, manhandsize, womanhandsize, font, material, manvp.DiamondId, manvp.fDiamondId, womanvp.DiamondId, womanvp.fDiamondId);
            //cBll.AddCartByProduct(womanvp, memberid, womanhandsize, womanfont, material, -1, ncs.WebConfig.TJZuanShi);
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