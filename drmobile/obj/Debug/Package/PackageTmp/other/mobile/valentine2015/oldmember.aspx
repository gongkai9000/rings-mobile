<%@ Page Title="" Language="C#" MasterPageFile="~/master/mSite.Master" AutoEventWireup="true" CodeBehind="oldmember.aspx.cs" Inherits="drmobile.other.mobile.valentine2015.oldmember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style>
		.mbqrj img{width:100%}
		.mbqrj a{display:block}
	</style>
    <script src="/mjs/jquery.lazyload.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //        $(".shop_one img").hide();
            $(".mbqrj img").each(function () {
                var src = $(this).attr("src");
                $(this).removeAttr("src");
                $(this).attr("data-original", src);
                //默认隐藏
                //            $(this).hide();
            });
            $(".mbqrj img").lazyload({
                effect: "fadeIn",
                threshold: 200
            });
        });  
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--情人节页面-->
<div class="mbqrj">
	<img src="img/oldqrj_1.jpg" />
	<img src="img/oldqrj_2.jpg" />	
	<!--锁住一生套链-->
	<a href="/jewellery_detail.aspx?id=404">
		<img src="img/oldqrj_3.jpg" />
	</a>	
	<!--拥爱套链-->
	<a href="/jewellery_detail.aspx?id=403">
		<img src="img/oldqrj_4.jpg" />
	</a>
	<!--onlylove奢华套链-->
	<a href="/jewellery_detail.aspx?id=402">
		<img src="img/oldqrj_5.jpg" />
	</a>
	<!--onlylove简奢套链-->
	<a href="/jewellery_detail.aspx?id=401">
		<img src="img/oldqrj_6.jpg" />
	</a>
	<!--无限爱意-->
	<a href="/jewellery_detail.aspx?id=393">
		<img src="img/oldqrj_7.jpg" />
	</a>
</div>
<!--情人节页面end-->
</asp:Content>
