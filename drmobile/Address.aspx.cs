using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Common;

namespace drmobile
{
    /// <summary>
    ///  跳转到本页面中 两个可选参数 
    ///  ReturnUrl ：从执行跳转页面的链接
    ///  Type：地址管理时的 状态标识  若 Type=Choose 则提供选择功能
    /// </summary>
    public partial class Address : System.Web.UI.Page
    {
        public string ReturnUrl { get; set; }
        public string Type { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = CurrentUser.CurrentUid;
            this.ReturnUrl = Request["retrunPage"];
            this.Type=Request["Type"];
          
        }

    }
}
