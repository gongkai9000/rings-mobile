﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;

namespace drmobile.Comment
{
    public partial class EmptyComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "我的评价（空）";
            Title = "我的评价（空）";
        }
    }
}