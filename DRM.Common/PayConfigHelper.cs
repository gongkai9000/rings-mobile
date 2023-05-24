using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DRM.Common
{
    /// <summary>
    /// 银联在线支付config
    /// </summary>
   public class PayConfigHelper
    {
        public string _merchantId { set; get; }
        public string _frontUrl { set; get; }
        public string _backUrl { set; get; }
        public string _title { set; get; }
        public string _publickeyurl { set; get; }
        public string _privatekeyurl { set; get; }
        public string _orderid { set; get; }
    
    }
}
