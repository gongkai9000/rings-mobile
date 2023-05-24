<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="phonics_details.aspx.cs" Inherits="drmobile.phonics_details" %>

<%@ Register Src="muc/DiamondSearch.ascx" TagName="ucDiamonsearch" TagPrefix="uc1" %>
<%@ Register Src="muc/RelatedInfo.ascx" TagName="ucRelatedinfo" TagPrefix="uc1" %>
<%@ Register Src="muc/ProductImgView.ascx" TagName="ucProductImgView" TagPrefix="uc1" %>
<%@ Register Src="muc/PhonicsMaterial.ascx" TagName="ucMaterial" TagPrefix="uc1" %>
<%@ Register Src="muc/Handsize.ascx" TagName="ucHandsize" TagPrefix="uc1" %>
<%@ Register Src="muc/BuyControl.ascx" TagName="ucBuyControl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/mjs/dr_buy.js" ></script>
    <script type="text/javascript">
        //男戒主钻和副钻价格
        var ManZDiamondPrice = <%=ManProduct.DiamondPrice ?? 0 %> * <%=ManProduct.znumber ?? 0 %>;
        var ManFDiamondPrice = <%=ManProduct.fDiamondPrice ?? 0 %> * <%=ManProduct.fnumber ?? 0 %>;

        //女戒主钻和副钻价格
        var WomanZDiamondPrice = <%=WomanProduct.DiamondPrice ?? 0 %> * <%=WomanProduct.znumber ?? 0 %>;
        var WomanFDiamondPrice = <%=WomanProduct.fDiamondPrice ?? 0 %> * <%=WomanProduct.fnumber ?? 0 %>;

        //男戒女戒材质价格
        var ManMaterialPrice = 0;
        var WomanMaterialPrice = 0;
        var CurrentMaterial = "";
        var ManHandsizePrice = 0;
        var WomanHandsizePrice = 0;
        var w,s;

        var RefeshPPriceEvent = function(){
            $(".cpword_left i").text("￥"+formatCurrency(getProductPrice()));
        };

        function getManProductPrice() {
            return ManZDiamondPrice + ManFDiamondPrice + ManMaterialPrice + ManHandsizePrice;
        }
        function getWomanProductPrice() {
            return WomanZDiamondPrice + WomanFDiamondPrice + WomanMaterialPrice + WomanHandsizePrice;
        }

        function getProductPrice()
        {
            return getManProductPrice() + getWomanProductPrice();
        } 

        $(function () {
            s = new Success();
            w = new Wrong();

            MaterialChoosedEvent = function(m, mp,wp){
                CurrentMaterial = m;
                ManMaterialPrice = mp;
                WomanMaterialPrice = wp;
                $("#<%=ucManHandsize.UControlID %>").change();
                $("#<%=ucWomanHandsize.UControlID %>").change();
            };

            <%=ucManHandsize.UControlID %>ChangeEvent = function(option,p){
                ManHandsizePrice = p;
                RefeshPPriceEvent();
            };
            <%=ucWomanHandsize.UControlID %>ChangeEvent = function(option,p){
                WomanHandsizePrice = p;
                RefeshPPriceEvent();
            };

            $(".write_choose").click(function () {
                var txt = $(this).parent("div").find("input");
                txt.val(txt.val() + ($(this).text()).charAt());
            });
        });

        function toBuy() {
            checkComplete = function(info) {
                $.post("/API/AddCartAPI.ashx?cmd=AddCartPh",info, function(data) {
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
                $.post("/API/AddCartAPI.ashx?cmd=AddCartPh",info, function(data) {
                    if (data == "true") {
                        s.Show("添加成功");
                    } else {
                        w.Show(data);
                    }
                });
            };
            addCartFun();
        }
        function strlength(str) { num = str.length; var arr = str.match(/[^\x00-\x80]/ig); if (arr != null) num += arr.length; return num; }
        String.prototype.replaceAll = function (s1, s2) {
            return this.replace(new RegExp(s1, "gm"), s2);
        }
         var checkComplete= function(){};

         function addCartFun() {
            if($("#<%=ucManHandsize.UControlID %>").val() == "-1")
            {
                w.Show("请选择男戒手寸");
                return;
            }
            if($("#<%=ucWomanHandsize.UControlID %>").val() == "-1")
            {
                w.Show("请选择女戒手寸");
                return;
            }
            if (strlength($("#ipt_man").val().replaceAll("♥", "?")) > 8) {
                w.Show("男戒刻字数超过了8个字符，中文为2个字符");
                return;
            }
            if(strlength($("#ipt_woman").val().replaceAll("♥", "?")) > 8)
            {
                w.Show("女戒刻字数超过了8个字符，中文为2个字符");
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
                manhandsize : $("#<%=ucManHandsize.UControlID %>").val() == null?"":$("#<%=ucManHandsize.UControlID%>").val(),
                womanhandsize: $("#<%=ucWomanHandsize.UControlID%>").val() == null?"":$("#<%=ucWomanHandsize.UControlID%>").val(),
                manfont:$("#ipt_man").val(),
                womanfont:$("#ipt_woman").val()
            };
            checkComplete(data);
         }
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
							<uc1:ucHandsize runat="server" ID="ucManHandsize" UControlID="manhandsize"></uc1:ucHandsize>
                            <label>男</label>
							<uc1:ucHandsize runat="server" ID="ucWomanHandsize" UControlID="womanhandsize"></uc1:ucHandsize>
                            <label>女</label>
							<a href="/helpCenter/HandsizeHelp.aspx">如何量手寸？</a>
						</p>
						<p>
							<span class="fl">刻字：</span>
							<div class="hbwidth fl">
                                <div style="margin-bottom:6px">
							        <label>男</label><input type="text" id="ipt_man" class="kz_txt" placeholder="4个汉字或8个字母"/><em class="write_choose">♥</em><em class="write_choose">&</em>
                                </div>
                                <div>
                                    <label>女</label><input type="text" id="ipt_woman" class="kz_txt" placeholder="4个汉字或8个字母"/><em class="write_choose">♥</em><em class="write_choose">&</em>
                                </div>
                            </div>
						</p>
						<p class="sp_color">预计收货时间：付款成功后第<%=getDay()%>个工作日</p>
					</div>
				</div>
				<!--普通参数选择end-->
			</div>
			<!--参数选择end-->
			 <uc1:ucRelatedinfo runat="server" ID="ucRelatedinfo"></uc1:ucRelatedinfo>
            <uc1:ucBuyControl runat="server" ID="ucBuyControl"></uc1:ucBuyControl>
            
</asp:Content>
<asp:Content ContentPlaceHolderID="PageEndJs" ID="pageend" runat="server">

</asp:Content>
