<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="jewellery_list.aspx.cs" Inherits="drmobile.jewellery_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>珠宝饰品列表-CTloves-求婚钻戒领导品牌-唯爱诺珠宝官网</title>
<%--    <meta name="Description" content="CTloves官网,每位男士凭身份证一生限定制一枚的求婚钻戒，求婚钻戒第一品牌，购求婚钻戒签定真爱协议、专属页面，一生唯一真爱钻戒品牌" />
    <meta name="Keywords" content="CT（CTloves）,钻石,钻戒,真爱钻戒,用身份证购买的钻戒,结婚钻戒,钻石价格,钻戒价格,钻石戒指,情侣戒指，送女友礼物" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--返回选项-->
<div class="fhx">
	<a href="index_list.aspx">返回</a>
    <span>珠宝饰品</span>
</div>
<!--banner-->
<div class="banner">
	<img src="images/jewely.jpg"/>
</div>
<!--列表-->
<ul class="list">
	<li>
		<span>></span>
		<a href="manr_list.aspx">男戒系列</a>
	</li>
	<li>
		<span>></span>
		<a href="necklace_list.aspx">项链/吊坠</a>
	</li>
	<li>
		<span>></span>
		<a href="earrings_list.aspx">耳钉/耳环</a>
	</li>
	<li class="special_ring">
		<span>></span>
		<a href="bracelet_list.aspx">手链/手镯</a>
	</li>
</ul>
</asp:Content>
