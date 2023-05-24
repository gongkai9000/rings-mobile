<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="CartOrderDetail.aspx.cs" Inherits="drmobile.CartOrderDetail" %>
<%--<%@ Register Src="~/us/us_Cart.ascx" TagName="ucCart" TagPrefix="uc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>购物车</title>
<link type="text/css" rel="stylesheet" href="styles/member.css" />
<script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="Scripts/Wrong.js" type="text/javascript"></script>
<script src="Scripts/Verification.js" type="text/javascript"></script>
<script type="text/javascript">
    var w;
    $(document).ready(function () {
        w = new Wrong();
        w.Insert(".fhx");
    });
    var darryHome;
    var SMSRemind;
    function setDarryHome() {
        if ($("#txtMr").val() == "" || $("#txtCardId").val() == "" || $("#txtMs").val()=="") {
            w.Show("先生姓名、先生身份证、女士姓名不可为空。");
            return;
        }
        if (!(/(^\d{15}$)|(^\d{17}([0-9]|X)$)/.test($("#txtCardId").val()))) {
            w.Show("身份证不合法。");
            return;
        }
        if ($("#txtBirthday").val() != "" && !IsValidDate($("#txtBirthday").val())) {
            w.Show("生日不是正确日期。");
            return;
        }
        if ($("#txtMemorial1").val() != "" && !IsValidDate($("#txtMemorial1").val())) {
            w.Show("纪念日1不是正确的日期。");
            return;
        }
        if ($("#txtMemorial2").val() != "" && !IsValidDate($("#txtMemorial2").val())) {
            w.Show("纪念日2不是正确的日期。");
            return;
        }
        w.Exit();

        darryHome = { "DarryHomeMemberName": $("#txtMr").val(),
            "DarryHomeIDCard": $("#txtCardId").val(),
            "DarryHomeMsName": $("#txtMs").val()
        };
        SMSRemind = { "txtBirthday": $("#txtBirthday").val(), "txtMemorial1": $("#txtMemorial1").val(), "txtMemorial2": $("#txtMemorial2").val() };
        $("#btnAgree").hide();
        $(".contract input[type='text']").attr("readonly", "readonly");

    }

    function toPay() {
        if ("True" == "<%=IsDarry %>") {
            if (!darryHome || !SMSRemind) {
                w.Show("请填写和接受真爱协议。");
                return;
            }
        }
        $.post("<%=OrderAPIUrl %>?action=CreateOrder&addressId=<%=AddressId %>", { "DarryHome": darryHome, "SMSRemind": SMSRemind, "txtOrderNote": $("#txtOrderNote").val() }, function (data) {
        if (data.result == "OK") {
            window.location = data.msg;
        }
        else {
            w.Show(data.msg);
        }
    });
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <!--返回选项-->
<div class="fhx">
	<a href="javascript:history.go(-1)">返回</a>
    <span>购物车</span>
</div>
    <!--边框外-->
<div class="dl_corent">
	<div class="new_ad">收货人信息</div>
    <!--收货人信息-->
    <div class="border">
    	<p><%=Address.SpAddressName%><span><%=Address.SpAddressMobile%></span></p>
        <p><%=Address.SpAddressCity %></p>
        <p><%=Address.SpAddressStreet%></p>
        <div class="button">
        	<a href="Address.aspx?retrunPage=CartOrderDetail.aspx&Type=Choose">选择收货人信息</a>
        </div>
    </div>
    <!--协议-->
    <div class="border" id="protocol" runat="server">
    	<div class="contract">
        	<!--定位四个角-->
        	<div class="contract-top"></div>
            <div class="contract-tright"></div>
            <div class="contract-bottom"></div>
            <div class="contract-bright"></div>
            <div class="the_xy">
            	<img src="images/xy.jpg" width="192" height="19"/>
            </div>
            <div class="to_love">
                <p>CTloves 每位男士凭身份证号一生仅可购买一枚，作为一生唯一真爱的最高承诺。</p>
                <p>签署该协议则表示您已经过慎重考虑，决定自购买之日起，将您的身份证号与CTloves 编码绑定，并接受亲友对购买信息的验证查询。</p>
                <p>此购买信息将终身留存在CTloves 数据库中并无法更改。</p>
                <p>请用心呵护您的真爱。</p>
            </div>
            <input type="text" readonly="readonly" class="ipt_3" placeholder="请输入先生的姓名" id="txtMr" value="<%=DRM.Common.CookieHelper.GetCookie("sirName")%>" />
            <input type="text" readonly="readonly" class="ipt_3" placeholder="先生的身份证号码" id="txtCardId" value="<%=DRM.Common.CookieHelper.GetCookie("sirCode")%>"/>
            <input type="text" class="ipt_3" placeholder="请输入女士的姓名" id="txtMs"/>
            <div class="to_love">
                <p>女生会很在乎您记得这些重要的日子。不一定要送礼，一句问候或是一份惊喜都能给爱情加分。</p>
                <p>如果有重要的节日让CTloves珠宝帮您提醒。</p>
            </div>
            <input type="text" class="ipt_3" placeholder="她的生日" id="txtBirthday"/>
            <input type="text" class="ipt_3" placeholder="纪念日一" id="txtMemorial1"/>
            <input type="text" class="ipt_3" placeholder="纪念日二" id="txtMemorial2"/>
            <div class="button or_button" onclick="setDarryHome()" id="btnAgree">我同意并且接受该协议</div>
        </div>
    </div>
    
<%--    <!--订单信息-->
    <uc1:ucCart ID="cartList" runat="server" />--%>
    <!--总额-->
<%--    <div class="new_ad">商品总计:<span>￥21600.00</span></div>--%>
    <textarea class="ipt_3" placeholder="附加信息" id="txtOrderNote"></textarea>
    <div class="button" onclick="toPay()">去结算</div>
    <div class="button" style="display: none">继续购物</div>
</div>


</asp:Content>


