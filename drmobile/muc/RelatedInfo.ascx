<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedInfo.ascx.cs" Inherits="drmobile.muc.RelatedInfo" %>
<%@ Register Src="/muc/Paging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<%@ Register Src="/muc/infoview.ascx" TagName="ucInfoview" TagPrefix="uc1" %>
<script src="/mjs/jquery.lazyload.min.js" type="text/javascript"></script>
<script type="text/javascript">
    var CommentLoadEvent = function () { };
    function CommentLoadData(currentPageNum) {
        $.get("/API/Comment.aspx?pagenum=" + currentPageNum + "&pid=<%=CurrentProduct.id %>", function (data) {
            $("#commentContent").append(data);
            __CurrentPagingComment.CurrentPageNum = currentPageNum;
            __CurrentPagingComment.LoadComplete();

            //总条数
            $(".thenav_ul-all i").text("（" + CommentDataCount + "）");
            
        });
    }
    $(function () {
        __CurrentPagingComment.CustomChanged = function (num) {
            CommentLoadData(num);
        };
        setTimeout(function () {
            CommentLoadData(__CurrentPagingComment.CurrentPageNum);
        }, 400);
    });
    $(function () {
        //        $(".shop_one img").hide();
        $(".shop_one img").each(function () {
            var src = $(this).attr("src");
            $(this).removeAttr("src");
            $(this).attr("data-original", src);
            //默认隐藏
            //            $(this).hide();
        });
        $(".shop_one img").lazyload({
            effect: "fadeIn",
            threshold: 150
        });
    });  
</script>
            <!--商品导航-->
			<div class="thenav_ul">
				<!--第一个-->
				<div class="thenav_ulatl">
					<div class="thenav_ul-all">
						<p>图文详情</p>
					</div>
					<!--图文详情-->
			        <!--商品导航end-->
                    <div class="shop_allit shop_one" >
                        <%=CurrentProduct.mobile_pcontent%>
                    </div>
                 </div>

                <!--第二个-->
				<div class="thenav_ulatl">
					<div class="thenav_ul-all">
						<p>商品参数</p>
					</div>
					<!--商品参数-->
				    <!--商品参数-->
				    <div class="shop_allit shop_sec">
                        <uc1:ucInfoview runat="server" id="ucInfoview"></uc1:ucInfoview>
				    </div>
				    <!--商品参数end-->
                </div>
                <!--第二个end-->
				<!--第三个-->
				<div class="thenav_ulatl">
					<div class="thenav_ul-all">
						<p>累计评价<i>（）</i></p>
					</div>
					<!--累计评价-->
				    <!--累计评价-->
				    <div class="shop_allit shop_three">
                        <div id="wrapper" style="height:600px">
                        <div>
					    <ul class="shop_three-ul" id="commentContent">
					
					    </ul>
                        <div id="pullUp"></div>
                        </div>
                        </div>
				    </div>
				    <!--累计评价end-->
                </div>
           </div>
            <uc1:ucPaging runat="server" ID="ucPaging" ClientObjectName="__CurrentPagingComment" SrollControlID="wrapper"></uc1:ucPaging>
