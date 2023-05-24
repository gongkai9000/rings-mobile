<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="drmobile.news.detail" %>

<%@ Register Src="/muc/newslist.ascx" TagName="ucNewslist" TagPrefix="uc1" %>
<%@ Register Src="/muc/website.ascx" TagName="ucWebsite" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="Description" content="戴瑞Darry Ring是求婚钻戒的领导品牌，同时提供大量关于DR族的相关资讯知识介绍，想查询DR族的问题或者想了解DR族的价格、图片、款式、评价等问题都可以选择戴瑞Darry Ring官网。" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:ucWebsite runat="server" ID="ucwebsite"></uc1:ucWebsite>
	<!--文章-->
	<div class="zx_actricle">
		<h1><%=CurrentNews.ProposeNewsTitle%></h1>
		<%=CurrentNews.ProposeNewsContent %>
	</div>
	<!--文章end-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">
</asp:Content>
