using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drmobile.muc
{
    public partial class Paging : System.Web.UI.UserControl
    {
        public string ClientObjectName
        {
            get;
            set;
        }
        /// <summary>
        /// 当前页数
        /// </summary>
        private int _currentPageNum = 1;
        public int CurrentPageNum
        {
            get { return _currentPageNum; }
            set
            {
                _currentPageNum = value;
            }
        }

        public string SrollControlID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //默认全局对象名
            ClientObjectName = string.IsNullOrEmpty(ClientObjectName) ? "__CurrentPaging" : ClientObjectName;
        }
    }
}