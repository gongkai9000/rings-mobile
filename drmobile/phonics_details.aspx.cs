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
using drmobile.master;

namespace drmobile
{
    public partial class phonics_details : DRM.Common.ProductDetailPage
    {
        public string Url
        {
            get
            {
                return Request.Url.ToString();
            }
        }
        /// <summary>
        /// 男戒产品ID
        /// </summary>
        public int ManPID { get; set; }
        /// <summary>
        /// 女戒产品ID
        /// </summary>
        public int WomanPID { get; set; }
        public view_product2 ManProduct { get; set; }
        public view_product2 WomanProduct { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //根据CollectionId获取男戒ID和女戒ID
            ManPID = Convert.ToInt32(CurrentViewProduct.CollectionId.Split(',')[0]);
            WomanPID = Convert.ToInt32(CurrentViewProduct.CollectionId.Split(',')[1]);
            ManProduct = pBll.GetProduct(ManPID);
            WomanProduct = pBll.GetProduct(WomanPID);

            ucProductImgView.ProductID = PID;
            ucProductImgView.CurrentProduct = CurrentViewProduct;

            ucMaterial.ManProductID = ManPID;
            ucMaterial.WomanProductID = WomanPID;
            ucManHandsize.PID = ManPID;
            ucWomanHandsize.PID = WomanPID;

            ucRelatedinfo.CurrentProduct = CurrentViewProduct;
            ucRelatedinfo.IsPhonics = true;
            ucRelatedinfo.ManProduct = ManProduct;
            ucRelatedinfo.WomanProduct = WomanProduct;

            (Master as nSite).CurrentHeader = "商品详情";
            Title = CurrentViewProduct.title + "_CTloves唯爱诺珠宝官网";
            //(Master as nSite).IsGray = false;
            (Master as nSite).PanelClass = " shop_padding";
            (Master as nSite).IsShowBackDefaultPage = "block";
        }

        public int getDay()
        {
            return 15;
        }
    }
}