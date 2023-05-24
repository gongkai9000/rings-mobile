<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="DarryFail.aspx.cs" Inherits="drmobile.DarryFail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>专属验证</title>
<link type="text/css" rel="stylesheet" href="styles/member.css" />
<script type="text/javascript">

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
                <p>尊贵的<%=Name %>先生，经过DR专属查询显示您已享拥一枚Darry Ring求婚戒指或购物车中存在Darryring，您可以继续挑选我们的结婚对戒系列以及其他精致的珠宝礼物。祝您购物愉快！</p>
                <span>香港戴瑞珠宝</span>
            </div>
        </div>
        <!--提示-->
        <div class="quick_dl">
        	<p>您可以继续挑选我们的结婚对戒系列产品，以及其他精致华美的珠宝首饰。祝您购物愉快！</p>
        </div>
        <!--分享-->
        <div class="shareor">
        	<a href="Cart.aspx">查看商品</a>

        </div>
    </div>
</div>


</asp:Content>
