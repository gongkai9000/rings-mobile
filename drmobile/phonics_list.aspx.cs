using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DRM.Entity;
using DRM.BLL;
using drmobile.master;
using DRM.Common;


namespace drmobile
{
    public partial class phonics_list : System.Web.UI.Page
    {
        ProductBLL dringbll = new ProductBLL();
        ProTypeBll ptbll = new ProTypeBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as mSite).CurrentClass = Current.Jew;
            this.Title = getTitle();
            DataLoad();
        }


        private void DataLoad()
        {
            int type = 0;
            List<int> intlList = new List<int>();
            List<view_product2> list = new List<view_product2>();
            if (int.TryParse(Request["type"] ?? "0", out type))
            {
                if (type == 0)
                {
                    intlList = ptbll.GetChidlTypeList(36).Select(t => t.id).ToList();
                    intlList.Add(3);
                    list = dringbll.GetList(intlList);
                }
                else if (type == ProductBLL.ManJiezi)
                {
                    list = dringbll.GetList(ProductBLL.ManJiezi);
                }
                else
                {
                    list = dringbll.GetList(type);
                }
                this.rp_product.DataSource = list;
                this.rp_product.DataBind();
            }

        }

        public string GetURL(object type)
        {
            string url = string.Empty;
            List<int> intlList = ptbll.GetChidlTypeList(36).Select(t => t.id).ToList();
            if (Convert.ToInt32(type) == ProductBLL.ManJiezi)
            {
                url = "/manring_detail.aspx";
            }
            else if (type.ToString() == "3")
            {
                url = "/phonics_details.aspx";
            }
            else if (intlList.Contains(int.Parse(type.ToString())))
            {
                url = "/jewellery_detail.aspx";
            }

            return url;
        }
        public string GetClass(int num)
        {
            if (num == int.Parse(Request["type"] ?? "0"))
            {
                return "click-dr";
            }
            else
            {
                return "";
            }
        }

        public string getTitle()
        {
            string type = Request.QueryString["type"];
            if (string.IsNullOrEmpty(type))
            {
                return "珠宝饰品 首饰 项链吊坠-CTloves唯爱诺珠宝官网";
            }
            else if(type == "3")
            {
                return "CTloves情侣对戒，结婚对戒价格 图片 款式|CTloves唯爱诺珠宝官网";
            }
            else if (type == "2")
            {
                return "男钻戒 钻石男戒价格 图片 款式- CTloves唯爱诺珠宝官网";
            }
            else if (type == "4")
            {
                return "情侣吊坠 钻石吊坠 项链吊坠价格 图片 款式- CTloves唯爱诺珠宝官网";
            }
            else if (type == "5")
            {
                return "饰品项链 钻石项链 情侣项链价格 图片 款式- CTloves唯爱诺珠宝官网";
            }
            else if (type == "8")
            {
                return "手链 情侣手链 钻石手链价格 图片 款式- CTloves唯爱诺珠宝官网";
            }
            else if (type == "6")
            {
                return "钻石耳环 耳坠 耳环饰品 耳环图片大全 - CTloves唯爱诺珠宝官网";
            }
            return "";
        }


    }
}