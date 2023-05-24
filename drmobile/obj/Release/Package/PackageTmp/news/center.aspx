<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="drmobile.news.center" %>

<%@ Register Src="/muc/newslist.ascx" TagName="ucNewslist" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!--品牌动态-->
	    <div class="awhrite">
		    <ul class="mbxx_all zxzx_all">
			    <li class="thsp_title">					
				    <span class="the_ppdt"></span>品牌动态
				    <i class="iconfont fr">&#xe605;</i>
				    <a href="list.aspx?typeid=47" class="fr">更多</a>
			    </li>
			    <uc1:ucNewslist runat="server" id="ucPinpai" PageSize="4"></uc1:ucNewslist>
		    </ul>
	    </div>
        <!--品牌动态end-->
		<!--求婚指南-->
		<div class="awhrite">
			<ul class="mbxx_all zxzx_all">
				<li class="thsp_title">					
					<span class="the_qhzn"></span>求婚指南
					<i class="iconfont fr">&#xe605;</i>
					<a href="list.aspx?typeid=42" class="fr">更多</a>
				</li>
			    <uc1:ucNewslist runat="server" id="ucQiuhun" PageSize="4"></uc1:ucNewslist>
			</ul>
		</div>
		<!--求婚指南end-->
        <!--钻石百科-->
		<div class="awhrite">
			<ul class="mbxx_all zxzx_all">
				<li class="thsp_title">					
					<span class="the_zsbk"></span>钻石百科
					<i class="iconfont fr">&#xe605;</i>
					<a href="list.aspx?typeid=18" class="fr">更多</a>
				</li>
			    <uc1:ucNewslist runat="server" id="ucZuanshi" PageSize="4"></uc1:ucNewslist>
			</ul>
		</div>
		<!--钻石百科end-->
        <!--珠宝百科-->
		<div class="awhrite">
			<ul class="mbxx_all zxzx_all">
				<li class="thsp_title">					
					<span class="the_zbbk"></span>珠宝百科
					<i class="iconfont fr">&#xe605;</i>
					<a href="list.aspx?typeid=22" class="fr">更多</a>
				</li>
			    <uc1:ucNewslist runat="server" id="ucZhubao" PageSize="4"></uc1:ucNewslist>
			</ul>
		</div>
		<!--珠宝百科end-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">
</asp:Content>
