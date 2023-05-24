using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;

namespace drmobile.muc
{
    public partial class infoview : System.Web.UI.UserControl
    {
        public bool IsPhonics { get; set; }
        public view_product2 CurrentProduct { get; set; }
        public view_product2 ManProduct { get; set; }
        public view_product2 WomanProduct { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}