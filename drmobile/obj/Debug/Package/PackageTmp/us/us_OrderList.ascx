<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="us_OrderList.ascx.cs" Inherits="drmobile.us.us_OrderList" %>
<%@ Register Src="/muc/CommodityInfo.ascx" TagName="ucCommodityInfo" TagPrefix="uc1" %>

        <asp:Repeater runat="server" ID="detailRepeater">
            <ItemTemplate>
			<!--产品-->
			<div class="spwhrite cmain">
				<div class="thecp_img thecp_spimg fl">
					<img src="<%#ImageURLFormat(Convert.ToString(Eval("imgurl"))) %>" />
				</div>
				<div class="thecp_word thecp_spword fl">
					<h3><%#Eval("Title") %>[<%#Eval("productNo") %>]</h3>
					<p><i>￥<%#Convert.ToDecimal(Eval("MemberPrice")).ToString("N0")%></i></p>
                    <uc1:ucCommodityInfo runat="server" id="ucCommodityInfo" Data="<%#Container.DataItem %>"></uc1:ucCommodityInfo>
					<p><span><%#Eval("addtime") %></span></p>
				</div>
			</div>
			<!--产品end-->
            </ItemTemplate>
        </asp:Repeater>