﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true"
    CodeBehind="earrings_list.aspx.cs" Inherits="drmobile.earrings_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>耳钉/耳环列表-CTloves-求婚钻戒领导品牌-唯爱诺珠宝官网</title>
<%--    <meta name="Description" content=" CTloves官网,每位男士凭身份证一生限定制一枚的求婚钻戒，求婚钻戒第一品牌，购求婚钻戒签定真爱协议、专属页面，一生唯一真爱钻戒品牌" />
    <meta name="Keywords" content="CT（CTloves）,钻石,钻戒,真爱钻戒,用身份证购买的钻戒,结婚钻戒,钻石价格,钻戒价格,钻石戒指,情侣戒指，送女友礼物" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--返回选项-->
    <div class="fhx">
        <a href="javascript:history.go(-1)">返回</a> <span>耳钉/耳环</span>
    </div>
    <!--banner-->
    <div class="banner">
        <img src="images/erh.jpg" />
    </div>
    <!--产品列表-->
    <div class="all_bk">
        <ul class="all_thing">
            <asp:Repeater ID="rp_product" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="thing_top">
                            <a href="jewellery_detail.aspx?type=''&&id=<%#Eval("ProductId") %>">
                                <img src="<%#Eval("imgurl") %>" width="121" height="130" /></a>
                        </div>
                        <div class="thing_bottom">
                            <p>
                                <%#DRM.Common.StringHelper.SubString(Eval("Title").ToString(),8) %></p>
                            <span>￥<%#Eval("MemberPrice")%>.00</span>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
