<%@ Page Title="" Language="C#" MasterPageFile="~/master/mSite.Master" AutoEventWireup="true"
    CodeBehind="phonics2_list.aspx.cs" Inherits="drmobile.phonics_list" %>

<%@ Register Src="/muc/Paging.ascx" TagName="ucPaging" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<%--    <meta name="Description" content="CTloves官网,每位男士凭身份证一生限定制一枚的求婚钻戒，求婚钻戒第一品牌，购求婚钻戒签定真爱协议、专属页面，一生唯一真爱钻戒品牌" />--%>
<%--    <meta name="Keywords" content="CT（CTloves）,钻石,钻戒,真爱钻戒,用身份证购买的钻戒,结婚钻戒,钻石价格,钻戒价格,钻石戒指,情侣戒指，送女友礼物" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--购买资格查询-->
    <div class="zg_search">
        <img alt="真爱信物-对戒" src="mimages/duijie_banner.svg" />
        <div class="searchit">
            <a href="/diamondring_list.aspx" class="noborder"><span>去选购求婚钻戒</span> </a>
        </div>
    </div>
    <!--购买资格查询end-->
    <!--全部系列-->
    <div class="whrite-cort djwhrite-cort fix">
        <a href="/phonics_list.aspx" class="<%=GetClass(0)%>">全部</><a href="/phonics_manring_list.aspx?type=2 " class="<%=GetClass(2)%>">
                男戒</a><a href="/phonics_duijiering_list.aspx?type=3"class="<%=GetClass(3) %>">对戒</a>  <!--<a href="/phonics_list.aspx?type=4" class="<%=GetClass(4)%>">吊坠</a> <a href="/phonics_list.aspx?type=5"
                    class="<%=GetClass(5)%>">项链</a> <a href="/phonics_list.aspx?type=8" class="<%=GetClass(8)%>">
                        手链</a> <a href="/phonics_list.aspx?type=6" class="<%=GetClass(6)%>">耳环</a>-->
    </div>
    <!--全部系列end-->
    <!--粉色区域内-->
    <div class="pink-cort">
        <!--608区域内-->
        <div class="spwidth_608">
            <div id="wrapper" style="padding-top:50px">
                <div>
                <ul class="mbdr_cp fix" id="p_ctloves">
                    <asp:Repeater ID="rp_product" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="mbdr_cp-img">
                                    <a href="<%#GetURL(Eval("productTypeId")) %>?id=<%#Eval("id") %>">
                                        <img alt="<%#Eval("title") %>" src="<%#Eval("imgurl") %>" width="140" height="140" />
                                    </a>
                                </div>
                                <div class="mbdr_cp-word">
                                    <p class="hsp-height">
                                        <%#Eval("title") %></p>
                                    <p>
                                        <span class="fl">￥<%#string.Format("{0:N0}", Eval("MemberPrice"))%></span><%--<i class="fr">销量：<%#Eval("salecount")%></i>--%></p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <!--查看更多-->
                <div class="checkmore" id="pullUp">
                    <p>加载中，请稍候</p>
                    <span></span>
                </div>
                <!--查看更多end-->
                </div>
            </div>
        </div>
        <!--608区域内end-->
        </div>
        <!--返回顶部-->
        <div class="iconfont fh_top">
            &#xe601;</div>
        <!--返回顶部end-->
        <!--产品列表-->
        <script src="/mjs/fhdb.js" type="text/javascript"></script>
        <script type="text/javascript">
            var count = 2;
            var status = 0;
            var CommentLoadEvent = function () { };
            function CommentLoadData(currentPageNum) {
                $.get("/API/ProductList.ashx?type=<%=Request["type"]??"0" %>",{ "cmd": "jew", "top": count * 10 }, function (data) {
                    if (data == "s") {
                    }
                    else {

                        $("#p_ctloves").append(data);
                        __CurrentPagingProduct.CurrentPageNum = currentPageNum;
                        count += 1;
                        status = 0;
                    }
                    __CurrentPagingProduct.LoadComplete();
                });
            }
            $(function () {
                __CurrentPagingProduct.CustomChanged = function (num) {
                    CommentLoadData(num);
                };
            });
        </script>
        <uc1:ucPaging runat="server" ID="ucPaging" ClientObjectName="__CurrentPagingProduct" SrollControlID="wrapper"></uc1:ucPaging>
</asp:Content>
