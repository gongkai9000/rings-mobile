using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRM.Entity;
using System.Web;
using DRM.BLL;

namespace DRM.Common
{
    public class CurrentUser
    {
        /// <summary>
        /// 获取用户的Id 
        /// 若存在 则返回uid
        /// 不存在 则 返回
        /// </summary>
        public static int CurrentUid
        {
            get
            {
                if (WebConfig.Check == "session")
                {
                    return SessionUser.CurrentUid;
                }
                else if (WebConfig.Check == "cookie")
                {
                    return CookieUser.CurrentUid;
                }

                return 0;

            }
        }

        public static T_Member Member {
            get {
               return MemberBLL.GetMemberById(CurrentUser.CurrentUid);
            }
        }

        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin
        {
            get
            {
                if (WebConfig.Check == "session")
                {
                    return SessionUser.IsLogin;
                }
                else if (WebConfig.Check == "cookie")
                {
                    return CookieUser.IsLogin;
                }
                return false;
            }
        }


        public static void UpdateUser(T_Member member, int userTypeId)
        {
            //if (WebConfig.Check == "session")
            //{
            //    SessionUser.UpdateUser(member, userTypeId);
            //}
            //else if (WebConfig.Check == "cookie")
            //{
                CookieUser.UpdateUser(member, userTypeId);
            //}

        }

    }

    /// <summary>
    /// 用户Session
    /// </summary>
    public class SessionUser
    {

        /// <summary>
        /// 获取当前用户的userId  
        /// 若存在 则返回 用户Id 
        /// 不存在 则返回 整型0
        /// </summary>
        public static int CurrentUid
        {
            get
            {
                if (!string.IsNullOrEmpty(SessionHelper.GetSessionStr("uid")))
                {
                    return Convert.ToInt32(SessionHelper.GetSessionStr("uid"));
                }
                else
                {
                    HttpContext.Current.Response.Redirect("/Account/Login.aspx?returnUrl=" + HttpContext.Current.Request.Url.ToString());
                    return 0;
                }
            }

        }


        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin
        {
            get
            {
                if (!string.IsNullOrEmpty(SessionHelper.GetSessionStr("uid")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取当前用户的Session 为 用户实体模型
        /// 若存在 则 返回对象实体 
        /// 若不存在 则 返回 null
        /// </summary>
        public static T_Member CurrentUser
        {
            get
            {
                if (SessionHelper.GetSession("user") != null)
                {
                    return SessionHelper.GetSession("user") as T_Member;

                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 将用户Id写进Session中 
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userId">用户Id</param>
        public void SetUid(string key, int userId)
        {
            SessionHelper.SetSession(key, userId);
        }

        /// <summary>
        /// 给用户添加 Session
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="member">实体对象</param>
        public static void SetUser(string key, T_Member member)
        {
            SessionHelper.SetSession(key, member);
        }

        /// <summary>
        /// 更新UserSession 中的数据
        /// </summary>
        /// <param name="member">实体对象</param>
        /// <param name="userTypeId"></param>
        public static void UpdateUser(T_Member member, int userTypeId)
        {
            SessionHelper.SetSession("user", member);
            SessionHelper.SetSession("uid", member.Id.ToString());
            SessionHelper.SetSession("email", HttpContext.Current.Server.UrlEncode(member.email));
            SessionHelper.SetSession("uname", HttpContext.Current.Server.UrlEncode(member.nickname));
            SessionHelper.SetSession("logintime", member.lastlogin.ToString());
            SessionHelper.SetSession("loginip", member.lastip);
            SessionHelper.SetSession("UserTypeId", userTypeId.ToString());
        }
    }

    /// <summary>
    /// 获取用户cookie信息
    /// </summary>
    public class CookieUser
    {
        /// <summary>
        /// 获取当前用户Id
        /// 若存在则 返回用户Id
        /// 若不存在 返回 0
        /// </summary>
        public static int CurrentUid
        {
            get
            {
                if (CookieHelper.GetCookie("uid") != null)
                {

                    return int.Parse(CookieHelper.GetCookie("uid"));


                }
                else
                {
                    HttpContext.Current.Response.Redirect("/Account/Login.aspx?returnUrl=" + HttpContext.Current.Request.Url.ToString());
                    return 0;
                }
            }
        }



        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin
        {
            get
            {
                if (!string.IsNullOrEmpty(CookieHelper.GetCookie("uid")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 更新用户cookie 
        /// </summary>
        /// <param name="member">用户实体对象</param>
        /// <param name="usertypeId">用户类型Id</param>
        public static void UpdateUser(T_Member member, int usertypeId)
        {
            CookieHelper.ClearCookie("uid");
            CookieHelper.ClearCookie("email");
            CookieHelper.ClearCookie("mobile");
            CookieHelper.ClearCookie("uname");
            CookieHelper.ClearCookie("logintime");
            CookieHelper.ClearCookie("loginip");
            CookieHelper.ClearCookie("UserTypeId");

            CookieHelper.setCookieCrossDomain("uid", member.Id.ToString(), 1);
            CookieHelper.setCookieCrossDomain("email", member.email, 1);
            CookieHelper.setCookieCrossDomain("mobile", member.mobile, 1);
            CookieHelper.setCookieCrossDomain("uname", member.nickname, 1);
            CookieHelper.setCookieCrossDomain("logintime", member.lastlogin.ToString(), 1);
            CookieHelper.setCookieCrossDomain("loginip", member.lastip, 1);
            CookieHelper.setCookieCrossDomain("UserTypeId", usertypeId.ToString(), 1);
        }
    }
}
