<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="DarrySuccess.aspx.cs" Inherits="drmobile.DarrySuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>专属验证</title>
<link type="text/css" rel="stylesheet" href="styles/member.css" />
<script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function BuyNow() {
        $.get('/API/AddCartAPI.ashx?cmd=AddCartDR&cardId=<%= Request.QueryString["cardId"]%>&pid=<%=Request.QueryString["productId"] %>', function (msg) { 
            if(msg == "true")
            {
                window.location = "Cart.aspx";
            }
            else
            {
                alert(msg);
            }
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--返回选项-->
<div class="fhx">
	<a href="javascript:history.go(-1)">返回</a>
    <span>专属验证</span>
</div>

<!--边框外-->
<div class="dl_corent">
    <!--验证结果框-->
    <div class="border">
    	<div class="contract">
        	<!--定位四个角-->
        	<div class="contract-top"></div>
            <div class="contract-tright"></div>
            <div class="contract-bottom"></div>
            <div class="contract-bright"></div>
            <!--内容-->
            <div class="yz_false">
            	<h5>专属验证</h5>
                <p>您好，您提供的身份证尚未有购买记录，可以对Darry Ring求婚钻戒进行挑选购买，一生仅此一枚。祝您购物愉快！</p>
                <span>香港戴瑞珠宝</span>
            </div>
        </div>
        <!--提示-->
        <div class="quick_dl">
        	<p>尚未购买，<a href="/Account/Register.aspx">点击注册</a>。</p>
            <p>立即购买Darry Ring即可享有<a href="javascript:void(0)">专属页面</a>。</p>
        </div>
        <!--分享-->
        <div class="shareor">
        	<a href="<%=Btn.Url %>" onclick="<%=Btn.OnClick %>"><%=Btn.Text %></a>

        </div>
    </div>
</div>

</asp:Content>
