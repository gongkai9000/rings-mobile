using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.BLL;

namespace drmobile.CustomerService
{
    public partial class Detail : System.Web.UI.Page
    {
        public int Type { get { return Convert.ToInt32(Request.QueryString["type"]); } }
        public string Name
        {
            get
            {
                switch (Type)
                {
                    case 1:
                        return "官网店铺";
                        break;
                    case 2:
                        return "真爱疑问";
                        break;
                    case 3:
                        return "购买限制";
                        break;
                    case 4:
                        return "产品疑问";
                        break;
                    case 5:
                        return "关于定制";
                        break;
                    case 6:
                        return "关于运输";
                        break;
                    case 7:
                        return "关于售后";
                        break;
                }
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = Name;
            Title = Name;
            NewsBLL nbll = new NewsBLL();
            rpQuestion.DataSource = nbll.getComquestionByType(Type);
            rpQuestion.DataBind();
        }

    }
}