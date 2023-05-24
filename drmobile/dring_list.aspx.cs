using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DRM.BLL;
using DRM.Entity;
using DRM.Common;

namespace drmobile
{
    /// <summary>
    /// 产品详情页面
    /// </summary>
    public partial class dring_list : System.Web.UI.Page
    {
        public T_Product pmodel;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id =Request.QueryString["id"].ToString();
            if (id == null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                DataLoad(id);
            }
        }
       
        private void DataLoad(string strid)
        {
            int id = Convert.ToInt32(strid);
             pmodel = new T_Product();
            ProductBLL productbll = new ProductBLL();
            if (id > 0)
            {
                view_product2 pmodel = productbll.GetProduct(id);
                if (pmodel != null)
                {    
                    this.txt_title.InnerText = pmodel.title.ToString();
                }
            }
        }
    }
}