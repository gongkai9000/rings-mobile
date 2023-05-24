<%@ Page Title="" Language="C#" MasterPageFile="~/master/mSite.Master" AutoEventWireup="true"
    CodeBehind="diamondring_list.aspx.cs" Inherits="drmobile.diamondring_list" %>

<%@ Register Src="/muc/Paging.ascx" TagName="ucPaging" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta name="Description" content="CTloves唯爱诺珠宝官网提供CTloves钻戒价格和钻石戒指图片款式介绍，CTloves真爱戒指寓意一生唯一真爱，男士一生只能买一次的钻戒，给心爱的她最珍贵的承诺！" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--购买资格查询-->
    <div class="zg_search">
        <!--<img alt="True Love系列 奢华款" src="mimages/ct_cp/dring_banner.jpg" />-->


        
             
                <!--验证-->
                <div class="yzpb_cort toyz_begin">

            <a href="brand.aspx" class="thelove_zs">
            <img src="/mimages/ctloves_sm3-truelove.jpg" alt="i love ctloves">
			</a>                 
                    
                </div>
                <!--验证end-->
                
          



        <div class="searchit sp_searchit">
            <a href="/help.aspx"><span>钻戒购买流程</span> </a><a href="/ctyz.aspx" class="noborder"><span>
                CT专属查询</span> </a>
        </div>
    </div>
    <!--购买资格查询end-->
   <!--全部系列-->
    <div class="whrite-cort fix">
        <a href="/diamondring_list.aspx" runat="server" id="all">全部系列</a> <a href="/diamonctringforever_list.aspx?typeid=12"
            runat="server" id="forever">Forever系列</a> <a href="/diamonctringmyheart_list.aspx?typeid=11"
                runat="server" id="myheart">My Heart系列</a> <a href="/diamonctringiswear_list.aspx?typeid=15"
                    runat="server" id="swear">I Swear系列</a>  <a href="/diamonctringtruelove_list.aspx?typeid=16"
                            runat="server" id="truelove">True Love系列</a><a href="/diamondringPrincess_list.aspx?typeid=17"
                                 runat="server" id="just">Princess系列</a>
    </div>
    <!--全部系列end-->
    <!--粉色区域内-->
    <div class="pink-cort">
        <!--608区域内-->
        <div class="spwidth_608">
            <div id="wrapper" style="padding-top:50px">
                
                <div>

           <!--Myheart系列start-->
           <div class="zbk_center">
            	<!--banner左边-->
            	<div class="zbkc-left">
                	<h5>True Love系列</h5>
                    <p></p><div>
	<p>
		真爱的纯净像一片片的雪花</p>
</div>
<div>
	<p>
		起点和终点都是你 </p>
</div>
<p></p>


                    <div class="mbdr_cp-img">
                                    <a href="/ctring_detail.aspx?id=399">
                                        <img alt="True Love系列 经典款" src="http://www.ctloves.com/nimages/ct_product/mTrueLove2.png" >
                                    </a>
                     </div>



                    <div class="button">
                        <div class="bt2" id="Div4"><span><a href="/ctyz.aspx" target=_blank>购买资格查询</a></span></div>

                        <div class="bt1"><a href="/ctring_detail.aspx?id=399" target="_blank">立即购买此款</a></div>
            		</div>
                </div> 
                <!--banner右边的背景图-->
               
            </div>

           <!--Myheart系列end-->
                
                
    
                
                <ul class="mbdr_cp fix" id="p_ctloves">
                    <asp:Repeater ID="rp_product" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="mbdr_cp-img">
                                    <a href="ctring_detail.aspx?id=<%#Eval("id")%>">
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
               CTloves求婚钻戒男士凭身份证购买，一生仅能定制一枚。</p>
            <img src="mimages/ct_cp/lct.png" />
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
                $.get("/API/ProductList2.ashx?type=<%=Request["type"]??"16" %>",{ "cmd": "ctloves", "top": count * 10 }, function (data) {
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
