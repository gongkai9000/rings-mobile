<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="drmobile.news.list" %>

<%@ Register Src="/muc/newslist.ascx" TagName="ucNewslist" TagPrefix="uc1" %>
<%@ Register Src="/muc/website.ascx" TagName="ucWebsite" TagPrefix="uc1" %>
<%@ Register Src="/muc/Paging.ascx" TagName="ucPaging" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:ucWebsite runat="server" ID="ucwebsite"></uc1:ucWebsite>
<!--导航-->
<div class="zx_bk" id="divClass" runat="server">
	<div class="zx_nav">
        <asp:Repeater runat="server" ID="rpClass">
            <ItemTemplate>
                <a<%#GetClass(Container.ItemIndex,Convert.ToInt32(Eval("id"))) %> href="/news/list.aspx?typeid=<%#Eval("id") %>">
			        <i></i>
			        <%#Eval("title")%>
		        </a>
            </ItemTemplate>
        </asp:Repeater>
	</div>
</div>
<!--导航end-->
<div class="awhrite" id="wrapper">
    <ul class="mbxx_all zxzx_all" id="ulList">
        <uc1:ucNewslist runat="server" id="ucList"></uc1:ucNewslist>
    </ul>
     <div id="pullUp"></div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">
<uc1:ucPaging ID="ucpaging" runat="server" ClientObjectName="NewsList" SrollControlID="wrapper" />
<script type="text/javascript">
    NewsList.CustomChanged = function (num) {
        $.get("/API/NewsList.aspx?typeid=<%=Request.QueryString["typeid"] %>&skip=" + $("#ulList li").length, function (data) {
            $("#ulList").append(data);
        });
    };
</script>
</asp:Content>
