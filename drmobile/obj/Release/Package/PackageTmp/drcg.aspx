﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="drcg.aspx.cs" Inherits="drmobile.drcg" %>

<%@ Import Namespace="DRM.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>已经购买过DR戒指-Darry Ring官网</title>
    <script type="text/javascript" src="mjs/TouchSlide.1.1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--验证的消息-->
    <div class="dryz_newbk">
        <!--购买过-->
        <div class="dryz-buy">
            <p class="hmargin">
                <span>
                    <%=HttpUtility.HtmlDecode(Request["name"]) %></span> 的Darry Ring已经赠出</p>
            <p>
                钻戒绑定爱人姓名:
                <%=HttpUtility.HtmlDecode(Request["gName"]) %></p>
            <p>
                钻戒定制日期：
                <%=HttpUtility.HtmlDecode(Request["date"]) %></p>
            <p>
                以上Darry Ring绑定信息终生不可更改</p>
        </div>
        <!--购买过end-->
    </div>
    <!--验证的消息end-->
    <!--查看专属页面-->
    <div class="look_other">
        <a href="http://home.darryring.com/index.php/index/index/mid/<%=Base64Helper.Base64Encrypt(HttpUtility.HtmlDecode(Request["id"]??"MQ==")) %>">
            查看专属页面</a>
    </div>
    <!--查看专属页面end-->
    <!--600区域内-->
    <div class="spwidth_600 the_line">
        <!--产品左右滑动-->
        <div id="slideBox3" class="slideBox">
            <div class="bd">
                <ul>
                    <li>
                        <div class="cp_img fl">
                            <img src="/mimages/dr_yz/5.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                DR对戒My heart系列 简约对戒</p>
                            <p>
                                <span>￥5980</span></p>
                            <a href="/phonics_details.aspx?id=328" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                    <li>
                        <div class="cp_img fl">
                            <img src="/mimages/dr_yz/6.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                DR对戒Forever系列 挚爱对戒</p>
                            <p>
                                <span>￥4860</span></p>
                            <a href="/phonics_details.aspx?id=365" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                    <li>
                        <div class="cp_img fl">
                            <img src="mimages/dr_yz/7.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                               DR男戒 勇者男戒 10分H色</p>
                            <p>
                                <span>￥6556</span></p>
                            <a href="/manring_detail.aspx?id=369" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                    <li>
                        <div class="cp_img fl">
                            <img src="mimages/dr_yz/8.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                DR男戒 天骄男戒 15分H色</p>
                            <p>
                                <span>￥7400</span></p>
                            <a href="/manring_detail.aspx?id=368" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                </ul>
            </div>
            <span class="img_pre spimg_pre"></span><span class="img_next spimg_next"></span>
        </div>
        <!--产品左右滑动end-->
        <div class="more_cp">
            <a href="/phonics_list.aspx">选购更多对戒饰品</a>
        </div>
        <script type="text/javascript" src="/mjs/TouchSlide.1.1.js"></script>
        <script type="text/javascript">
            TouchSlide({
                slideCell: "#slideBox3",
                titCell: ".hd ul", //开启自动分页 autoPage:true ，此时设置 titCell 为导航元素包裹层
                mainCell: ".bd ul",
                effect: "leftLoop",
		        autoPlay:true, //自动播放
		        interTime:4000
            });
        </script>
</asp:Content>
