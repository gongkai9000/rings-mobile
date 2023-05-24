using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.BLL;
using DRM.Common;
using DRM.Entity;

namespace drmobile.Comment
{
    public partial class MyComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "我要评价";
            Title = "我要评价";
            nCommentBLL cbll = new nCommentBLL();
            int datacount = 0;

            List<view_ordercomment> ocList = new List<view_ordercomment>(); 
            if (string.IsNullOrEmpty(Request.QueryString["orderid"]))
            {
                ocList = cbll.getNoCommentOrder(CurrentUser.CurrentUid, int.MaxValue, 0, out datacount);
            }
            else
            {
                ocList = cbll.getNoCommentOrder(Request.QueryString["orderid"]);
            }
            if (ocList.Count == 0)
            {
                Server.Transfer("EmptyComment.aspx");
            }
            rpOrderDetail.DataSource = ocList;
            rpOrderDetail.DataBind();
        }
    }
}