using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DRM.Entity;
using DRM.BLL;
using drmobile.master;

namespace drmobile
{
    public partial class diamondring_list : System.Web.UI.Page
    {

        ProductBLL dringbll = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as mSite).CurrentClass = Current.Darry;
            this.Title = getTitle();
            DataLoad();
        }


        private void DataLoad()
        {
            int result = 1;
            if (!int.TryParse(this.Request["typeid"] ?? "1", out result))
                return;
            this.SetClass(result);
            this.rp_product.DataSource = (object)this.dringbll.GetList(result);
            this.rp_product.DataBind();

        }

        /// <summary>
        /// 获取钻重信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetCtStr(Object obj)
        {
            string str = "";
            if (obj != null)
            {
                if (obj != "")
                {
                    double s = Convert.ToDouble(obj);
                    str = (s * 100) + "分";
                }
                else
                {
                    str = "";
                }
            }
            else
            {
                str = "";
            }
            return str;
        }

        /// <summary>
        /// 获取钻石颜色
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetClolor(Object obj)
        {
            string str = "";
            if (obj != null)
            {
                if (obj != "")
                {
                    str = Convert.ToString(obj) + "色";
                }
                else
                {
                    str = "";
                }
            }
            else
            {
                str = "";
            }
            return str;
        }

        public void SetClass(int num)
        {
            switch (num)
            {
                case 1:
                    this.all.Attributes["class"] = "click-dr";
                    break;
                case 11:
                    this.myheart.Attributes["class"] = "click-dr";
                    break;
                case 12:
                    this.forever.Attributes["class"] = "click-dr";
                    break;
                case 15:
                    this.swear.Attributes["class"] = "click-dr";
                    break;
                case 16:
                    this.truelove.Attributes["class"] = "click-dr";
                    break;
                case 17:
                    this.just.Attributes["class"] = "click-dr";
                    break;
            }
        }

        public string getTitle()
        {
            string str = this.Request.QueryString["typeid"];
            if (string.IsNullOrEmpty(str))
                return "CTloves钻戒价格 CTloves钻石戒指|CTloves官网";
            switch (str)
            {
                case "12":
                    return "Forever系列求婚钻戒_CTloves唯爱诺珠宝官网";
                case "11":
                    return "My Heart系列求婚钻戒_CTloves唯爱诺珠宝官网";
                case "15":
                    return "I Swear系列求婚钻戒_CTloves唯爱诺珠宝官网";
                case "17":
                    return "Princess系列求婚钻戒_CTloves唯爱诺珠宝官网";
                case "16":
                    return "True Love系列求婚钻戒_CTloves唯爱诺珠宝官网";
                default:
                    return "";
            }
        }
    }
}