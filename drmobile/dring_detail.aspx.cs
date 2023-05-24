using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DRM.Entity;
using DRM.BLL;
using DRM.Common;
using System.Data;
using DRI.BLL;
using drmobile.master;

namespace drmobile
{
    public partial class dring_detail : DRM.Common.ProductDetailPage
    {
        public string Url { get {
            return Request.Url.ToString();
        } }

        public string IsShowCustomDiamond { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            tjLuozuan(CurrentViewProduct.TJLZ);

            ucProductImgView.ProductID = PID;
            ucProductImgView.CurrentProduct = CurrentViewProduct;

            ucMaterial.ProductID = PID;
            ucHandsize.PID = PID;

            ucrelatedinfo.CurrentProduct = CurrentViewProduct;

            (Master as nSite).CurrentHeader = "商品详情";
            Title = CurrentViewProduct.title + "_" + CurrentViewProduct.zct + "克拉_" + CurrentViewProduct.zcolor + "色_" + CurrentViewProduct.zcut + CurrentViewProduct.zclarity + "价格图片_CTloves求婚钻戒 唯爱诺珠宝官网";
            //(Master as nSite).IsGray = false;
            (Master as nSite).PanelClass = " shop_padding";
            (Master as nSite).IsShowBackDefaultPage = "block";

            IsShowCustomDiamond = CurrentViewProduct.IsCustomDiamond.HasValue ? (CurrentViewProduct.IsCustomDiamond.Value ? "" : "style=\"display:none\"") : "style=\"display:none\"";

        }

        //获取推荐裸钻//
        private void tjLuozuan(int? tjlz)
        {
            if (tjlz.HasValue)
            {
                DiamondBLL dbll = new DiamondBLL();
                rpZuanshi.DataSource = dbll.getListByType(tjlz.Value, 9);
                rpZuanshi.DataBind();
            }
            else
            {
                tjPanel.Visible = false;
            }
        }


        public int getDay()
        {
            if (CommonFun.Is20Day(CurrentViewProduct.productTypeId, CurrentViewProduct.id))
            {
                return 20;
            }
            return 15;
        }
    }
}
