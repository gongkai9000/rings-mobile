using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.Entity;
using DRM.BLL;
using DRI.BLL;
using DRM.Common;

namespace drmobile
{
    public partial class MyCollect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "我的收藏";
            this.Title = "我的收藏";
            (Master as nSite).PanelClass = " nopadding";

            FavoritesBLL fbll = new FavoritesBLL();
            var data = fbll.getFavorites(CurrentUser.CurrentUid);

            if (data.Count == 0)
            {
                Server.Transfer("EmptyCollect.aspx");
            }

            rpCollect.DataSource = data;
            rpCollect.DataBind();
        }

        public string getUrl(view_myfavorites f)
        {
            int type = f.productTypeId;
            int proid = f.pid;
            string myparm = f.myParms;
            string url = "";
            List<int> nanjieList = new List<int>() { 2 };
            List<ProductType> jewList = new ProTypeBll().GetChidlTypeList(36);
            List<ProductType> darryList = new ProTypeBll().GetChidlTypeList(1);
            List<ProductType> phLis = new ProTypeBll().GetChidlTypeList(3);

            if (nanjieList.Contains(type))
            {
                url = string.Format("/manring_detail.aspx?id={0}", proid);
            }
            else if (jewList.Select(t => t.id).Contains(type))
            {
                url = string.Format("/jewellery_detail.aspx?id={0}", proid);
            }
            else if (darryList.Select(t => t.id).Contains(type))
            {
                if (string.IsNullOrEmpty(myparm))
                {
                    url = string.Format("/dring_detail.aspx?id={0}", proid);
                }
                else
                {
                    url = string.Format("/dring_detail.aspx?id={0}&Did={1}", proid, myparm);
                }
            }
            else if (phLis.Select(t => t.id).Contains(type))
            {
                url = string.Format("/phonics_details.aspx?id={0}", proid);
            }
            return url;
        }
    }
}