using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using System.Dynamic;
using System.Reflection;

namespace drmobile.muc
{
    public partial class CommodityInfo : System.Web.UI.UserControl
    {
        public dynamic Data { get; set; }

        public string carat {
            get {
                Type type = Data.GetType();
                PropertyInfo info = type.GetProperty("carat");
                PropertyInfo zct = type.GetProperty("zct");
                if (info != null)
                {
                    return Convert.ToString(info.GetValue(Data, null) * 100);
                }
                else if (zct != null)
                {
                    return Convert.ToString(zct.GetValue(Data, null) * 100);
                }
                return "";
            }
        }
        public string color
        {
            get
            {
                Type type = Data.GetType();
                PropertyInfo info = type.GetProperty("color");
                PropertyInfo info2 = type.GetProperty("zcolor");
                if (info != null)
                {
                    return info.GetValue(Data, null);
                }
                else if (info2 != null)
                {
                    return info2.GetValue(Data, null);
                }
                return "";
            }
        }
        public string clarity
        {
            get
            {
                Type type = Data.GetType();
                PropertyInfo info = type.GetProperty("clarity");
                PropertyInfo info2 = type.GetProperty("zclarity");
                if (info != null)
                {
                    return Convert.ToString(info.GetValue(Data, null));
                }
                else if (info2 != null)
                {
                    return Convert.ToString(info2.GetValue(Data, null));
                }
                return "";
            }
        }
        public string cut
        {
            get
            {
                Type type = Data.GetType();
                PropertyInfo info = type.GetProperty("cut");
                PropertyInfo info2 = type.GetProperty("zcut");
                if (info != null)
                {
                    return Convert.ToString(info.GetValue(Data, null));
                }
                else if (info2 != null)
                {
                    return Convert.ToString(info2.GetValue(Data, null));
                }
                return "";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getDisplay(string type)
        {
            ProTypeBll ptbll = new ProTypeBll();
            ProductBLL pbll = new ProductBLL();

            if (type == "handsize")
            {
                if (!(pbll.IsDarryRing(Convert.ToInt32(Data.productTypeId)) || pbll.IsPhonics(Convert.ToInt32(Data.productTypeId)) || pbll.IsMan(Convert.ToInt32(Data.productTypeId))))
                {
                    return " style=\"display:none\"";
                }
            }
            else if (type == "fontstyle")
            {
                if (!(pbll.IsDarryRing(Convert.ToInt32(Data.productTypeId)) || pbll.IsPhonics(Convert.ToInt32(Data.productTypeId)) || pbll.IsMan(Convert.ToInt32(Data.productTypeId))))
                {
                    return " style=\"display:none\"";
                }
            }
            else if (type == "diamond")
            {
                if (!(pbll.IsDarryRing(Convert.ToInt32(Data.productTypeId))))
                {
                    return " style=\"display:none\"";
                }
            }
            return string.Empty;
        }
    }
}