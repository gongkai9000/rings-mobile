using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;
using DRM.Common.OCS;

namespace DRM.Common
{
    public class MemcachedObject
    {
        private MemcachedClient MClient { get; set; }
        private int DefaultExpires = 60 * 60;

        public MemcachedObject()
        {
            MClient = MemCached.getInstance();
        }

        public object this[string key]
        {
            get
            {
                return Convert.ToString(MClient.Get(key));
            }
            set
            {
                Set(key, value);
            }
        }

        public bool TryGet(string key,out object value)
        {
            return MClient.TryGet(key, out value);
        }

        public void Set(string key, object value)
        {
            Set(key, value, DefaultExpires);
        }
        public void Set(string key, object value, int seconds)
        {
            bool bl = MClient.Store(Enyim.Caching.Memcached.StoreMode.Set, (key), value, DateTime.Now.AddSeconds(seconds));
        }

        public bool Remove(string key)
        {
            return MClient.Remove(key);
        }
    }
}
