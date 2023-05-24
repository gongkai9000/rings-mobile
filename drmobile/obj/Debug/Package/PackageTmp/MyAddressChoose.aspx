<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="MyAddressChoose.aspx.cs" Inherits="drmobile.MyAddressChoose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript" src="mjs/member.js" ></script>
<script type="text/javascript" src="mjs/CustomControl.js" ></script>
<script type="text/javascript">
    $(function () {
        var a = new MyAlert();
        var s = new Success();
        //删除键
        $(".delbut").click(function () {
            var msg = "你确定要删除该地址吗？";
            a.id = $(this).attr("addid");
            a.control = this;
            a.Show(msg);
        });
        //确定删除
        a.SureEvent = function () {
            $.post("API/DeleteAddressAPI.ashx", { id: a.id }, function (data) {
                if (data == "noid") {
                    w.Show("收货地址编号获取错误！");
                    return;
                }
                if (data == "wrong") {
                    w.Show("删除失败！");
                    return;
                }
                if (data == "ok") {
                    s.Show("删除成功");
                    $("#address_" + a.id).remove();
                    return;
                }
            });
        }
        //选择地址
        $('.mraddress').click(function () {
            var aid = $(this).find("span").attr("addid");
            window.location = "<%=ReturnUrl %>"+aid;
        });

    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--收货地址-->
			<div class="mb_address">
				<!--新增地址-->
				<div class="address_add">
					<a href="AddAddress.aspx?returnurl=<%=ReturnUrl %>">新增收货地址+</a>
				</div>
				<!--新增地址end-->

                <asp:Repeater runat="server" ID="rpAddress">
                    <ItemTemplate>
                        <!--原有地址-->
				        <div class="theaddress" id="address_<%#Eval("SpAddressID") %>">
					        <div class="theadress_top"></div>
					        <div class="theadress_border cmain">
						        <!--地址-->
                                <a href="<%=ReturnUrl %><%#Eval("SpAddressID") %>" class="adress_thea"></a>
						        <div class="theadress_center">
							        <p>
								        <span><%#Eval("SpAddressName")%></span>
								        <span><%#Eval("SpAddressMobile")%></span>
							        </p>
							        <p><%#Eval("SpAddressCity")%><%#Eval("SpAddressStreet") %></p>
						        </div>	
                                
						        <!--地址end-->
						        <!--地址修改删除等-->
						        <div class="theadress_bottom">
							        <div class="mraddress fl">
								        <span class="iconfont<%#isDefaultClass(Convert.ToBoolean(Eval("SpAddressDefault"))) %>" addid="<%#Eval("SpAddressID") %>">&#xe613;</span>
								        <i>选择地址</i>
							        </div>
							        <div class="xaddress fr">
								        <span class="iconfont mrad_click">&#xe614;</span>
								        <a href="AddAddress.aspx?id=<%#Eval("SpAddressID") %>&returnurl=<%=ReturnUrl %><%#Eval("SpAddressID") %>">修改</a>
								        <span class="iconfont mrad_click">&#xe612;</span>
								        <i class="delbut" addid="<%#Eval("SpAddressID") %>"><a href="javascript:void(0)">删除</a></i>
							        </div>
						        </div>
						        <!--地址修改删除等end-->
					        </div>
				        </div>
                    </ItemTemplate>
                </asp:Repeater>
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