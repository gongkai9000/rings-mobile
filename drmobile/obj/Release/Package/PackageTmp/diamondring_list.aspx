<%@ Page Title="" Language="C#" MasterPageFile="~/master/mSite.Master" AutoEventWireup="true"
    CodeBehind="diamondring_list.aspx.cs" Inherits="drmobile.diamondring_list" %>

<%@ Register Src="/muc/Paging.ascx" TagName="ucPaging" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta name="Description" content="Darry Ring戴瑞珠宝官网提供Darry Ring钻戒价格和钻石戒指图片款式介绍，DR真爱戒指寓意一生唯一真爱，男士一生只能买一次的钻戒，给心爱的她最珍贵的承诺！" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--购买资格查询-->
    <div class="zg_search">
        <img alt="True Love系列 奢华款" src="mimages/dr_cp/dring_banner.jpg" />
        <div class="searchit sp_searchit">
            <a href="/help.aspx"><span>钻戒购买流程</span> </a><a href="/dryz.aspx" class="noborder"><span>
                DR专属查询</span> </a>
        </div>
    </div>
    <!--购买资格查询end-->
    <!--全部系列-->
    <div class="whrite-cort fix">
        <a href="/diamondring_list.aspx" runat="server" id="all">全部系列</a> <a href="/diamondring_list.aspx?typeid=12"
            runat="server" id="forever">Forever系列</a> <a href="/diamondring_list.aspx?typeid=11"
                runat="server" id="myheart">My Heart系列</a> <a href="/diamondring_list.aspx?typeid=15"
                    runat="server" id="swear">I Swear系列</a> <a href="/diamondring_list.aspx?typeid=13"
                        runat="server" id="just">Just You系列</a> <a href="/diamondring_list.aspx?typeid=16"
                            runat="server" id="truelove">True Love系列</a>
    </div>
    <!--全部系列end-->
    <!--粉色区域内-->
    <div class="pink-cort">
        <!--608区域内-->
        <div class="spwidth_608">
            <div id="wrapper" style="padding-top:50px">
                <div>
                <ul class="mbdr_cp fix" id="p_darryring">
                    <asp:Repeater ID="rp_product" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="mbdr_cp-img">
                                    <a href="dring_detail.aspx?id=<%#Eval("id")%>">
                                        <img alt="<%#Eval("title") %>" src="<%#Eval("imgurl") %>" width="140px" height="140px" />
                                    </a>
                                </div>
                                <div class="mbdr_cp-word">
                                    <p class="hsp-height">
                                        <%#DRM.Common.StringHelper.SubString(Eval("title").ToString(),20) %>&nbsp;<%#GetCtStr(Eval("zct"))%>&nbsp;<%#GetClolor(Eval("zcolor"))%></p>
                                    <p>
                                        <span class="fl">￥<%#string.Format("{0:N0}",Eval("MemberPrice"))%> </span><%--<i class="fr">销量：<%#Eval("salecount")%></i>--%>
                                    </p>
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
                </div>
                </div>
            </div>
        </div>
        
        <!--608区域内end-->

        <!--查看更多end-->
        <!--购买流程-->
        <div class="buy_lc">
            <h4>
                购买流程</h4>
            <p>
                Darry Ring求婚钻戒产品男士需凭身份证购买，一生仅能定制一枚。对戒及饰品需定制Darry Ring求婚钻戒后才可购买。</p>
            <img src="mimages/dr_cp/lct.png" />
        </div>
        <!--购买流程end-->
        <!--返回顶部-->
        <div class="iconfont fh_top">
            &#xe601;</div>
        <!--返回顶部end-->
        <script src="mjs/fhdb.js" type="text/javascript"></script>
        <script type="text/javascript">
            var count = 2;
            var status = 0;
            var CommentLoadEvent = function () { };
            function CommentLoadData(currentPageNum) {
                $.get("/API/ProductList.ashx?type=<%=Request["type"]??"1" %>",{ "cmd": "darryring", "top": count * 10 }, function (data) {
                    if (data == "s") {
                    }
                    else {

                        $("#p_darryring").append(data);
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
