<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="drmobile.muc.header" %>
<!--头部-->
<header>
    <i class="iconfont cl_nav fl">&#xe617;</i>
    <a href="/" class="logo_href"><img src="/mimages/logo.png" alt="Darry Ring官网" /></a>
    <a href="/Cart.aspx" class="iconfont shopcart havething fr">&#xe60c;<%if (CartCount > 0)
                  { %>
                <i><%=CartCount%></i>
                <%} %></a>
    <a href="<%= UrlStr %>" class="iconfont member fr" rel="nofollow" id="IsLogin">&#xe600;</a>
</header>
<!--头部end-->
<!--侧导航-->
<div class="allnav_left">
	<div class="theclose">
		<img src="/mimages/close.png" />
	</div>
	<a href="/brand.aspx">品牌文化</a>
    <a href="/pzgy.aspx">品质工艺</a>
    <a href="/mstartlist.aspx">明星见证</a>
    <a href="/fansshow.aspx">真爱至上</a>
    <a href="/shop.aspx">实体店铺</a>
    <a href="/news/center.aspx">资讯中心</a>
	<a href="javascript:NTKF.im_openInPageChat()">在线咨询</a>
	<a href="/MemberCenter.aspx" class="allnav_left-mb">
		<span class="iconfont member">&#xe600;</span><%=DRM.Common.CurrentUser.IsLogin ? DRM.Common.CommonFun.LoginName : "尚未登录"%>
	</a>
</div>
<!--侧导航end-->
<!--阴影背景-->
<div class="bk_gray"></div>
<!--阴影背景end-->
<script language="javascript" type="text/javascript">
    NTKF_PARAM = {
        siteid: "kf_9883",                            //Ntalker提供平台基础id,
        settingid: "kf_9883_1402631963601",          //Ntalker分配的缺省客服组id  
        uid: "<%=UserID %>",                                //用户id
        uname: "<%=NickName %>",                     //用户名              
        orderid: "",                     //订单id
        orderprice: "",                        //订单价格
    }
</script>
<script type="text/javascript" src="http://dl.ntalker.com/js/xn6/ntkfstat.js?siteid=kf_9883" charset="utf-8"></script>