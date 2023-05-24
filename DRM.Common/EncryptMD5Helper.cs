using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DRM.Common
{
    public class Encrypt
    {
        /// <summary>
        /// 与JAVA统一的MD5方法
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string MD5Java(string source)
        {
            return MD5Java(source, "UTF-8");
        }
        public static string MD5Java(string source, string charset)
        {
            return MD5Java(Encoding.GetEncoding(charset).GetBytes(source));
        }
        /// <summary>
        /// 与JAVA统一的MD5方法
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string MD5Java(byte[] source)
        {
            StringBuilder result = new StringBuilder();
            using (var md5 = MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(source);
                for (int i = 0; i < bytes.Length; i++)
                {
                    string hex = bytes[i].ToString("X");
                    if (hex.Length == 1)
                    {
                        result.Append("0");
                    }
                    result.Append(hex);
                }
            }
            return result.ToString();
        }


    }
}
