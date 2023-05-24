using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Common;
using QConnectSDK;
using QConnectSDK.Models;
using DRM.Entity;
using DRM.Common;
using DRM.BLL;
namespace Web_Diamond11
{
    public partial class dr_QQCallBackURL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MemcacheSession msession = new MemcacheSession();
                if (Request.Params["code"] != null && msession["requeststate"] != null)
                {
                    QOpenClient qzone = null;
                    User currentUser = null;

                    var verifier = Request.Params["code"];
                    string state = msession["requeststate"].ToString();
                    qzone = new QOpenClient(verifier, state);
                    currentUser = qzone.GetCurrentUser();

                    //Framework.Common.Cookie.WriteCookie("QzoneOauth",qzone.ToString());
                    string openid = qzone.OAuthToken.OpenId;

                    if (null != currentUser)
                    {
                        T_Member model = new T_Member();
                        model = MemberBLL.GetMemberbyQQid(openid);

                        if (model != null)
                        {
                            ////cs.Member.UpdateUser(dr, 0);
                            //CurrentUser.UpdateUser(model, 0);
                            CommonFun.UpdateUser(model, 0);
                        }
                        else
                        {
                            T_Member regm = new T_Member();
                            regm.nickname = currentUser.Nickname;
                            regm.addtime = DateTime.Now;
                            regm.regip = CommonFun.GetIp();
                            regm.lastip = CommonFun.GetIp();
                            regm.lastlogin = DateTime.Now;
                            regm.QQOpenId = openid;

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
}