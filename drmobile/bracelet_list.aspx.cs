using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DRM.Entity;
using DRM.BLL;

namespace drmobile
{
    public partial class bracelet_list : System.Web.UI.Page
    {
        ProductBLL dringbll = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataLoad();
        }


        private void DataLoad()
        {
            this.rp_product.DataSource = dringbll.GetList(7);
            this.rp_product.DataBind();
        }
    }
}