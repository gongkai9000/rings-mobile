using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Entity;
using DRM.BLL.Order;
using DRM.Common;
using drmobile.master;
using DRM.BLL;

namespace drmobile
{
    public partial class MemberCenter : System.Web.UI.Page
    {
        public string LoginName {
            get {
                var m = CurrentUser.Member;
                if (!string.IsNullOrEmpty(m.email))
                {
                    return m.email;
                }
                else if (!string.IsNullOrEmpty(m.mobile))
                {
                    return m.mobile;
                }
                else
                {
                    return m.nickname ?? "";
                }
            }
        }

        public string base64UID {
            get {
                return Base64Helper.Base64Encrypt(Convert.ToString(CurrentUser.CurrentUid));
            }
        }

        public int CartCount
        {
            get;
            set;
        }
        //public int OrderCount
        //{
        //    get;
        //    set;
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            //OrderBLL orderBll = new OrderBLL();
            //var data = orderBll.GetOrderByStatus(CurrentUser.CurrentUid, OrderStatus.Status.未处理);
            //orderRepeater.DataSource = data;
            //orderRepeater.DataBind();
            (Master as nSite).CurrentHeader = "个人中心";
            this.Title = "个人中心";
            (Master as nSite).PanelClass = " nopadding";

            CartBLL cbll = new CartBLL();
            CartCount = cbll.GetCartCount(CurrentUser.CurrentUid);
            //OrderBLL obll = new OrderBLL();
            //OrderCount = obll.GetOrderCountByMember(CurrentUser.CurrentUid);
        }
    }
}