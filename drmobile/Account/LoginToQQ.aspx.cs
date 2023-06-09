﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QConnectSDK.Context;
using Framework.Common;
using DRM.Common;

namespace Web_Diamond.Account
{
    public partial class LoginToQQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new QzoneContext();
            string state = Guid.NewGuid().ToString().Replace("-", "");
            string scope = "get_user_info,add_share,list_album,upload_pic,check_page_fans,add_t,add_pic_t,del_t,get_repost_list,get_info,get_other_info,get_fanslist,get_idolist,add_idol,del_idol,add_one_blog,add_topic,get_tenpay_addr";
            var authenticationUrl = context.GetAuthorizationUrl(state, scope);
            //request token, request token secret 需要保存起来
            //在demo演示中，直接保存在全局变量中.真实情况需要网站自己处理
            MemcacheSession msession = new MemcacheSession();
            msession["requeststate"] = state;
            Response.Redirect(authenticationUrl);
        }
    }
}