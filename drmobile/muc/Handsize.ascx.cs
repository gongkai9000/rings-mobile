using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;

namespace drmobile.muc
{
    public partial class Handsize : System.Web.UI.UserControl
    {
        public string UControlID { get; set; }

        public string HandsizePriceJSVar { get; set; }

        public int PID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UControlID = string.IsNullOrEmpty(UControlID) ? "defaultHandsizeID" : UControlID;
            HandsizePriceJSVar = string.IsNullOrEmpty(HandsizePriceJSVar) ? "CurrentHandsizePrice" : HandsizePriceJSVar;

            rpHandsize.DataSource = new HandSizeBll().GetSizeGroupList(PID);
            rpHandsize.DataBind();
        }

    }
}