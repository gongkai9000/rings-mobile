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
    public partial class manring_detail : DRM.Common.ProductDetailPage
    {
        public string Url
        {
            get
            {
                return Request.Url.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucProductImgView.ProductID = PID;
            ucProductImgView.CurrentProduct = CurrentViewProduct;

            ucMaterial.ProductID = PID;
            ucHandsize.PID = PID;

            ucrelatedinfo.CurrentProduct = CurrentViewProduct;

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