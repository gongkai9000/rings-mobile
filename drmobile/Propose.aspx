<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="Propose.aspx.cs" Inherits="drmobile.Propose" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--返回选项-->
<div class="fhx">
	<%--<a href="index_list.aspx">返回</a>
    <span>求婚指南</span>--%>
    <a href="javascript:history.go(-1);">返回</a>
    <span>求婚指南</span>
</div>
<!--banner-->
<div class="banner">
	<img src="images/forever.jpg"/>
</div>
<!--列表-->
<ul class="list">
	<li>
		<span>></span>
		<a href="ProposeList.aspx?classId=3">求婚常识</a>
	</li>
	<li>
		<span>></span>
		<a href="ProposeList.aspx?classId=4">求婚创意</a>
	</li>
	<li>
		<span>></span>
		<a href="ProposeList.aspx?classId=1">真爱故事</a>
	</li>
    <%--暂无求婚墙功能！--%>
	<%--<li>
		<span>></span>
		<a href="LoveWall_List.aspx">求婚墙</a>
	</li>--%>
</ul>
</asp:Content>
