<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="call_back_url.aspx.cs" Inherits="drmobile.pay.mobile_pay.call_back_url" %>
<%@ Register Src="/muc/CommodityInfo.ascx" TagName="ucCommodityInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p class="iconfont pay_cg">&#xe606;<span>支付成功</span></p>
			<!--支付方式-->
			<div class="spwhrite">
				<p>您的支付方式：支付宝</p>
				<p>您的订单号：<%=orderid %></p>
				<p>您的支付金额：<i>￥<%=Price %></i></p>
			</div>
			<!--支付方式end-->
			<!--产品-->
            <asp:Repeater ID="rptProduct" runat="server" >
            <ItemTemplate>
			<div class="spwhrite cmain">
				<div class="thecp_img fl">
					<img src="<%#Eval("imgurl") %>" />
				</div>
				<div class="thecp_word fl">
                        <a href="/<%#getUrl(Eval("productTypeId").ToString()) %>?id=<%#Eval("ProductId").ToString() %>">
                        <h3><%#Eval("Title") %></h3></a>
                        <uc1:ucCommodityInfo runat="server" id="ucCommodityInfo" Data="<%#GetDataItem() %>"></uc1:ucCommodityInfo>
					    <p><i>￥<%#Eval("memberprice") %></i></p>                  
				</div>
				<div class="iconfont right_position">&#xe605;</div>
			</div>
            </ItemTemplate>
            </asp:Repeater>
			<!--产品end-->
			<div class="spwidth_608 sm_pad">
				<a href="/mindex.aspx" class="to_shop">返回首页</a>
			</div>
</asp:Content>
