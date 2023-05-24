using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DRM.BLL;
using DRM.Common;
using DRM.Entity;

namespace drmobile.API
{
    public partial class DiamondAPI : System.Web.UI.Page
    {
        public int ProductID
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["pid"]);
            }
        }
        protected view_product2 CurrentProduct { get; set; }

        int PageSize = 4;
        protected void Page_Load(object sender, EventArgs e)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            ProductBLL pBll = new ProductBLL();
            CurrentProduct = pBll.GetProduct(ProductID);

            int pageindex = Convert.ToInt32(Request.QueryString["pagenum"]) - 1;
            string orderby = string.Empty;

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            foreach (string k in Request.QueryString.Keys)
            {
                list.Add(new KeyValuePair<string, string>(k, Request.QueryString[k]));
            }
            int datacount;

            int lzid = WebConfig.LZID;
            if (Request.QueryString["isSpot"] == "false")
            {
                lzid = WebConfig.LZID;
            }
            else if (Request.QueryString["isSpot"] == "true")
            {
                lzid = WebConfig.SpotLZID;
            }

            rpDiamond.DataSource = pBll.getDiamonds(lzid, list, PageSize, pageindex, out datacount);
            rpDiamond.DataBind();
            rpDiamond.RenderControl(writer);

            int pagenum = datacount / PageSize + (datacount % PageSize == 0 ? 0 : 1);

            Response.Clear();
            Response.Write("<script>var ZSSearchDataCount = " + datacount + ";var ZSSearchPageCount = " + pagenum + ";</script>");
            Response.Write(sw.ToString());
            Response.End();
        }

        public decimal GetProductPrice(decimal dprice)
        {
            decimal mprice = Convert.ToDecimal(Request.QueryString["mprice"]);
            decimal zdprice = dprice  * (CurrentProduct.znumber??0);
            decimal fdprice = (CurrentProduct.fDiamondPrice ??0) * (CurrentProduct.fnumber ?? 0);
            return mprice + zdprice + fdprice;
        }
        public string GetCurrentMaterial()
        {
            return Request.QueryString["Material"];

        }
    }
}