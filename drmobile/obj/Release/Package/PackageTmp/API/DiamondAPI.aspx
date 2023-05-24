<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiamondAPI.aspx.cs" Inherits="drmobile.API.DiamondAPI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Repeater runat="server" ID="rpDiamond">
                    <ItemTemplate>
                    <li>
						<div class="mbdr_cp-word detail_border">
							<p>商品编号： <%#Eval("code")%></p> 
						</div>
						<div class="mbdr_cp-word mbdr_cp-spword">
							<p>钻重：<%#Eval("carat")%></p> 
							<p>颜色：<%#Eval("color") %></p> 
							<p>净度：<%#Eval("clarity")%></p> 
							<p>切工：<%#Eval("cut") %></p> 
							<p>对称：<%#Eval("symmetry")%></p> 
							<p>抛光：<%#Eval("polish")%></p> 
							<p>荧光：<%#Eval("fluorescence")%></p> 
							<p>材质：<%#GetCurrentMaterial()%></p> 
							<p>钻戒价格：<span>￥<%#GetProductPrice(Convert.ToDecimal(Eval("memberprice"))).ToString("N0")%></span></p> 
							<a href="/dring_detail.aspx?id=<%=ProductID %>&Did=<%#Eval("id") %>">立即购买</a>
						</div>
					</li>
                    </ItemTemplate>
                </asp:Repeater>
    </div>
    </form>
</body>
</html>
