using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using DRM.Entity;
using DRM.BLL;
using System.Web.UI;
using Framework.Common;
using System.Net;
using System.IO;

namespace DRM.Common
{
    public class CommonFun
    {
        /// <summary>
        /// 是否预计发货时间20天的
        /// </summary>
        /// <returns></returns>
        public static bool Is20Day(int ptid,int pid)
        {
            ProTypeBll ptbll = new ProTypeBll();
            var ptlist = ptbll.GetChidlTypeList(WebConfig.MyHeart).Select(t => t.id).ToList();
            var plist = new List<int>();
            plist.Add(340);
            plist.Add(342);

            if (ptlist.Contains(ptid) || plist.Contains(pid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取当前登录的uId
        /// 存在 则返回 uid
        /// 不存在 则返回 0标识为不存在
        /// </summary>
        public static int CurrentUserID
        {
            get
            {
                if (!string.IsNullOrEmpty(CookieHelper.GetCookie("uid")))
                {
                    return Convert.ToInt32(CookieHelper.GetCookie("uid"));
                }
                else
                {
                    return 0;
                }
            }
        }

        public static string LoginName
        {
            get
            {
                var m = CurrentUser.Member;
                string result = string.Empty;
                if (!string.IsNullOrEmpty(m.email))
                {
                    result = m.email;
                }
                else if (!string.IsNullOrEmpty(m.mobile))
                {
                    result = m.mobile;
                }
                else
                {
                    result = m.nickname ?? "";
                }
                return result;
            }
        }

        ///// <summary>
        ///// 是否登录
        ///// </summary>
        ///// <returns></returns>
        //public static bool IsLogin
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(CookieHelper.GetCookie("uid")))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        /// <summary>
        /// 获取Ip
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
           // string ip = string.Empty;
           // ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
           // switch (ip)
           // {
           //     case null:
           //         break;
           //     case "":
           //         ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
           //         break;
           // }
           // if ((ip == null) || (ip == string.Empty))
           // {
           //     ip = HttpContext.Current.Request.UserHostAddress;
           // }
           // if (!(((ip != null) && (ip != string.Empty)) && IsIP(ip)))
           // {
           //     return "0.0.0.0";
           // }
           // return ip;
           //return WebRequest.GetIP();
            return HttpContext.Current.Request.UserHostAddress;
        }
        /// <summary>
        /// 判断是否为Ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }





        public static void UpdateUser(T_Member model, int UserTypeId)
        {
            if (model.loginlock.ToString() == "0" || model.loginlock.ToString() == "")
            {
                model.lastlogin = DateTime.Now;
                model.lastip = GetIp();
                CurrentUser.UpdateUser(model,UserTypeId);
            }
            else
            {
                JSAlertAndRedirect("帐号已锁定!", "/");
            }

        }

        public static void JSAlertAndRedirect(string content, string url)
        {
            HttpContext.Current.Response.Write(string.Format("<script type=\"text/javascript\">alert('{0}');location.href='{1}'</script>", content.Replace("'", "''"), url));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获取指定长度的 字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStr(Object str, int length)
        {
            string str1 = "";
            if (str == null)
            {
                return "";
            }
            else
            {
                str1 = str.ToString();
            }
            if (str1.Length <= 0)
            {
                return "";
            }
            else if (str1.Length < length)
            {
                return str1;

            }
            else
            {
                return str1.Substring(0, length) + "...";
            }
        }

        /// <summary>
        /// 向浏览器端返回数据
        /// </summary>
        /// <param name="data"></param>
        public static void ResponseData(string data, bool isEnd)
        {
            //HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(data);
            if (isEnd)
            {
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 向浏览器端返回数据
        /// </summary>
        /// <param name="data"></param>
        public static void ResponseJSON(string data, bool isEnd)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            ResponseData(data, isEnd);
        }

        /// <summary>
        /// 显示页面消息
        /// </summary>
        /// <param name="p"></param>
        public static void ShowInfoMsg(Page p, string msg)
        {
            p.ClientScript.RegisterClientScriptBlock(p.GetType(), "show", "w.Show('" + msg + "')", true);
        }

        public static void ClearCookieCompatible()
        {
            CookieHelper.ClearCookieByDomain("m.darryring.com");
        }

      

    }

 

}

