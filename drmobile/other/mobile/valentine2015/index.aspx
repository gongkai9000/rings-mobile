<%@ Page Title="" Language="C#" MasterPageFile="~/master/mSite.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="drmobile.other.mobile.valentine2015.index" %>
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
				<img src="img/mbqrj_1.jpg" />
				<img src="img/mbqrj_2.jpg" />
				<!--my heart-->
				<a href="/diamondring_list.aspx?typeid=11">
					<img src="img/mbqrj_3.jpg" />
					<img src="img/mbqrj_4.jpg" />
				</a>
				<!--true love-->
				<a href="/diamondring_list.aspx?typeid=16">
					<img src="img/mbqrj_5.jpg" />
				</a>
				<!--i swear-->
				<a href="/diamondring_list.aspx?typeid=15">
					<img src="img/mbqrj_6.jpg" />
				</a>	
				<!--forever-->
				<a href="/diamondring_list.aspx?typeid=12">
					<img src="img/mbqrj_7.jpg" />
				</a>
				<!--just you-->
				<a href="/diamondring_list.aspx?typeid=13">
					<img src="img/mbqrj_8.jpg" />
					<img src="img/mbqrj_9.jpg" />
				</a>
				<!--Princess-->
				<a href="/diamondring_list.aspx?typeid=17">
					<img src="img/mbqrj_10.jpg" />
					<img src="img/mbqrj_11.jpg" />
				</a>	
				<!--dr对戒-->
				<a href="/phonics_details.aspx?id=323">
					<img src="img/mbqrj_12.jpg" />
					<img src="img/mbqrj_13.jpg" />
				</a>	
				<!--真爱印记-->
				<a href="/phonics_details.aspx?id=408">
					<img src="img/mbqrj_14.jpg" />
					<img src="img/mbqrj_15.jpg" />
				</a>	
				<!--锁住一生套链-->
				<a href="/jewellery_detail.aspx?id=404">
					<img src="img/mbqrj_16.jpg" />
					<img src="img/mbqrj_17.jpg" />
				</a>	
				<!--拥爱套链-->
				<a href="/jewellery_detail.aspx?id=403">
					<img src="img/mbqrj_18.jpg" />
					<img src="img/mbqrj_19.jpg" />
				</a>
				<!--onlylove奢华套链-->
				<a href="/jewellery_detail.aspx?id=402">
					<img src="img/mbqrj_20.jpg" />
					<img src="img/mbqrj_21.jpg" />
				</a>
				<!--onlylove简奢套链-->
				<a href="/jewellery_detail.aspx?id=401">
					<img src="img/mbqrj_22.jpg" />
					<img src="img/mbqrj_23.jpg" />
				</a>
				<!--无限爱意-->
				<a href="/jewellery_detail.aspx?id=393">
					<img src="img/mbqrj_24.jpg" />
					<img src="img/mbqrj_25.jpg" />
				</a>
			</div>
			<!--情人节页面end-->
</asp:Content>
