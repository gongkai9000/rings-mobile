using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using drmobile.master;
using DRM.BLL;
using DRM.Common;
using DRM.Entity;

namespace drmobile
{
    public partial class TrueLove : System.Web.UI.Page
    {
        public view_cart DarryCart { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as nSite).CurrentHeader = "真爱协议";
            Title = "真爱协议";
            (Master as nSite).PanelClass = " nopadding";

            CartBLL cbll = new CartBLL();
            var data = cbll.GetViewCartByMemberId(CurrentUser.CurrentUid);

            DarryCart = cbll.getDarryInCart(data);

            if (DarryCart == null)
            {
                DarryCart = new view_cart();
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "alert('购物车为空，或购物车中没找到DarryRing求婚钻戒');window.location='/Cart.aspx';", true);
                return;
            }

            List<DropDownEntity> yearList = new List<DropDownEntity>();
            for (int i = DateTime.Now.Year; i >= 1930; i--)
            {
                yearList.Add(new DropDownEntity(i.ToString(), i.ToString()));
            }
            //yearList.Single(t => t.Text == "1990").Attribute = "selected=\"selected\"";

            List<DropDownEntity> monthList = new List<DropDownEntity>();
            for (int i = 1; i <= 12; i++)
            {
                monthList.Add(new DropDownEntity(i.ToString(), i.ToString()));
            }

            rpDate1Year.DataSource = yearList;
            rpDate2Year.DataSource = yearList;
            rpDate3Year.DataSource = yearList;

            rpDate1Month.DataSource = monthList;
            rpDate2Month.DataSource = monthList;
            rpDate3Month.DataSource = monthList;

            this.Page.DataBind();

            ucWorkflow.CartList = data;
            ucWorkflow.CurrentProcess = muc.Process.TrueLove;
        }
    }

    public class DropDownEntity {
        public DropDownEntity(string text, string value)
        {
            Text = text;
            Value = value;
        }
        public DropDownEntity(string text, string value,string attribute)
        {
            Text = text;
            Value = value;
            Attribute = attribute;
        }
        public string Text { get; set; }
        public string Value { get; set; }
        public string Attribute { get; set; }
    }
}
