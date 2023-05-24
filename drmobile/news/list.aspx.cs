using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using drmobile.master;
using System.IO;
using DRM.Entity;

namespace drmobile.news
{
    public partial class list : System.Web.UI.Page
    {
        public List<T_ArticleType> AtList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "资讯中心";

            string typeid = Request.QueryString["typeid"];
            string tag = Request.QueryString["tag"];

            string t = string.Empty;
            if (!string.IsNullOrEmpty(typeid))
            {
                t = ProposeBLL.GetProTypeById(Convert.ToInt32(typeid)).title;
            }
            else
            {
                t = ProposeBLL.getTagwordById(Convert.ToInt32(tag)).SEOTitle;
            }
            Context.Items.Add("pagetitle", t);

            Title = t + " - CTloves唯爱诺珠宝官网";

            AtList = new List<T_ArticleType>(); 

            //分类列表
            if (!string.IsNullOrEmpty(typeid))
            {
                NewsBLL nbll = new NewsBLL();
                ucList.NewsList = nbll.getNewsByType(nbll.getChild(Convert.ToInt32(typeid)), 15);

                AtList = nbll.getChildAt(Convert.ToInt32(typeid));

                //如果没有子分类，则显示平级分类
                if (AtList.Count == 0)
                {
                    AtList = nbll.getListByPID(ProposeBLL.GetProTypeById(Convert.ToInt32(typeid)).pid.Value);
                }
                rpClass.DataSource = AtList;
                rpClass.DataBind();
            }
            //tag列表
            else
            {
                ucList.NewsList = ProposeBLL.getListByTagId(Convert.ToInt32(tag), 15);
            }

            if (AtList.Count == 0)
            {
                divClass.Visible = false;
            }
        }

        public string GetClass(int index,int id)
        {
            if (id == Convert.ToInt32(Request.QueryString["typeid"]))
            {
                return " class=\"zx_click\"";
            }
            if (index == AtList.Count - 1)
            {
                return "";
            }
            return string.Empty;
        }
    }
}