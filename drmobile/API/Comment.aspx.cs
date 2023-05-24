using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using System.IO;

namespace drmobile.API
{
    public partial class Comment1 : System.Web.UI.Page
    {
        public int ProductID
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["pid"]);
            }
        }
        public int PageSize
        {
            get
            {
                return 10;
            }
        }

        public int PageIndex
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["pagenum"]) - 1;
            }
        }

        public int DataCount { get; set; }

        public int PageCount
        {
            get
            {
                return DataCount / PageSize + (DataCount % PageSize == 0 ? 0 : 1);
            }
        }

        nCommentBLL cBll = new nCommentBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            int dCount;

            rpComment.DataSource = cBll.getList(ProductID, PageSize, PageIndex, out dCount);
            DataCount = dCount;
            rpComment.DataBind();

            rpComment.RenderControl(writer);

            Response.Clear();
            Response.Write("<script>var CommentDataCount = " + DataCount + ";var CommentPageCount = " + PageCount + ";</script>");
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}