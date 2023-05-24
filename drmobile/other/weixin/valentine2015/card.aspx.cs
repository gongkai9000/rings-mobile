using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using DRM.Entity;

namespace drmobile.other.weixin.valentine2015
{
    public partial class card : System.Web.UI.Page
    {
        public string msgfrom { get; set; }
        public string msgto { get; set; }
        public string content { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            msgfrom = Request.QueryString["msgfrom"];
            msgto = Request.QueryString["msgto"];
            content = Request.QueryString["content"];
        }
    }
}