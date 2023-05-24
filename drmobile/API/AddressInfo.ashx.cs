using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using DRM.Common;
using DRM.BLL;
using DRM.Entity;

namespace drmobile.API
{
    /// <summary>
    /// AddressInfo 的摘要说明
    /// </summary>
    public class AddressInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            string json = string.Empty;
            if (action == "province")
            {
                json = GetProvince();
            }
            else if (action == "city")
            {
                json = GetCity(context.Request.QueryString["code"]);
            }
            else if (action == "district")
            {
                json = GetDistrict(context.Request.QueryString["code"]);
            }
            else if (action == "getbyid")
            {
                json = GetAddressById(Convert.ToInt32(context.Request.QueryString["id"]));
            }
            else if (action == "save")
            {
                T_SpAddress address = SpAddressBLL.GetAddressById(Convert.ToInt32(context.Request.Form["ID"]));

                setData(address, context);

                SpAddressBLL.UpdateAddress(address);
                json = "{\"id\":"+address.SpAddressId+" }";
            }
            else if (action == "add")
            {
                T_SpAddress address = new T_SpAddress();
                address.MemberId = CurrentUser.CurrentUid;
                setData(address, context);
                SpAddressBLL.AddAdess(address);
                json = "{\"id\":" + address.SpAddressId + " }";
            }
            else if (action == "delete")
            {
                SpAddressBLL.Delete(Convert.ToInt32(context.Request.QueryString["id"]));
            }

            context.Response.ContentType = "application/json";
            context.Response.Clear();
            context.Response.Write(json);
            context.Response.End();
        }

        private void setData(T_SpAddress address, HttpContext context)
        {
            address.SpAddressName = Convert.ToString(context.Request.Form["name"]);
            address.SpAddressCity = context.Request.Form["province"] + context.Request.Form["city"] + context.Request.Form["district"];
            address.SpAddressStreet = context.Request.Form["street"];
            address.SpAddressCode = context.Request.Form["postcode"];
            address.SpAddressMobile = context.Request.Form["mobile"];
            address.SpAddressPhone = context.Request.Form["telephone"];
            address.SpAddressDefault = Convert.ToBoolean(context.Request.Form["IsDefault"] == "checked" ? "true" : "false");
        }

        private string GetAddressById(int id)
        {
            T_SpAddress spAddres = SpAddressBLL.GetAddressById(id);
            AddressEntity addEntity = new AddressEntity();
            addEntity.id = spAddres.SpAddressId;
            addEntity.city = spAddres.SpAddressCity;
            addEntity.code = spAddres.SpAddressCode;
            addEntity.mobile = spAddres.SpAddressMobile;
            addEntity.phone = spAddres.SpAddressPhone;
            addEntity.name = spAddres.SpAddressName;
            addEntity.street = spAddres.SpAddressStreet;
            addEntity.IsDefault = spAddres.SpAddressDefault;
            return JsonHelper.JsonSerializer<AddressEntity>(addEntity);
        }

        private string GetProvince()
        {
            string province = "/Scripts/json-array-of-province.js";
            return LoadFile(province);
        }

        private string GetCity(string provinceCode)
        {
            string city = "/Scripts/json-array-of-city.js";
            string cityString = LoadFile(city);

            List<Address> cityList = JsonHelper.JsonDeserialize<List<Address>>(cityString);
            string provinceCodePrefix = provinceCode.Substring(0, 2);
            var data = cityList.Where(t => t.code.IndexOf(provinceCodePrefix) == 0).ToList();
            return JsonHelper.JsonSerializer<List<Address>>(data);
        }

        private string GetDistrict(string cityCode)
        {
            string district = "/Scripts/json-array-of-district.js";
            string districtString = LoadFile(district);
            List<Address> districtList = JsonHelper.JsonDeserialize<List<Address>>(districtString);
            string cityCodePrefix = cityCode.Substring(0, 4);
            var data = districtList.Where(t => t.code.IndexOf(cityCodePrefix) == 0).ToList();
            return JsonHelper.JsonSerializer<List<Address>>(data);
        }

        private string LoadFile(string path)
        {
            FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath(path), FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            string output = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return output;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Address
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class AddressEntity
    {
        public int id { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string phone { get; set; }
        public bool IsDefault { get; set; }
    }
}