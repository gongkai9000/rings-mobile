using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using DRM.BLL.Order;
using DRM.Entity;

namespace drmobile.us
{
    public partial class us_OrderList : System.Web.UI.UserControl
    {
        public string OrderID { get; set; }

        public List<view_orderdetail> OrderList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            detailRepeater.DataSource = OrderList;
            detailRepeater.DataBind();
        }

        /// <summary>
        /// 图片路径转换
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected string ImageURLFormat(string url)
        {
            return DRM.Common.ImageURLFormat.Format(url);
        }
    }
}