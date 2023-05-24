<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="drmobile.OrderDetail" %>
<%@ Import Namespace="DRM.BLL.Order" %>

<%@ Register TagPrefix="uc" Src="~/us/us_OrderList.ascx" TagName="orderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="mjs/CustomControl.js" type="text/javascript"></script>
<script type="text/javascript">
    //确认收货
    var s;
    var a;
    $(function () {
        s = Success();
        a = MyAlert();
    });
    function changeStatusOver(orderid) {
        a.Show("是否确认收货？");
        a.SureEvent = function () {
            $.get("/API/OrderCommand.ashx?action=changeStatusOver&orderid=" + orderid, function () {
                s.Show("确认收货成功");
                window.location.reload();
            });
        };
    }
    function OpenExclusivePage(orderid) {
        $.get("/API/OrderCommand.ashx?action=OpenExclusivePage&orderid=" + orderid, function () {
            s.Show("开通成功");
        });
    }
    function CancelOrder(orderid) {
        a.Show("是否确定取消订单？");
        a.SureEvent = function () {
            $.get("/API/OrderCommand.ashx?action=CancelOrder&orderid=" + orderid, function () {
                s.Show("取消成功");
                window.location.reload();
            });
        };
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <!--白色区域内-->
			<div class="detail_number">
				订单编号：<%=Order.orderid %>
			</div>
			<div class="spwhrite">
				<div class="detail_all">
					<p>订单状态：<span class="orange"><%=OrderStatus.GetOrderStatus(Order.status) %></span></p>
					<p>支付方式：<span><%=Order.paytype %></span></p>
					<p>订单金额：<span class="red">￥<%=Order.ordertotal.Value.ToString("N0") %></span></p>
					<p>下单时间：<span><%=Order.addtime %></span></p>
					<p>预计发货时间：<span><%=getDeliverytime(Order)%></span></p>
				</div>
				<div class="detail_but">
	                <%=getBtnHTML(Order)%>
				</div>
			</div>
			<!--白色区域内end-->
            
            <uc:orderList runat="server" ID="ucOrder" />

			<!--白色区域内-->
			<div class="detail_number">
				收货信息
			</div>
			<div class="spwhrite cmain the_margin">
				<div class="detail_all">
					<p>收货人：<span><%=Order.realname %></span></p>
					<p>手机：<span><%=Order.mobile %></span></p>
					<p>收货地址：<span><%=Order.address %></span></p>
				</div>
<%--				<div class="iconfont right_position">&#xe605;</div>--%>
			</div>
			<!--白色区域内end-->
                            <div class="qrtc" style="display:none">
		        <p></p>
		        <div class="detail_but">
			        <a href="javascript:void(0)" class="bkwhirte fl">取消</a>
			        <a href="javascript:void(0)" class="fr">确定</a>
		        </div>
	        </div>
</asp:Content>
