using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DRM.Common
{
    public class ImageURLFormat
    {
        public static string Format(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (url.Contains(Common.WebConfig.ImgWeb))
                {
                    //UpYunImageServer
                    return url;
                }
                else
                {
                    //CompWebServer
                    return Common.WebConfig.CompWeb + url;
                }
            }
            return url;
        }

    }

    public enum ImageUrlType
    { 
        /// <summary>
        /// 图片存在官网web服务器，链接为相对路径，类似于：/userfiles/……
        /// </summary>
        CompWebServer,
        /// <summary>
        /// 图片存在Upyun服务器，链接为绝对路径，为：img.darryring.com...
        /// </summary>
        UpYunImageServer
    }
}
