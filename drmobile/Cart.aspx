<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="drmobile.Cart" %>

<%@ Register Src="muc/workflow.ascx" TagName="ucWorkflow" TagPrefix="uc1" %>
<%@ Register Src="muc/CommodityInfo.ascx" TagName="ucCommodityInfo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript" src="/mjs/member.js" ></script>
<script type="text/javascript" src="mjs/CustomControl.js"></script>
<script type="text/javascript">
    var s;
    var w;
    var a;
    $(function(){
        s = new Success();
        w = new Wrong();
        a = new MyAlert();
        $(".delbut").click(function(){
            var cartid = $(this).attr("cartid");
            a.Show("是否确定删除？");
            a.SureEvent = function(){
                $.post("/API/ClearCart.ashx?action=delete&cartid="+cartid,function(){
                    window.location.reload();
                });
            };
        });
    });
    function clearCart() {
        if (confirm("是否确认清空？")) {
            $.post("/API/ClearCart.ashx?action=clear", function (msg) {
                if(msg == "true")
                {
                    window.location.reload();
                }
                else
                {
                    w.Show(msg);
                }
            });
        }
    }

    function toPay() { 
        if(<%=DataCount %> ==0)
        {
            w.Show("购物车为空，无法结算。");
        }
        else
        {
            $.get("/API/CheckCart.ashx",function(msg){
                if(msg == "")
                {
                    window.location = "<%=ucWorkflow.NextUrl %>";
                }
                else
                {
                    w.Show(msg);
                }
            });
            
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <uc1:ucWorkflow runat="server" id="ucWorkflow"></uc1:ucWorkflow>
            <!--产品-->
            <asp:Repeater runat="server" ID="rpCart">
                <ItemTemplate>
                    <div class="awhrite sp_padding cmain">
				        <div class="thecp_img theshop_img fl">
					        <img src="<%#ImageURLFormat(Eval("ProductImg").ToString()) %>" />
				        </div>
				        <div class="thecp_word theshop_word fl">
				            <h3><%#Eval("Title") %></h3>
                            <uc1:ucCommodityInfo runat="server" id="ucCommodityInfo" Data="<%#GetDataItem() %>"></uc1:ucCommodityInfo>
                            <p><i>￥<%#string.Format("{0:N0}", Eval("MemberPrice"))%></i></p>
				        </div>
				        <div class="iconfont right_position delbut" cartid="<%#Eval("Id") %>">&#xe612;</div>
			        </div>
                </ItemTemplate>
            </asp:Repeater>

			<!--产品end-->
            <!--继续购物
			<div class="togoshop">
				<a href="/diamondring_list.aspx" class="iconfont">
					&#xe60c;<span>继续购物</span>
				</a>
			</div>
			<!--继续购物end-->
			<!--结算-->
			<div class="tb_js">
				<p class="fl">
					<span>共<%=DataCount%>件商品</span>
					<span>总计：<i>￥<%=TotalPrice.ToString("N0")%></i></span>
				</p>
				<a href="javascript:toPay()" class="fr">去结算</a>
			</div>
            
			<!--收货地址end-->	
            <div class="qrtc" style="display:none">
		        <p></p>
		        <div class="detail_but">
			        <a href="javascript:void(0)" class="bkwhirte fl">取消</a>
			        <a href="javascript:void(0)" class="fr">确定</a>
		        </div>
	        </div>
</asp:Content>
