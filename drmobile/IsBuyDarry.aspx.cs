using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using DRM.BLL.Result;
using System.Text;
using DRM.Common;
using drmobile.master;
using DRM.Entity;
using alipay_pay;
using System.Web.Helpers;

namespace drmobile
{
    public partial class IsBuyDarry : System.Web.UI.Page
    {
        public view_product2 CurrentProduct { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master as nSite).CurrentHeader = "验证查询";
            this.Title = "CTloves验证查询-CTloves-求婚钻戒领导品牌";
            string logFilePath = Server.MapPath("log/" + DateTime.Now.ToString().Replace(":", "_").Replace(" ", "_").Replace("/", "_")) + "_isbuydarry.txt";
            
            this.CurrentProduct = new ProductBLL().GetProduct(Convert.ToInt32(this.Request.QueryString["pid"]));
            if (string.IsNullOrEmpty(this.Request.QueryString["did"]))
                return;
            AlipayFunction.log_result(logFilePath, "\r\n" + "all request:" + this.Request.ToString());
            T_Diamonds diamondById = new DiamondBLL().getDiamondById(Convert.ToInt32(this.Request.QueryString["did"]));
            this.CurrentProduct.DiamondPrice = diamondById.memberprice;
            this.CurrentProduct.zcode = diamondById.code;
            this.CurrentProduct.zct = diamondById.carat;
            this.CurrentProduct.zclarity = diamondById.clarity;
            this.CurrentProduct.zcolor = diamondById.color;
            this.CurrentProduct.zcut = diamondById.cut;
            this.CurrentProduct.DiamondId = new int?(diamondById.Id);
            this.CurrentProduct.MemberPrice = new Decimal?(Convert.ToDecimal(this.Request.QueryString["price"]));
        }
    }
}