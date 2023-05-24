<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="mstartlist.aspx.cs" Inherits="drmobile.mstartlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb_star">
        <asp:Repeater runat="server" ID="rptlist">
            <ItemTemplate>
                <!--每一块内容-->
                <div class="mb_star-cort">
                    <h4>
                        <%#Eval("ProposeNewsTitle")%></h4>
                    <div class="mb_star-img">
                        <a href="/mstartdetail.aspx?id=<%#Eval("ProposeNewsId")%>">
                            <img src=" <%#Eval("smallPic")%>" />
                        </a>
                    </div>
                    <div class="mb_star-word">
                        <a href="/mstartdetail.aspx?id=<%#Eval("ProposeNewsId")%>">
                            <%#getStr2(Eval("ProposeNewsContent").ToString(),200, "...")%>
                        </a>
                    </div>
                </div>
                <!--每一块内容end-->
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!--明星见证end-->
</asp:Content>
