using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using drmobile.master;

namespace drmobile
{
    public partial class mactivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as mSite).CurrentClass = Current.Activity;
            this.Title = "CTloves真爱戒指最新活动_CTloves官网";
            if (!IsPostBack)
            {
                BindData();

            }
        }

        private void BindData()
        {
            rptlist.DataSource = new ActivityBll().GetActivities(t => true, 2);
            rptlist.DataBind();
        }
    }
}