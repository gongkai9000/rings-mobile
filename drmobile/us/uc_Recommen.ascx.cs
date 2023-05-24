using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using DRM.Entity;
using DRM.BLL;

namespace drmobile.us
{
    //裸钻推荐自定义控件
    public partial class uc_Recommen : System.Web.UI.UserControl
    {
        ProductBLL dringbll = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataLoad();
        }


        private void DataLoad()
        {
            this.rp_product.DataSource = dringbll.GetList(1);
            this.rp_product.DataBind();
        }
    }
}