﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;

namespace DRM.Common
{

    /// <summary>
    /// JSON序列化和反序列化辅助类
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// JSON序列化
        /// </summary>
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        /// <summary>
        /// JSON反序列化
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }

        public static T Json2ModelJS<T>(string JsonStr)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            T userJson = jss.Deserialize<T>(JsonStr);
            return userJson;
        }

        public static string Model2JsonJS<T>(T model)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string userJson = jss.Serialize(model);
            return userJson;
        }
    }
}
