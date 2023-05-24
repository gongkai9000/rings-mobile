using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;

namespace DRM.Common
{
    public class CookieHelper
    {
        public static readonly string CrossDomain = ConfigurationManager.AppSettings["crossdomain"];
        public CookieHelper()
        {
        }

        public static void ClearCookie()
        {
            int count = HttpContext.Current.Request.Cookies.Count;
            for (int i = 0; i < count; i++)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[i];
                cookie.Expires = DateTime.Now.AddDays(-1.0);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static void ClearCookie(string strName)
        {
            HttpCookie cookie = new HttpCookie(strName)
            {
                Expires = DateTime.Now.AddSeconds(-1.0)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void ClearCookieByDomain(string strName, string domain)
        {
            HttpCookie cookie = new HttpCookie(strName)
            {
                Expires = DateTime.Now.AddSeconds(-1.0),
                Domain = domain
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void ClearCookieByDomain(string domain)
        {
            int count = HttpContext.Current.Request.Cookies.Count;
            for (int i = 0; i < count; i++)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[i];
                cookie.Domain = domain;
                cookie.Expires = DateTime.Now.AddDays(-1.0);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }


        public static string GetCookie(string strName)
        {
            //if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null))
            //{
            //    return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            //}
            //return "";

            HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies[strName];
            if (Cookie != null)
            {
                try
                {
                    return Base64Helper.Base64Decrypt(Cookie.Value.ToString());
                }
                catch (Exception ex)
                {
                    CommonFun.ClearCookieCompatible();
                }
            }
            return null;

        }

        /// <summary>
        /// Cookies赋值
        /// </summary>
        /// <param name="strName">主键</param>
        /// <param name="strValue">键值</param>
        /// <param name="strDay">有效天数</param>
        /// <returns></returns>
        public static bool setCookie(string strName, string strValue, int strDay)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                //Cookie.Domain = ".xxx.com";//当要跨域名访问的时候,给cookie指定域名即可,格式为.xxx.com
               // Cookie.Domain = ".darryring.com";

                Cookie.Expires = DateTime.Now.AddDays(strDay);
                Cookie.Value = Base64Helper.Base64Encrypt(strValue);
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cookies赋值
        /// </summary>
        /// <param name="strName">主键</param>
        /// <param name="strValue">键值</param>
        /// <param name="strDay">有效天数</param>
        /// <returns></returns>
        public static bool setCookie(string strName, string strValue)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                //Cookie.Domain = ".xxx.com";//当要跨域名访问的时候,给cookie指定域名即可,格式为.xxx.com
                // Cookie.Domain = ".darryring.com";

                //Cookie.Expires = DateTime.Now.AddDays(strDay);
                Cookie.Value = Base64Helper.Base64Encrypt(strValue);
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cookies赋值
        /// </summary>
        /// <param name="strName">主键</param>
        /// <param name="strValue">键值</param>
        /// <param name="strDay">有效天数</param>
        /// <returns></returns>
        public static bool setCookieCrossDomain(string strName, string strValue, int strDay)
        {
            try
            {

                HttpCookie Cookie = new HttpCookie(strName);
                //Cookie.Domain = ".xxx.com";//当要跨域名访问的时候,给cookie指定域名即可,格式为.xxx.com
                Cookie.Domain = CrossDomain;

                Cookie.Expires = DateTime.Now.AddDays(strDay);
                Cookie.Value = Base64Helper.Base64Encrypt(strValue);
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
