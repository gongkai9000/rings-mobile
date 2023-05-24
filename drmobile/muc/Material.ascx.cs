using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;

namespace drmobile.muc
{
    public partial class Material : System.Web.UI.UserControl
    {
        public int ProductID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductBLL pBll = new ProductBLL();
            var data = pBll.getMaterial(ProductID);
            rpMaterial.DataSource = data;
            rpMaterial.DataBind();
        }
    }
}