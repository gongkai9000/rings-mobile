using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DRM.Common
{
    public class WebConfig
    {
        /// <summary>
        /// 公司官网地址
        /// </summary>
        public static string CompWeb {
            get {
                return Convert.ToString(ConfigurationManager.AppSettings["compWeb"]);
            }
        }


        /// <summary>
        /// 图片服务器
        /// </summary>
        public static string ImgWeb
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["imgWeb"]);
            }
        }

        /// <summary>
        ///选择用户存储数据方式
        /// </summary>
        public static string Check
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["check"]);
            }
        }

        /// <summary>
        /// 银联在线支付密钥1
        /// </summary>
        public static string CHINA_PAY_PAY_KEY_PATH
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["CHINA_PAY_PAY_KEY_PATH"]);
            }
        }
        /// <summary>
        /// 银联在线支付密钥1
        /// </summary>
        public static string CHINA_PAY_QT_KEY_PATH
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["CHINA_PAY_QT_KEY_PATH"]);
            }
        }

        /// <summary>
        /// MyHeart系列钻戒心形钻
        /// </summary>
        public static readonly int MyHeart = 11;

        /// <summary>
        /// 粉钻Darry
        /// </summary>
        public static readonly int FenZuanDarry = 45;


        public static readonly int DarryRing = 1;

        /// <summary>
        /// 裸钻ID
        /// </summary>
        public static readonly int LZID = 9;

        /// <summary>
        /// 现货裸钻ID
        /// </summary>
        public static readonly int SpotLZID = 44;

        /// <summary>
        /// 文章类别:品牌动态 (Darryring动态)
        /// </summary>
        public static readonly int Pinpai = 47;

        /// <summary>
        /// 文章类别:求婚指南  (求婚相关)
        /// </summary>
        public static readonly int Qiuhun = 42;

        /// <summary>
        /// 文章类别:钻石百科
        /// </summary>
        public static readonly int ZuanshiBaike = 18;

        /// <summary>
        /// 文章类别:珠宝百科
        /// </summary>
        public static readonly int ZhubaoBaike = 22;

        
    }
}
