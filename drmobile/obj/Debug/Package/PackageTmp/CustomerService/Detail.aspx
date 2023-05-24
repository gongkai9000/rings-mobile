<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="drmobile.CustomerService.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Repeater ID="rpQuestion" runat="server">
            <ItemTemplate>
                <!--问题-->
			    <div class="ques_answer">
				    <div class="detail_number the_question">
					    <i><%#Eval("question") %></i>
				    </div>
				    <div class="spwhrite the_answer">
					    <p><%#Eval("ask") %></p>
				    </div>
			    </div>
			    <!--问题end-->
            </ItemTemplate>
        </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">
</asp:Content>
