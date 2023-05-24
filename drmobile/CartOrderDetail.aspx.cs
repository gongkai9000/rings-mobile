using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.BLL;
using DRM.Entity;
using DRM.Common;
using DRM.BLL.Order;

namespace drmobile
{
    public partial class CartOrderDetail : System.Web.UI.Page
    {
        #region 属性
        /// <summary>
        /// 地址ID
        /// </summary>
        public int AddressId
        {
            get;
            set;
        }

        /// <summary>
        /// 地址实体
        /// </summary>
        public T_SpAddress Address
        {
            get;
            set;
        }
        public bool IsDarry { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 设置addressid和address
            string addressid = Request.QueryString["addressid"];
            if (!string.IsNullOrEmpty(addressid))
            {
                AddressId = Convert.ToInt32(addressid);
                Address = SpAddressBLL.GetAddressById(AddressId);
            }
            else
            {
                Address = SpAddressBLL.GetDefaultAddress(CurrentUser.CurrentUid);
                if (Address == null)
                {
                    Response.Redirect("Address.aspx?retrunPage=CartOrderDetail.aspx&Type=Choose");
                   
                }
                //获取默认地址
                AddressId = Address.SpAddressId;
            }
            #endregion

            CartBLL cBll = new CartBLL();
            //是否是Darry求婚钻戒
            IsDarry = cBll.IsHaveDarry(cBll.GetCartByMemberId(CurrentUser.CurrentUid));
            protocol.Visible = IsDarry;
        }

        public string OrderAPIUrl { get {
            return OrderBLL.OrderCommandPage;
        } }
    }
}
