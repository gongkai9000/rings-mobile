<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="drmobile.OrderList" %>
<%@ Import Namespace="DRM.BLL.Order" %>

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
<!--所有产品-->
			<div class="all_detail">
    <asp:Repeater ID="orderRepeater" runat="server">
        <ItemTemplate>
				<!--产品-->
				<div class="detail_number">
					订单编号：<%#Eval("orderid") %>
				</div>
				<div class="spwhrite cmain">
					<a href="OrderDetail.aspx?orderid=<%#Eval("orderid") %>" class="aposition"></a>
					<div class="theall_cp">
						<div class="thecp_img detail_spimg fl">
							<img src="<%#Eval("imgurl") %>" />
						</div>
						<div class="thecp_word detail_spword fl">
							<h3><%#Eval("title") %>[<%#Eval("ProductNo") %>]</h3>
							<p><i>￥<%#string.Format("{0:N0}", Eval("ordertotal"))%></i></p>
							<p><span><%#Eval("addtime") %></span></p>
                            <%#getOrderDetailCount(GetDataItem() as DRM.Entity.view_mOrder)%>
							<div class="detail_zt">
								订单状态：<%#getOrderStatus(Convert.ToInt32(Eval("status")))%>
							</div>
						</div>
					</div>
					<div class="iconfont right_position">&#xe605;</div>
                    <div class="detail_but cmain<%#getBtnCountClass(GetDataItem() as DRM.Entity.view_mOrder) %>">
						<%#getBtnHTML(GetDataItem() as DRM.Entity.view_mOrder)%>
					</div>
				</div>
				<!--产品end-->
        </ItemTemplate>
    </asp:Repeater>
    </div>
                <div class="qrtc" style="display:none">
		        <p></p>
		        <div class="detail_but">
			        <a href="javascript:void(0)" class="bkwhirte fl">取消</a>
			        <a href="javascript:void(0)" class="fr">确定</a>
		        </div>
	        </div>
</asp:Content>
