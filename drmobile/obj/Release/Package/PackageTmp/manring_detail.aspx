<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="manring_detail.aspx.cs" Inherits="drmobile.manring_detail" %>

<%@ Register Src="muc/DiamondSearch.ascx" TagName="ucdiamonsearch" TagPrefix="uc1" %>
<%@ Register Src="muc/RelatedInfo.ascx" TagName="ucrelatedinfo" TagPrefix="uc1" %>
<%@ Register Src="muc/ProductImgView.ascx" TagName="ucProductImgView" TagPrefix="uc1" %>
<%@ Register Src="muc/Material.ascx" TagName="ucMaterial" TagPrefix="uc1" %>
<%@ Register Src="muc/Handsize.ascx" TagName="ucHandsize" TagPrefix="uc1" %>
<%@ Register Src="muc/BuyControl.ascx" TagName="ucBuyControl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/mjs/dr_buy.js" ></script>
    <script type="text/javascript">
    var CurrentDiamondPrice = <%=CurrentViewProduct.DiamondPrice ?? 0 %> * <%=CurrentViewProduct.znumber ?? 0 %>;
    var FDiamondPrice = <%=CurrentViewProduct.fDiamondPrice ?? 0 %> * <%=CurrentViewProduct.fnumber ?? 0 %>;
    var CurrentMaterialPrice = 0;
    var CurrentMaterial = "";
    var CurrentHandsizePrice = 0;
    var s,w;

    var RefeshPPriceEvent = function(){
        $(".cpword_left i").text("￥"+formatCurrency(getProductPrice()));
    };

    function getProductPrice() {
        return CurrentDiamondPrice + FDiamondPrice + CurrentMaterialPrice + CurrentHandsizePrice;
    }

    function toBuy() {
        checkComplete = function(info) {
            $.post("/API/AddCartAPI.ashx?cmd=AddCartMan",info, function(data) {
                if (data == "true") {
                    s.Show("添加成功");
                    Redirect("/Cart.aspx");
                } else {
                    w.Show(data);
                }
            });
        };
        addCartFun();
    };
    function addCart() {
        checkComplete = function(info) {
            $.post("/API/AddCartAPI.ashx?cmd=AddCartMan",info, function(data) {
                if (data == "true") {
                    s.Show("添加成功");
                } else {
                    w.Show(data);
                }
            });
        };
        addCartFun();
    }

    var checkComplete= function(){};

    function strlength(str) { num = str.length; var arr = str.match(/[^\x00-\x80]/ig); if (arr != null) num += arr.length; return num; }
    String.prototype.replaceAll = function (s1, s2) {
        return this.replace(new RegExp(s1, "gm"), s2);
    }

    function addCartFun() { 
        if($(".choose_num").val() == "-1")
        {
            w.Show("请选择手寸");
            return;
        }
        if (strlength($("#ipt_1").val().replaceAll("♥", "?")) > 8) {
            w.Show("刻字数超过了8个字符，中文为2个字符");
            return;
        }
        if("<%=DRM.Common.CurrentUser.IsLogin.ToString() %>" == "False")
        {
            w.Show("尚未登录");
            Redirect('/Account/Login.aspx?returnUrl=<%=Url%>');
            return;
        }

        var data = {
        pid : <%=PID %>,
        caizhi : CurrentMaterial,
        handsize : $(".choose_num").val() == null?"":$(".choose_num").val(),
        font : $("#ipt_1").val()
        };
        checkComplete(data);
    }

    $(function(){
        s = new Success();
        w = new Wrong();

        MaterialChoosedEvent = function(m, p){
            CurrentMaterial = m;
            CurrentMaterialPrice = p;
            $("#<%=ucHandsize.UControlID %>").change();
        };

        <%=ucHandsize.UControlID %>ChangeEvent = function(option,p){
            CurrentHandsizePrice = p;
            RefeshPPriceEvent();
        };
    });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <uc1:ucProductImgView runat="server" ID="ucProductImgView"></uc1:ucProductImgView>
   
			<!--商品区域end-->
			<!--参数选择-->
			<div class="spwhrite cmain">
				<!--普通参数选择-->
				<div class="thechoose">
					<div class="thechoose_left">
                        <uc1:ucMaterial runat="server" ID="ucMaterial"></uc1:ucMaterial>
						<p>
							<span>手寸：</span>
							<uc1:ucHandsize runat="server" ID="ucHandsize" UControlID="handsize"></uc1:ucHandsize>
							<a href="/helpCenter/HandsizeHelp.aspx">如何量手寸？</a>
						</p>
						<p>
							<span>刻字：</span>
							<input type="text" id="ipt_1" class="kz_txt" placeholder="4个汉字或8个字母"/><em class="write_choose">♥</em><em class="write_choose">&</em>
						</p>
						<p class="sp_color">预计收货时间：付款成功后第<%=getDay()%>个工作日</p>
					</div>
				</div>
				<!--普通参数选择end-->
			</div>
			<!--参数选择end-->
            <uc1:ucrelatedinfo runat="server" ID="ucrelatedinfo"></uc1:ucrelatedinfo>
            <uc1:ucBuyControl runat="server" ID="ucBuyControl"></uc1:ucBuyControl>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageEndJs" ID="pageend" runat="server">

</asp:Content>
