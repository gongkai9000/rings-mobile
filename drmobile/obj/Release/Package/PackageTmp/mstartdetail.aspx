﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="mstartdetail.aspx.cs" Inherits="drmobile.mstartdetail" %>

<%@ Import Namespace="DRM.BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%=ProposeBLL.GetProposeById(Convert.ToInt32(Request["id"]??"1")).ProposeNewsContent %>
</asp:Content>
