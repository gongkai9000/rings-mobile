<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductImgView.ascx.cs" Inherits="drmobile.muc.ProductImgView" %>
<%@ Import Namespace="DRM.Common" %>
<script type="text/javascript">
    /*收藏事件*/
    var favoritesEvent = function () { };
    /*收藏样式*/
    function favoritesCss(isF) {
        if (isF) {
            $(".cpword_right span").addClass("sc_click");
            $(".cpword_right em").text("已收藏");
            $(".cpword_right span").unbind("click");
        }
        else {
            $(".cpword_right span").removeClass("sc_click");
            $(".cpword_right em").text("收藏");
            $(".cpword_right span").click(favoritesEvent);
        }
    }
    $(function () {
        try {
            favoritesEvent = function () {
                var _self = this;
                $(_self).unbind("click");
                var price = getProductPrice();
   
                $.get("/API/favorites.ashx?action=add&pid=<%=ProductID %>&diamondid=" + "<%=FavoriteDID %>" + "&price=" + price, function (msg) {
                    $(_self).click(favoritesEvent);
                    if (msg != "") {
                        w.Show(msg);
                    }
                    else {
                        favoritesCss(true);
                        s.Show("收藏成功")
                    }
                }, "html");
            };
        }
        catch (e) { }
        $(".cpword_right").click(function () {
            if ('<%=CurrentUser.IsLogin.ToString().ToLower() %>' == 'false') {
                w.Show("请登录！");
                Redirect('/Account/Login.aspx?returnUrl=<%=Url%>');
            }
        });

    });
         function formatCurrency(num) {
            num = num.toString().replace(/\$|\,/g, '');
            if (isNaN(num))
                num = "0";
            sign = (num == (num = Math.abs(num)));
            num = Math.floor(num * 100 + 0.50000000001);
            cents = num % 100;
            num = Math.floor(num / 100).toString();
            if (cents < 10)
                cents = "0" + cents;
            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
                num = num.substring(0, num.length - (4 * i + 3)) + ',' +
             num.substring(num.length - (4 * i + 3));
            var str = (((sign) ? '' : '-') + num + '.' + cents);
            str = str.substr(0, str.length - 3);
            return str;
        }
</script>
 <!--商品区域-->
			<div class="allcp_whrite">
				<!--商品滑动-->
				<div id="slideBox" class="slideBox slideBox5">
					<div class="bd">
						<ul>
                            <asp:Repeater runat="server" ID="rpImg">
                                <ItemTemplate>
                                    <li>
								    <img alt='<%=GetTitle(CurrentProduct.productTypeId)%>' src="<%#Eval("imgurl") %>" />
							        </li>
                                </ItemTemplate>
                            </asp:Repeater>
						</ul>
					</div>
					<div class="hd">
						<ul></ul>
					</div>
				</div>
				<!--商品滑动end-->
				<div class="thecp_allword otherer-bottom">
					<div class="cpword_left fl">
						<h4><%=GetTitle(CurrentProduct.productTypeId)%></h4>
						<p><i>￥</i></p>
						<p>
							<span>销量：<%=CurrentProduct.salecount%></span>
							<span>收藏：<%=CollectCount %></span>
						</p>
					</div>
					<div class="cpword_right fr">
						<a href="javascript:void(0)">
							<span></span>
							<em>收藏</em>
						</a>
					</div>
				</div>
			</div>
<script type="text/javascript" src="/mjs/TouchSlide.1.1.js" ></script>
<script type="text/javascript">
    TouchSlide({
        slideCell: "#slideBox",
        titCell: ".hd ul", //开启自动分页 autoPage:true ，此时设置 titCell 为导航元素包裹层
        mainCell: ".bd ul",
        effect: "leftLoop",
        autoPage: true, //自动分页
        autoPlay: true, //自动播放
        interTime: 4000
    });
</script>	