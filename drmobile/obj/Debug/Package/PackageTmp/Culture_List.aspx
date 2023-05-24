<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true"
    CodeBehind="Culture_List.aspx.cs" Inherits="drmobile.Culture_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>品牌文化列表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--返回选项-->
    <div class="fhx">
        <a href="javascript:history.go(-1);">返回</a> <span>品牌文化</span>
    </div>
    <!--banner-->
    <div class="banner">
        <img src="images/3.jpg" />
    </div> 
    <!--列表-->
    <ul class="list">
        <li><span>></span> <a href="BrandStoryList.aspx">品牌故事</a> </li>
        <%--<li><span>></span> <a href="#">体验中心</a> </li>--%>
        <li><span>></span> <a href="Media_List.aspx">媒体报道</a> </li>
        <%--<li><span>></span> <a href="#">CTloves社区</a> </li>--%>
       <li class="special_ring"><span>></span> <a href="Contact.aspx">联系我们</a> </li>
    </ul>
</asp:Content>
