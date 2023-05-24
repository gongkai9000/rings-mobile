using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;

namespace drmobile.muc
{
    public partial class PhonicsMaterial : System.Web.UI.UserControl
    {
public int ManProductID { get; set; }
        public int WomanProductID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductBLL pBll = new ProductBLL();
            var mandata = pBll.getMaterial(ManProductID);
            var womandata = pBll.getMaterial(WomanProductID);
            List<PMaterial> pmList = new List<PMaterial>();
            foreach (DRM.Entity.Material m in mandata)
            {
                PMaterial pm = new PMaterial() { 
                    Name = m.name,
                    ManPrice = m.price.Value
                };
                pmList.Add(pm);
            }
            try
            {
                foreach (DRM.Entity.Material m in womandata)
                {
                    pmList.Single(t => t.Name == m.name).WomanPrice = m.price.Value;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "alert('对戒中的男戒、女戒的可匹配材质不相同。');", true);
            }

            rpMaterial.DataSource = pmList;
            rpMaterial.DataBind();
        }
    }

    public class PMaterial
    {
        public string Name { get; set; }
        public decimal ManPrice { get; set; }
        public decimal WomanPrice { get; set; }
    }
    
}