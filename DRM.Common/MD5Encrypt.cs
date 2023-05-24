using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DRM.Common
{
    public  class MD5Encrypt
    {
        public string MD5Enc(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string str = null;

            str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(myString, "md5");
            str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
            return str;
        }
    }
}
