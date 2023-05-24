<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="BankPayList.aspx.cs" Inherits="drmobile.BankPayList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>支付列表</title>
<link type="text/css" rel="stylesheet" href="styles/member.css" />
<script type="text/javascript">

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--返回选项-->
<div class="fhx">
	<a href="javascript:history.go(-1)">返回</a>
    <span>支付列表</span>
</div>

<!--边框外-->
<div class="dl_corent">
	<!--支付列表-->
    <ul class="mem_list">
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">中国工商银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">平安银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">中国建设银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">中国农业银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">招商银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">交通银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">中国邮政储蓄银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">中信银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">浦发银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">广发银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">华夏银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">中国银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">中国光大银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">兴业银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">中国民生银行</a>
        </li>
        <li>
        	<span class="to-right"></span>
            <a href="#" target="_blank">BEA东亚银行</a>
        </li>
    </ul>
</div>

</asp:Content>
