<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="SubmitOrder.aspx.cs" Inherits="drmobile.SubmitOrder" %>

<%@ Register Src="muc/workflow.ascx" TagName="ucWorkflow" TagPrefix="uc1" %>
<%@ Register Src="muc/CommodityInfo.ascx" TagName="ucCommodityInfo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <uc1:ucWorkflow runat="server" id="ucWorkflow"></uc1:ucWorkflow>
			<!--白色区域内-->
<%--			<div class="detail_number thedetail_num mrg_top">
				订单编号：<%=OrderID%>
			</div>--%>
			<div class="detail_number thedetail_num">
				应付金额：<i><%=TotalPrice.ToString("N0") %>元</i>
			</div>
			<!--白色区域内end-->
			<!--产品-->
            
            <asp:Repeater runat="server" ID="rpProduct">
                <ItemTemplate>
                    <div class="spwhrite cmain nopwhrite">
				        <%--<a href="#" class="aposition"></a>--%>
				        <div class="thecp_spimg fl">
					        <img src="<%#Eval("ProductImg") %>" />
				        </div>
				        <div class="thecp_word thecp_owpword fl">
				            <h3><%#Eval("Title") %></h3>
                            <uc1:ucCommodityInfo runat="server" id="ucCommodityInfo" Data="<%#GetDataItem() %>"></uc1:ucCommodityInfo>
                            <p><i>￥<%#string.Format("{0:N0}", Eval("MemberPrice"))%></i></p>
				        </div>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
            
			<!--产品end-->
			<!--白色区域内-->
			<div class="detail_number">
				收货信息
			</div>
			<div class="spwhrite cmain" runat="server" id="addressDiv">
				<a href="/MyAddressChoose.aspx?returnUrl=<%=AddressCallbackUrl %>" class="aposition"></a>
				<div class="detail_all">
					<p>收货人：<span><%=CurrentAddress.SpAddressName%></span></p>
					<p>手机：<span><%=CurrentAddress.SpAddressMobile%></span></p>
					<p>收货地址：<span><%=CurrentAddress.SpAddressCity%><%=CurrentAddress.SpAddressStreet %></span></p>
				</div>
				<div class="iconfont right_position">&#xe605;</div>
			</div>
			<!--白色区域内end-->
			<!--新增地址-->
			<div class="address_add adress_mg">
				<a href="/AddAddress.aspx?returnurl=<%=AddressCallbackUrl %>">新增收货地址</a>
			</div>
			<!--新增地址end-->
			<!--支付方式-->
			<div class="detail_number thedetail_num">
				<img src="mimages/dr_cp/pay_1.png" width="20"/><span>支付方式</span>
			</div>
			<ul class="payway_ul">
            	<li class="theclick_d" paytype="zhifubao">
					<img src="mimages/dr_cp/pay_3.jpg" width="34"/>
					<span>支付宝支付</span>
					<i></i>
				</li>
				<li paytype="yinlian" class="nobder">
					<img src="mimages/dr_cp/pay_2.jpg" width="30"/>
					<span>银联在线</span>
					<i></i>
				</li>
				<li class="nobder" style="display:none">
					<img src="mimages/dr_cp/pay_4.jpg" width="34"/>
					<span>财付通支付</span>
					<i></i>
				</li>
			</ul>
			<!--支付方式end-->
			<!--备注框-->
			<div class="pay_text">
				<textarea id="txtOrderNote" maxlength="200" style="border:none;margin:4px 0;width:95%;height:100px;outline:none;font-size:16px;resize:none;padding:0 2%;font-family:'微软雅黑';color:#666" placeholder="备注："></textarea>
			</div>
			<!--备注框end-->
			<div class="theyz_bt">
				<button class="yz-button" type="button">
					提交订单
				</button>
			</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">
    <script src="mjs/dr_buy.js" type="text/javascript"></script>
    <script type="text/javascript">
        var s,w;
        var addressId = <%=CurrentAddress.SpAddressId  %>;
        $(function () {
            s = new Success();
            w = new Wrong();
            $(".yz-button").click(function () { 
                if(addressId == 0)
                {
                    w.Show("请先选择地址");
                    return;
                }
                var pt = $(".payway_ul .theclick_d").attr("paytype");
                $.post("/API/OrderCommand.ashx?action=CreateOrder&addressId="+addressId,{txtOrderNote:$("#txtOrderNote").val(),paytype:pt},function(msg){
                    if(msg.result != "OK")
                    {
                        w.Show(msg.msg);
                        return;
                    }
                    else
                    {
                        sendga(msg.orderid);
                        window.location = msg.msg;
                    }
                },"json");
            });

        });
        ga('require', 'ecommerce', 'ecommerce.js');               //固定引用ecommerce.js
        function sendga(orderid)
        {
            ga('ecommerce:addTransaction', {    //收集订单数据
                'id': orderid,                    // 订单号（变量）。必填   
                'affiliation': '',                // 联盟商家名（变量）。一般不用填   
                'revenue': '<%=TotalPrice %>',              // 订单金额（变量）。一般需要填
                'shipping': '0',                // 运费（变量）。选填
                'tax': '',                     // 税（变量）。一般不用填
                'currency': 'CNY'                 // 货币代码 （变量）。一般为CNY
            });
            <%for(int i=0;i<CurrentCart.Count;i++){%>
                ga('ecommerce:addItem', {   //收集商品数据
                    'id': orderid,                    // 订单号。必填.   
                    'name': '<%=CurrentCart[i].Title %>',   // 商品名称。必填   
                    'sku': '',                // SKU号（变量）选填
                    'category': '',        // 商品类目。选填   
                    'price': '<%=CurrentCart[i].MemberPrice %>',                // 商品单价。
                    'quantity': '1'                   // 商品数量   
                });
            <%}%>
            ga('ecommerce:send');
        }
    </script>
</asp:Content>
