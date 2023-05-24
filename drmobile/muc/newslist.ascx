<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="newslist.ascx.cs" Inherits="drmobile.muc.newslist" %>
<asp:Repeater runat="server" ID="rpNewsList">
    <ItemTemplate>
        <li<%#getstyle(Container.ItemIndex) %>>
			<a href="/news/<%#Eval("ProposeNewsId")%>.html">
				<%#Eval("ProposeNewsTitle")%>
				<i class="iconfont fr">&#xe605;</i>
			</a>
		</li>
    </ItemTemplate>
</asp:Repeater>