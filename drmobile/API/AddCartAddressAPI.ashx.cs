using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRM.Entity;
using DRM.Common;
using DRM.BLL;
using System.Web.SessionState;

namespace drmobile.API
{
    /// <summary>
    /// AddCartAddressAPI 的摘要说明
    /// </summary>
    public class AddCartAddressAPI : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";          
                CreateAddress(context);   
        }
        /// <summary>
        /// 验证添加信息
        /// </summary>
        /// <param name="context"></param>
        private static void CreateAddress(HttpContext context)
        {
            string city = context.Request["city"];
            string street = context.Request["street"];
            string code = context.Request["code"];
            string tel = context.Request["tel"];
            string rido = context.Request["rido"];
            string name = context.Request["name"];

            if (name == null)
            {
                context.Response.Write("name");
            }
            if (city == null)
            {
                context.Response.Write("city");
            }
            if (street == null)
            {
                context.Response.Write("street");
            }

            ///创建用户收货信息
            Address(context, city, street, code, tel, name);


        }

        /// <summary>
        /// 添加用户收货信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="code"></param>
        /// <param name="tel"></param>
        private static void Address(HttpContext context, string city, string street, string code, string tel, string name)
        {
            T_SpAddress model = new T_SpAddress();
            model.SpAddressCity = city;
            model.SpAddressStreet = street;
            model.SpAddressCode = code;
            model.SpAddressName = name;
            model.SpAddressMobile = tel;
            model.MemberId = CurrentUser.CurrentUid;
            model.SpAddressDefault = false;
            //跟新用户所有的收货地址都不勾选
            // bool res = SpAddressBLL.UpdateStatus(CurrentUser.CurrentUid);
            bool r = SpAddressBLL.AddAdess(model);
            if (r)
            {
                context.Response.Write("true");
            }
            else
            {
                context.Response.Write("false");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
