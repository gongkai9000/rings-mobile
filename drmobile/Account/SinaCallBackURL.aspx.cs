using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DRM.Common;
using NetDimension.Weibo;
using System.Configuration;
using DRM.BLL;
using DRM.Entity;
using NetDimension.Web;

namespace drmobile.Account
{
    public partial class SinaCallBackURL : System.Web.UI.Page
    {
        NetDimension.Web.Cookie cookie = new NetDimension.Web.Cookie("WeiboDemo", 24, TimeUnit.Hour);
        Client Sina = null;
        OAuth oauth = new OAuth(ConfigurationManager.AppSettings["sinaAppKey"], ConfigurationManager.AppSettings["sinaAppSecret"], ConfigurationManager.AppSettings["sinaCallbackUrl"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            Sina = new Client(oauth); //用cookie里的accesstoken来实例化OAuth，这样OAuth就有操作权限了
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                {
                    var token = oauth.GetAccessTokenByAuthorizationCode(Request.QueryString["code"]);
                    string accessToken = token.Token;
                    cookie["AccessToken"] = accessToken;
                    //Session["SinaOpenid"] = Sina.API.Entity.Account.GetUID();

                    T_Member model = new T_Member();
                    string sinauid = Sina.API.Entity.Account.GetUID();
                    model = MemberBLL.GetMemberbySineid(sinauid);

                    if (model != null)
                    {
                        //CurrentUser.UpdateUser(model, 0);
                        CommonFun.UpdateUser(model, 0);
                    }
                    else
                    {
                        string nickname = Sina.API.Entity.Users.Show(sinauid).Name;
                        T_Member regm = new T_Member();
                        regm.nickname = nickname;
                        regm.addtime = DateTime.Now;
                        regm.regip = CommonFun.GetIp();
                        regm.lastip = CommonFun.GetIp();
                        regm.lastlogin = DateTime.Now;
                        regm.SinaOpenId = Sina.API.Entity.Account.GetUID();

                        MemberBLL.Add(regm);

                        //CurrentUser.UpdateUser(regm, 0);
                        CommonFun.UpdateUser(regm, 0);
                    }
                }
            }

             
                Response.Redirect("/MemberCenter.aspx");
             
        }
    }
}