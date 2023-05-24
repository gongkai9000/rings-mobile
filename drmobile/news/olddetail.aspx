<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="olddetail.aspx.cs" Inherits="drmobile.news.olddetail" %>

<%@ Register Src="/muc/newslist.ascx" TagName="ucNewslist" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="Description" content="CTlovesCTloves是求婚钻戒的领导品牌，同时提供大量关于CTloves族的相关资讯知识介绍，想查询CTloves族的问题或者想了解CTloves族的价格、图片、款式、评价等问题都可以选择CTlovesCTloves官网。" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<!--文章-->
	<div class="zx_actricle">
		<h1><%=CurrentDetail.title%></h1>
		<%=CurrentDetail.content%>
	</div>
	<!--文章end-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">
</asp:Content>
