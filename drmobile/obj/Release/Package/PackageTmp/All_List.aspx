<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true"
    CodeBehind="All_List.aspx.cs" Inherits="drmobile.All_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>全部列表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--返回选项-->
    <div class="fhx">
        <a href="javascript:history.go(-1);">返回</a> <span>全部列表</span>
    </div>
    <!--列表-->
    <ul class="list">
        <li><span>></span> <a href="Index_List.aspx">首页</a> </li>
      <li><span>></span> <a href=" http://www.darryring.com/mobile/pink_index.aspx">稀世粉钻</a> </li>
        <li><span>></span> <a href="diamondring_list.aspx">求婚钻戒</a> </li>
        <li><span>></span> <a href="phonics_list.aspx">结婚对戒</a> </li>
        <li><span>></span> <a href="jewellery_list.aspx">珠宝饰品</a> </li>
        <li><span>></span> <a href="Culture_List.aspx">品牌文化</a> </li>
        <li><span>></span> <a href="Propose.aspx">求婚指南</a> </li>
        <li><span>></span> <a href="ProblemList.aspx">常见疑问</a> </li>
       <%-- <li><span>></span> <a href="#">体验中心</a> </li>--%>
       <li class="special_ring"><span>></span> <a href="Contact.aspx">联系我们</a> </li>
    </ul>
</asp:Content>
