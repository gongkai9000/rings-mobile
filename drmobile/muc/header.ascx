<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="drmobile.muc.header" %>
<!--头部-->
<header>
    <i class="iconfont cl_nav fl">&#xe617;</i>
    <a href="/" class="logo_href"><img src="/mimages/logo.svg" alt="CTloves官网" /></a>
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
    
    <a href="/fansshow.aspx">真爱至上</a>
    
    <a href="/news/center.aspx">资讯中心</a>
	<a href="">在线咨询</a>
	<a href="/MemberCenter.aspx" class="allnav_left-mb">
		<span class="iconfont member">&#xe600;</span><%=DRM.Common.CurrentUser.IsLogin ? DRM.Common.CommonFun.LoginName : "尚未登录"%>
	</a>
</div>
<!--侧导航end-->
<!--阴影背景-->
<div class="bk_gray"></div>
<!--阴影背景end-->
