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
    public partial class NewsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string typeid = Request.QueryString["typeid"];
            string tag = Request.QueryString["tag"];
            int skip = Convert.ToInt32(Request.QueryString["skip"]);
            if (!string.IsNullOrEmpty(typeid))
            {
                NewsBLL nbll = new NewsBLL();
                ucList.NewsList = nbll.getNewsByType(nbll.getChild(Convert.ToInt32(typeid)), skip, 8);
            }
            else
            {
                ucList.NewsList = ProposeBLL.getListByTagId(Convert.ToInt32(tag), skip, 8);
            }

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            ucList.RenderControl(writer);

            Response.Clear();
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}