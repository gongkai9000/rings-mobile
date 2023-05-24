<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pay.aspx.cs" Inherits="drmobile.pay.pay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
  
    <asp:PlaceHolder runat="server" ID="ph_pay_1" Visible="false">
<div style="text-align:center;">正在打开付款页面，请稍候 ... ...</div>
<asp:Literal runat="server" ID="ltlHtml"></asp:Literal>
    </asp:PlaceHolder>
    
    
</body>
</html>
