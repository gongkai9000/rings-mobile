<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="MyAfterService.aspx.cs" Inherits="drmobile.MyAfterService" %>

<%@ Register Src="/muc/CommodityInfo.ascx" TagName="ucCommodityInfo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--所有产品-->
			<div class="all_detail">
				<!--产品-->
                <asp:Repeater runat="server" ID="rpOrderDetail">
                <ItemTemplate>
			
                    <div class="spwhrite cmain">
				        <div class="thecp_img detail_spimg fl">
					        <img src="<%#DRM.Common.ImageURLFormat.Format(Convert.ToString(Eval("imgurl"))) %>" />
				        </div>
				        <div class="thecp_word detail_spword fl">
					        <h3><%#Eval("title")%>[<%#Eval("productNo")%>]</h3>
					        <p><i>￥<%#Convert.ToDecimal(Eval("memberprice")).ToString("N0")%></i></p>
                            <uc1:ucCommodityInfo runat="server" id="ucCommodityInfo" Data="<%#GetDataItem() %>"></uc1:ucCommodityInfo>
					        <p><span><%#Eval("addtime") %></span></p>
                            <div class="detail_but sqdetail">
							        <a href="<%#getBtnUrl(GetDataItem() as DRM.Entity.view_orderdetailAfterservice)%>"><%#getBtnText(GetDataItem() as DRM.Entity.view_orderdetailAfterservice)%></a>
						        </div>
				        </div>
                        <div class="iconfont right_position">&#xe605;</div>
			        </div>
                </ItemTemplate>
                </asp:Repeater>
             </div>
             
</asp:Content>
