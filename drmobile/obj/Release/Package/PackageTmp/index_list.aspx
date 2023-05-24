<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true"
    CodeBehind="index_list.aspx.cs" Inherits="drmobile.index_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <title>全部商品-Darry Ring-求婚钻戒领导品牌-戴瑞珠宝官网</title>
<%--<meta name="Description" content=" DarryRing官网,每位男士凭身份证一生限定制一枚的求婚钻戒，求婚钻戒第一品牌，购求婚钻戒签定真爱协议、专属页面，一生唯一真爱钻戒品牌"/>
<meta name="Keywords" content="DR（DarryRing）,钻石,钻戒,真爱钻戒,用身份证购买的钻戒,结婚钻戒,钻石价格,钻戒价格,钻石戒指,情侣戒指，送女友礼物" />--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--轮播-->
    <div class="main">
        <ul class="content">
            <li>
                <img src="images/3.jpg" /></li>
            <li>
                <img src="images/jewely.jpg" /></li>
            <li>
                <img src="images/erh.jpg" /></li>
            <li>
                <img src="images/3.jpg" /></li>
        </ul>
        <ul class="num">
            <li class="on"></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
    </div>
    <!--列表-->
    <ul class="list">
       <li><span>></span> <a href=" http://www.darryring.com/mobile/pink_index.aspx">稀世粉钻</a> </li>
        <li><span>></span> <a href="diamondring_list.aspx">求婚钻戒</a> </li>
        <li><span>></span> <a href="phonics_list.aspx">结婚对戒</a> </li>
        <li><span>></span> <a href="jewellery_list.aspx">珠宝饰品</a> </li>
    </ul>
    <!--展示-->
    <div class="show">
        <a href="IsBuyDarry.aspx">
            <img src="images/ty.jpg" width="50%" class="fl" />
        </a><a href="Propose.aspx">
            <img src="images/qh.jpg" width="50%" class="fl" />
        </a><a href="diamondring_list.aspx">
            <img src="images/zj.jpg" width="100%" />
        </a>
    </div>
    <!--验证等-->
    <ul class="t_it">
        <li><span>></span> <a href="IsBuyDarry.aspx">DR验证查询</a> </li>
        <li><span>></span> <a href="DiaNousList.aspx">购钻知识</a> </li>
        <li class="b_none"><span>></span> <a href="ProblemList.aspx">常见疑问</a> </li>
    </ul>
    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="Scripts/all_same.js"></script>
    <script type="text/javascript" src="Scripts/banner.js"></script>
</asp:Content>
