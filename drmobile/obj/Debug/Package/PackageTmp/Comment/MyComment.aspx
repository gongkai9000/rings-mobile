<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="MyComment.aspx.cs" Inherits="drmobile.Comment.MyComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="all_detail">
				<!--产品-->
                <asp:Repeater runat="server" ID="rpOrderDetail">
                <ItemTemplate>
                    <div class="spwhrite cmain">
				        <div class="thecp_img detail_spimg fl">
					        <img src="<%#DRM.Common.ImageURLFormat.Format(Convert.ToString(Eval("imgurl"))) %>" />
				        </div>
				        <div class="thecp_word detail_spword fl">
					        <h3><%#Eval("title")%>[<%#Eval("productNo")%>]</h3>
					        <p><i>￥<%#Eval("memberprice")%></i></p>
                            <p>材质：<%#Eval("Material") %></p>
<%--                            <p>手寸：<%#Eval("handsize")%></p>
                            <p>刻字：<%#Eval("fontstyle")%></p>--%>
					        <p><span><%#Eval("addtime") %></span></p>
                            <div class="detail_but sqdetail">
							        <a href="Comment.aspx?odid=<%#Eval("Id") %>">评价</a>
						    </div>
				        </div>
                        <div class="iconfont right_position">&#xe605;</div>
			        </div>
                </ItemTemplate>
                </asp:Repeater>
             </div>
</asp:Content>
