<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="website.ascx.cs" Inherits="drmobile.muc.website" %>
<!--面包屑-->
<div class="zx_bread">
<asp:SiteMapPath ID="smpWebsite" runat="server" RenderCurrentNodeAsLink="true">
    <RootNodeTemplate>
        <a href="<%#Eval("url") %>"><%#Eval("title") %></a>
    </RootNodeTemplate>
    <NodeTemplate>
        <a href="<%#Eval("url") %>"><%#Eval("title") %></a>
    </NodeTemplate>
    <CurrentNodeTemplate>
        <i><%#Eval("title") %></i>
    </CurrentNodeTemplate>
    <PathSeparatorTemplate>
        <em></em>
    </PathSeparatorTemplate>
</asp:SiteMapPath>
</div>
<!--面包屑end-->