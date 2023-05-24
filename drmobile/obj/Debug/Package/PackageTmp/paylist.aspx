<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="paylist.aspx.cs" Inherits="drmobile.paylist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--支付方式-->
			<div class="detail_number thedetail_num">
				<img src="/mimages/ct_cp/pay_1.png" width="20"/><span>支付方式</span>
			</div>
			<ul class="payway_ul">
            	<li class="theclick_d" paytype="zhifubao">
					<img src="/mimages/ct_cp/pay_3.jpg" width="34"/>
					<span>支付宝支付</span>
					<i></i>
				</li>
				<li paytype="yinlian" class="nobder" style="display:none">
					<img src="/mimages/ct_cp/pay_2.jpg" width="30"/>
					<span>银联在线</span>
					<i></i>
				</li>
				<li class="nobder" style="display:none">
					<img src="/mimages/ct_cp/pay_4.jpg" width="34"/>
					<span>财付通支付</span>
					<i></i>

               				</li>
               <li paytype="weixin" class="nobder">
					<img src="/mimages/ct_cp/pay_2.jpg" width="30"/>
					<span>微信支付</span>
					<i></i>
				</li>
			</ul>
			<!--支付方式end-->
			<div class="theyz_bt">
				<button class="yz-button" type="button">
					提交订单
				</button>
			</div>
			<!--底部-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">
<script type="text/javascript" src="/mjs/dr_buy.js" ></script>
<script type="text/javascript">
    $(".yz-button").click(function () {
        var paytype = $(".theclick_d").attr("paytype");
        $.post("/API/OrderCommand.ashx?action=choosePayType&orderid=<%=Request.QueryString["orderid"] %>&paytype="+paytype,function(msg){
            window.location = msg;
        });
    });
</script>
</asp:Content>
