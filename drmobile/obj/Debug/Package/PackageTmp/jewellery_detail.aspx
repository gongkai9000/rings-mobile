<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="jewellery_detail.aspx.cs" Inherits="drmobile.jewellery_detail" %>

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
    var s,w;

    var RefeshPPriceEvent = function(){
        $(".cpword_left i").text("￥"+formatCurrency(getProductPrice()));
    };

    function getProductPrice() {
        return CurrentDiamondPrice + FDiamondPrice + CurrentMaterialPrice;
    }

    function toBuy() {
        checkComplete = function(info) {
            $.post("/API/AddCartAPI.ashx?cmd=AddCartJl",info, function(data) {
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
            $.post("/API/AddCartAPI.ashx?cmd=AddCartJl",info, function(data) {
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

    function addCartFun() { 
        if("<%=DRM.Common.CurrentUser.IsLogin.ToString() %>" == "False")
        {
            w.Show("尚未登录");
            Redirect('/Account/Login.aspx?returnUrl=<%=Url%>');
            return;
        }

        var data = {
        pid : <%=PID %>,
        caizhi : CurrentMaterial
        };
        checkComplete(data);
    }

    $(function(){
        s = new Success();
        w = new Wrong();

        MaterialChoosedEvent = function(m, p){
            CurrentMaterial = m;
            CurrentMaterialPrice = p;
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
						<p class="sp_color">预计收货时间：付款成功后第<%=getDay()%>个工作日</p>
					</div>
				</div>
			</div>
			<!--参数选择end-->
            <uc1:ucrelatedinfo runat="server" ID="ucrelatedinfo"></uc1:ucrelatedinfo>
            <uc1:ucBuyControl runat="server" ID="ucBuyControl"></uc1:ucBuyControl>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageEndJs" ID="pageend" runat="server">

</asp:Content>
