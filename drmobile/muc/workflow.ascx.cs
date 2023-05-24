using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;
using DRM.BLL;

namespace drmobile.muc
{
    public partial class workflow : System.Web.UI.UserControl
    {
        public WorkflowModel CurrentModel { get; set; }
        public Process CurrentProcess { get; set; }
        public List<view_cart> CartList = new List<view_cart>();
        protected string Url { get; set; }

        public string NextUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CartBLL cbll = new CartBLL();
            CurrentModel = cbll.IsHaveDarry(CartList) ? WorkflowModel.DarryRing : WorkflowModel.Other;
            if (CurrentModel != WorkflowModel.DarryRing)
            {
                wfDiv.Visible = false;
            }
            else
            {
                if (CurrentProcess == Process.Cart)
                {
                    Url = "/mimages/dr_cp/t1.jpg";
                }
                else if(CurrentProcess == Process.TrueLove)
                {
                    Url = "/mimages/dr_cp/t2.jpg";
                }
                else if (CurrentProcess == Process.Order)
                {
                    Url = "/mimages/dr_cp/t3.jpg";
                }
            }

            if (CurrentModel == WorkflowModel.DarryRing && CurrentProcess == Process.Cart)
            {
                NextUrl = "/TrueLove.aspx";
            }
            else if (CurrentModel == WorkflowModel.DarryRing && CurrentProcess == Process.TrueLove)
            {
                NextUrl = "/SubmitOrder.aspx";
            }
            else if (CurrentModel == WorkflowModel.DarryRing && CurrentProcess == Process.Order)
            {
                //NextUrl = "/SubmitOrder.aspx";
            }
            else if (CurrentModel == WorkflowModel.Other && CurrentProcess == Process.Cart)
            {
                NextUrl = "/SubmitOrder.aspx";
            }
            else if (CurrentModel == WorkflowModel.Other && CurrentProcess == Process.Order)
            {
                //NextUrl = "/SubmitOrder.aspx";
            }
        }
    }

    public enum Process { 
        Cart,
        TrueLove,
        Order
    }

    public enum WorkflowModel { 
        DarryRing,
        Other
    }
}