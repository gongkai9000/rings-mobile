<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="drmobile.API.Comment1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Repeater runat="server" ID="rpComment">
                <ItemTemplate>
                    <li>
						<p><%# Server.HtmlEncode(Convert.ToString(Eval("recontent")))%></p>
						<%--<p><span><%#Eval("title") %>    100分F色</span></p>--%>
						<p class="fix"><span class="fl"><%#Server.HtmlEncode(DRM.Common.StringHelper.StrToP(Convert.ToString(Eval("UserName") ?? ""), 1))%></span><span class="fr"><%#Eval("addtime") %></span></p>
					</li>
                </ItemTemplate>
            </asp:Repeater>
    </div>
    </form>
</body>
</html>
