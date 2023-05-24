using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using DRM.Common;
using drmobile.master;
using DRM.Entity;

namespace drmobile
{
    public partial class Cart : System.Web.UI.Page
    {

        public decimal TotalPrice { get; set; }
        public int DataCount { get; set; }
  
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "购物车";
            Title = "购物车";

            #region 绑定数据
            CartBLL cart = new CartBLL();
            List<view_cart> list = cart.GetViewCartByMemberId(CurrentUser.CurrentUid);

            if (list.Count == 0)
            {
                Server.Transfer("EmptyCart.aspx");
            }

            TotalPrice = list.Select(t => t.MemberPrice).Sum() ?? 0;
            DataCount = list.Count;
            rpCart.DataSource = list;
            rpCart.DataBind();
            #endregion

            ucWorkflow.CartList = list;
            ucWorkflow.CurrentProcess = muc.Process.Cart;
        }

        /// <summary>
        /// 图片路径转换
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected string ImageURLFormat(string url)
        {
            return DRM.Common.ImageURLFormat.Format(url);
        }
        public string getDisplay(string type, view_cart cart)
        {
            ProTypeBll ptbll = new ProTypeBll();
            ProductBLL pbll = new ProductBLL();

            if (type == "handsize")
            {
                if (!(pbll.IsDarryRing(cart.productTypeId.Value) || pbll.IsPhonics(cart.productTypeId.Value) || pbll.IsMan(cart.productTypeId.Value)))
                {
                    return " style=\"display:none\"";
                }
            }
            else if (type == "fontstyle")
            {
                if (!(pbll.IsDarryRing(cart.productTypeId.Value) || pbll.IsPhonics(cart.productTypeId.Value) || pbll.IsMan(cart.productTypeId.Value)))
                {
                    return " style=\"display:none\"";
                }
            }
            else if (type == "diamond")
            {
                if (!(pbll.IsDarryRing(cart.productTypeId.Value)))
                {
                    return " style=\"display:none\"";
                }
            }
            return string.Empty;
        }

    }
}