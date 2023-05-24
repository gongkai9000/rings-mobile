using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DRM.Entity
{
    public  class ProductDetail
    {
        /// <summary>
        /// 产品标题 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 带参数产品标题
        /// </summary>
        public string strTitle { get; set; }
        /// <summary>
        /// 产品分类Id
        /// </summary>
        public string ClassId { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 推荐裸钻Id
        /// </summary>
        public string DProductId { get; set; }
        /// <summary>
        /// 产品展示图片1
        /// </summary>
        public string imgurl1 { get; set; }
        /// <summary>
        /// 产品展示图片2
        /// </summary>
        public string imgurl2 { get; set; }
        /// <summary>
        /// 产品展示图片3
        /// </summary>
        public string imgurl3 { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string caizhi { get; set; }
        /// <summary>
        /// 手寸大小
        /// </summary>
        public string Fontsize { get; set; }
        /// <summary>
        /// 产品价格
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 戒托价格
        /// </summary>
        public string RingPrice { get; set; }
        /// <summary>
        /// 裸钻价格
        /// </summary>
        public string Lzmemberprice { get; set; }
        /// <summary>
        /// 默认裸钻价格
        /// </summary>
        public string DiamondPrice { get; set; }
        /// <summary>
        /// 刻字
        /// </summary>
        public string Kz { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string PCode { get; set; }
        /// <summary>
        /// 重量（克拉）
        /// </summary>
        public string Ct { get; set; }
        /// <summary>
        /// 净度
        /// </summary>
        public string Clarity { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 切工
        /// </summary>
        public string Cut { get; set; }
        /// <summary>
        /// 描述内容
        /// </summary>
        public string Pcontent { get; set; }
        /// <summary>
        /// 证书类型
        /// </summary>
        public string Cert_type { get; set; }
        /// <summary>
        /// 证书编号
        /// </summary>
        public string cert_no { get; set; }
        /// <summary>
        /// 金重
        /// </summary>
        public string Jinct { get; set; }
    }

}
