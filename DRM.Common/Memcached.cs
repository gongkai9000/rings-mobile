using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using System.Net;
using Enyim.Caching.Memcached;
using System.Configuration;

namespace DRM.Common.OCS
{
    public sealed class MemCached
    {
        public static readonly string address = ConfigurationManager.AppSettings["memcachedAddress"];
        public static readonly int port = Convert.ToInt32(ConfigurationManager.AppSettings["memcachedPort"]);

        private static MemcachedClient MemClient;
        static readonly object padlock = new object();
        //线程安全的单例模式
        public static MemcachedClient getInstance()
        {
            if (MemClient == null)
            {
                lock (padlock)
                {
                    if (MemClient == null)
                    {
                        MemClientInit();
                    }
                }
            }
            return MemClient;
        }

        static void MemClientInit()
        {
            //初始化缓存
            MemcachedClientConfiguration memConfig = new MemcachedClientConfiguration();
            //IPAddress newaddress = Dns.GetHostAddresses("58ed864c30a94586.m.cnszalist3pub001.ocs.aliyuncs.com")[0]; //your_instanceid替换为你的OCS实例的ID
            IPAddress newaddress = Dns.GetHostAddresses(address)[0];

            IPEndPoint ipEndPoint = new IPEndPoint(newaddress, port);

            // 配置文件 - ip
            memConfig.Servers.Add(ipEndPoint);
            // 配置文件 - 协议
            memConfig.Protocol = MemcachedProtocol.Binary;
            // 配置文件-权限
            //memConfig.Authentication.Type = typeof(PlainTextAuthenticator);
            //memConfig.Authentication.Parameters["zone"] = "";
            ////memConfig.Authentication.Parameters["userName"] = "58ed864c30a94586";
            ////memConfig.Authentication.Parameters["password"] = "Wang169_";
            //下面请根据实例的最大连接数进行设置
            //memConfig.SocketPool.MinPoolSize = 1;
            //memConfig.SocketPool.MaxPoolSize = 200;
            
            MemClient = new MemcachedClient(memConfig);
        }

    }
}

