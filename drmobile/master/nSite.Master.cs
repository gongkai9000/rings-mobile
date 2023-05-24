using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace drmobile.master
{
    public partial class nSite : System.Web.UI.MasterPage
    {
        public string CurrentHeader { set; get; }
        public string PanelClass { get; set; }

        private string _isShowbackdefaultpage = "none";
        public string IsShowBackDefaultPage
        {
            get {
                return _isShowbackdefaultpage;
            }
            set {
                _isShowbackdefaultpage = value;
            }
        }

        [DefaultValue(true)]
        public bool IsGray
        {
            get;
            set;
        }
        protected string FirstPanelClass { get; set; }

        /// <summary>
        /// 是否有包括底部的背景图
        /// </summary>
        public bool IsBGImg { get; set; }

        /// <summary>
        /// 包括底部的背景图的URL
        /// </summary>
        public string BGImgUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsGray)
            {
                FirstPanelClass = "gray-cort";
            }
        }

        protected void Page_Init(object sender, EventArgs args)
        {
            IsGray = true;
        }

        protected void Page_PreRender(object sender, EventArgs args)
        {
            hea.InnerText = CurrentHeader;
        }
    }
}