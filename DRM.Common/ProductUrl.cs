using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using DRM.BLL;

namespace DRM.Common
{
    public class ProductUrl
    {
        public static string getUrl(view_orderdetail f)
        {
            int type = f.productTypeId.Value;
            int proid = f.ProductId.Value;
            int? did = f.diamondId;
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
                if (did.HasValue)
                {
                    url = string.Format("/dring_detail.aspx?id={0}&did={1}", proid, did.Value);
                }
                else
                {
                    url = string.Format("/dring_detail.aspx?id={0}", proid);
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
