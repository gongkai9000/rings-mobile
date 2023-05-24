using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;

namespace drmobile.muc
{
    public partial class newslist : System.Web.UI.UserControl
    {
        public int PageSize { get; set; }
        public List<T_ProposeNews> NewsList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            rpNewsList.DataSource = NewsList ?? new List<T_ProposeNews>();
            rpNewsList.DataBind();
        }

        public string getstyle(int index)
        {
            if (index == NewsList.Count-1)
            {
                return " style=\"border:none\"";
            }
            return string.Empty;
        }
    }
}