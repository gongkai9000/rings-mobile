<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="EmptyAddress.aspx.cs" Inherits="drmobile.EmptyAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			<div class="spwidth_608">
				<div class="mb_noshop">
					<img src="/mimages/dr_member/noadress.png" />
					<p>你还没有添加地址哦。</p>
					<a href="AddAddress.aspx?returnurl=<%=ReturnUrl %>" class="to_shop">去添加</a>
				</div>
			</div>
</asp:Content>