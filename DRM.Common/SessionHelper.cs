using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
//using System.Web.SessionState;

namespace DRM.Common
{
    /// <summary>
    /// session Helper
    /// </summary>
    public class SessionHelper
    {
        public SessionHelper()
        {
        }

        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="key"></param> 
        /// <param name="value"></param>
        public static void SetSession(string key, object value)
        {
            //HttpContext.Current.Session.Add(key, value);
            MemcacheSession session = new MemcacheSession();
            session.Set(key, value);
        }

        /// <summary>
        /// 设置Session,分钟
        /// </summary>
        /// <param name="key"></param> 
        /// <param name="value"></param>
        public static void SetSession(string key, object value,int timeout)
        {
            //HttpContext.Current.Session.Add(key, value);
            //HttpContext.Current.Session.Timeout = timeout;
            MemcacheSession session = new MemcacheSession();
            session.Set(key, value, timeout);
        }

        /// <summary>
        /// 根据session 的键 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetSession(string key)
        {
            MemcacheSession session = new MemcacheSession();
            return session[key];
        }
        /// <summary>
        /// 根据key 来获取Session
        /// </summary>
        /// <param name="key"></param>
        /// <returns>string类型</returns>
        public static string GetSessionStr(string key)
        {
            MemcacheSession session = new MemcacheSession();
            return Convert.ToString(session[key]);
        }

        /// <summary>
        /// 清除Session
        /// </summary>
        /// <param name="key"></param>
        public static void ClearSession(string key)
        {
            //HttpContext.Current.Session.Remove(key);
            MemcacheSession session = new MemcacheSession();
            session.Remove(key);
        }

    }
}
