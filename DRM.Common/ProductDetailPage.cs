using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.BLL;

namespace DRM.Common
{
    public class ProductDetailPage : System.Web.UI.Page
    {
        public int PID { get; set; }
        public int DiamondID { get; set; }

        public view_product2 CurrentViewProduct { get; set; }
        public ProductBLL pBll = new ProductBLL();

        protected void Page_PreLoad(object sender, EventArgs args)
        {
            PID = Convert.ToInt32(Request.QueryString["id"]);

            try
            {
                CurrentViewProduct = pBll.GetProduct(PID);
            }
            catch (Exception ex)
            {
                Server.Transfer("/underGoods.aspx");
            }

            if (!string.IsNullOrEmpty(Request.QueryString["Did"]))
            {
                DiamondID = Convert.ToInt32(Request.QueryString["Did"]);
                DiamondBLL dBll = new DiamondBLL();
                T_Diamonds zdiamond = dBll.getDiamondById(DiamondID);

                ResultMsg msg = pBll.checkDiamond(zdiamond, CurrentViewProduct);
                if (!msg.Result)
                {
                    throw new Exception(msg.Msg);
                }

                decimal? memberprice = CurrentViewProduct.MemberPrice + ((zdiamond.memberprice - CurrentViewProduct.DiamondPrice) * CurrentViewProduct.znumber);
                CurrentViewProduct.DiamondPrice = zdiamond.memberprice;
                CurrentViewProduct.zcode = zdiamond.code;
                CurrentViewProduct.zct = zdiamond.carat;
                CurrentViewProduct.zclarity = zdiamond.clarity;
                CurrentViewProduct.zcolor = zdiamond.color;
                CurrentViewProduct.zcut = zdiamond.cut;
                CurrentViewProduct.MemberPrice = memberprice;
                CurrentViewProduct.DiamondId = zdiamond.Id;
            }

            pBll.updateProClickNum(PID);//更新点击数
        }
    }
}
