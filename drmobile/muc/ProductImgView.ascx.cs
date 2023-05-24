using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;
using DRI.BLL;
using DRM.Common;
using DRM.BLL;

namespace drmobile.muc
{
    public partial class ProductImgView : System.Web.UI.UserControl
    {
        public List<ProductImgUrl> ImgUrlList { get; set; }
        public int ProductID { get; set; }

        public view_product2 CurrentProduct { get; set; }
        public int CollectCount { get; set; }

        public string Url { get; set; }

        public int? DiamondArgs {
            get {
                return string.IsNullOrEmpty(Request.QueryString["Did"]) ? (int?)null : Convert.ToInt32(Request.QueryString["Did"]);
            }
        }
        public string FavoriteDID {
            get {
                return DiamondArgs.HasValue ? DiamondArgs.Value.ToString() : "";
            }
        }

        ProductBLL pbll = new ProductBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Url = Request.Url.ToString();
            
            ImgUrlList = pbll.GetUrlById(ProductID);
            rpImg.DataSource = ImgUrlList;
            rpImg.DataBind();

            FavoritesBLL fbll = new FavoritesBLL();
            CollectCount = fbll.getFavoritesCountByProduct(ProductID);

            //收藏样式
            string fjs = string.Empty;
            FavoritesBLL fBll = new FavoritesBLL();
            if (CurrentUser.IsLogin)
            {
                if (fBll.IsFavorites(ProductID, CurrentUser.CurrentUid))
                {
                    fjs = "$(function(){favoritesCss(true);});";
                }
                else
                {
                    fjs = "$(function(){favoritesCss(false);});";
                }

            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "initMagnifier", fjs, true);
        }
      
        public string GetTitle(int typeid)
        {
            if (pbll.IsDarryRing(typeid))
            {
                return CurrentProduct.title + " " + (CurrentProduct.zct * 100) + "分" + CurrentProduct.zcolor + "色";
            }
            else
            {
                return CurrentProduct.title;
            }
        }
    }
}