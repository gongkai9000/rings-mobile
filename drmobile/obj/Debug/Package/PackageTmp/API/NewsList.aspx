<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="drmobile.API.NewsList" %>
<%@ Register Src="/muc/newslist.ascx" TagName="ucNewslist" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <uc1:ucNewslist runat="server" id="ucList"></uc1:ucNewslist>
    </div>
    </form>
</body>
</html>
