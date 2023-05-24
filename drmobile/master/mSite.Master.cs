using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace drmobile.master
{
    public partial class mSite : System.Web.UI.MasterPage
    {

        public Current CurrentClass { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreRender(object sender, EventArgs args)
        {
            // ProcessClass();
        }
        private void ProcessClass()
        {

            if (CurrentClass == Current.Brand)
            {
                brand.Attributes["class"] = "click-change";
            }
            else if (CurrentClass == Current.Darry)
            {
                darry.Attributes["class"] = "click-change";
            }
            else if (CurrentClass == Current.Jew)
            {
                jew.Attributes["class"] = "click-change";
            }
            else if (CurrentClass == Current.Activity)
            {
                activity.Attributes["class"] = "click-change";
            }
        }

    }
    public enum Current
    {
        Brand,
        Darry,
        Jew,
        Activity

    }
}