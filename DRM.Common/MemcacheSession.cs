using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;
using DRM.Common.OCS;
using System.Configuration;


namespace DRM.Common
{
    public class MemcacheSession
    {
        public const string SessionToken = "__MSessionToken";
        public static readonly string AppKey = ConfigurationManager.AppSettings["appkey"];
        private string Token { get; set; }
        private MemcachedClient MClient { get; set; }
        private int DefaultExpires = 15;

        private void CreateSession()
        {
            string g = Guid.NewGuid().ToString();
            CookieHelper.setCookie(SessionToken, g);
            Token = g;
        }

        public MemcacheSession()
        {
            Token = CookieHelper.GetCookie(SessionToken);
            MClient = MemCached.getInstance();
        }

        public object this[string key]
        {
            get{
                if (string.IsNullOrEmpty(Token))
                {
                    return string.Empty;
                }
                return Convert.ToString(MClient.Get(AppKey + "__" + Token + "__" + key));
            }
            set{
                Set(key, value);
            }
        }

        public void Set(string key,object value)
        {
            Set(key, value, DefaultExpires);
        }
        public void Set(string key, object value, int minutes)
        {
            if (string.IsNullOrEmpty(Token))
            {
                CreateSession();
            }
            bool bl = MClient.Store(Enyim.Caching.Memcached.StoreMode.Set, (AppKey + "__" + Token + "__" + key), value, DateTime.Now.AddMinutes(minutes));
        }

        public bool Remove(string key)
        {
            return MClient.Remove(key);
        }
    }
}
