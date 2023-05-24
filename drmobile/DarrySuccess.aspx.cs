using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL.Order;
using DRM.Common;

namespace drmobile
{
    public partial class DarrySuccess : System.Web.UI.Page
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        private int ProductId { get; set; }
        public OrderBtn Btn { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Btn = new OrderBtn();
            if (string.IsNullOrEmpty(Request.QueryString["productId"]))
            {
                Btn.IsDisplay = true;
                Btn.Url = "diamondring_list.aspx";
                Btn.Text = "挑选钻戒";
            }
            else
            {
                Btn.IsDisplay = true;
                Btn.Url = "javascript:void(0);";
                Btn.OnClick = "BuyNow();";
                Btn.Text = "立即购买";

            }


        }

    }

}