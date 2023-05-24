using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;

namespace drmobile.muc
{
    public partial class RelatedInfo : System.Web.UI.UserControl
    {
        public view_product2 CurrentProduct { get; set; }

        private bool _isphonics = false;
        public bool IsPhonics {
            get { return _isphonics; }
            set { _isphonics = value; }
        }
        public view_product2 ManProduct { get; set; }
        public view_product2 WomanProduct { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucInfoview.IsPhonics = IsPhonics;
            ucInfoview.CurrentProduct = CurrentProduct;
            ucInfoview.ManProduct = ManProduct;
            ucInfoview.WomanProduct = WomanProduct;
        }
    }
}