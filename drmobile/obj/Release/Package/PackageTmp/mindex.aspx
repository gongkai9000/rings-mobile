<%@ Page Title="" Language="C#" MasterPageFile="~/master/mSite.Master" AutoEventWireup="true"
    CodeBehind="mindex.aspx.cs" Inherits="drmobile.mindex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="canonical" href="http://m.darryring.com/" />
    <meta name="Description" content="香港戴瑞珠宝Darry Ring(DR)官网手机站，每位男士凭身份证一生只可购买一枚,最独特的求婚钻戒,购钻授予真爱证书,可定制专属页面,证明与找寻一生唯一真爱的首选。"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--购买资格查询-->
	<div class="zg_search">
        <a href="/brand.aspx">
		    <img src="/mimages/fbaner.jpg" alt="男士一生仅能定制一枚" /> 
        </a>
		<div class="searchit searchit_nobk">
			<a href="/dryz.aspx">
				<img src="/mimages/zs_search.png" />
			</a>
		</div>
	</div>
	<!--购买资格查询end-->

        <!--608区域内-->
        <div class="spwidth_608">
            <!--真爱至上-->
			<a href="fansshow.aspx" class="thelove_zs">
				<img src="/mimages/love_zs.jpg" alt="真爱至上" />
			</a>
			<!--真爱至上end-->
            <!--产品左右滑动-->
            <div id="slideBox" class="slideBox">
                <div class="bd">
                    <ul>
                        <li><a class="pic" href="/diamondring_list.aspx?type=12">
                            <img src="/mimages/1Forever1.jpg" alt="darry ring forever系列" /></a> </li>
<%--                        <li><a class="pic" href="http://www.darryring.com/mobile/pink_index.aspx">
                            <img src="/mimages/2Marry-me1.jpg" alt="darry ring marry me系列" /></a> </li>--%>
                        <li><a class="pic" href="/diamondring_list.aspx?type=11">
                            <img src="/mimages/3My-heart1.jpg" alt="darry ring my heart系列" /></a> </li>
                        <li><a class="pic" href="/diamondring_list.aspx?type=16">
                            <img src="/mimages/4True-Love1.jpg" alt="darry ring ture love系列" /></a> </li>
                        <li><a class="pic" href="/diamondring_list.aspx?type=15">
                            <img src="/mimages/5I-Swear1.jpg"  alt="darry ring i swear系列"/></a> </li>
                    </ul>
                </div>
                <div class="hd">
                    <ul>
                    </ul>
                </div>
            </div>
            <!--产品左右滑动end-->
            <!--粉钻预约-->
			<a href="http://www.darryring.com/mobile/pink_index.aspx" class="thelove_zs thelove_bot">
				<img src="/mimages/fzit.jpg" />
			</a>
			<!--粉钻预约end-->
            <!--明星左右滑动-->
            <div id="slideBox2" class="slideBox slideBox2">
                <div class="bd">
                    <ul>
                        <li><a class="pic" href="/mstartdetail.aspx?id=2670">
                            <img alt="DR见证：戚薇&李承铉真爱" src="/mimages/hd1.jpg" /></a>
                            <div class="cort_word">
                                <h3>
                                    戚薇&李承铉</h3>
                                <p>
                                    李承铉大胆表白Darry Ring式爱情的一生唯一真爱承诺</p>
                                <p>
                                    DR见证：戚薇&李承铉真爱
                                </p>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=2675">
                            <img alt="著名影星 何晟铭" src="/mimages/m.jpg" /></a>
                            <div class="cort_word">
                                <h3>
                                    著名影星 何晟铭</h3>
                                <p>
                                    这里面装的不仅仅是一枚钻戒......而是我毕生所有的真爱.....
                                </p>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=2676">
                            <img alt="《小时代》御用钻戒" src="/mimages/xsd.jpg" /></a>
                            <div class="cort_word">
                                <h3>
                                    《小时代》御用钻戒</h3>
                                <p>
                                    奢侈是精神上的唯一，是真爱的唯一。Darry Ring与小时代也开启了奢侈新定义......</p>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=2674">
                            <img alt="情感作家 陆琪" src="/mimages/5a.jpg" /></a>
                            <div class="cort_word">
                                <h3>
                                    情感作家 陆琪</h3>
                                <p>
                                    “一生”的约定，“唯一”的爱人，“真爱”的信仰，这就是Darry Ring式爱情......</p>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=3175">
                            <img alt="杜海涛晒Darry Ring" src="/mimages/hd2.jpg" /></a>
                            <div class="cort_word">
                                <h3>
                                    杜海涛</h3>
                                <p>
                                    杜海涛晒Darry Ring感慨父母感情好，宣布加入DR族</p>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=3176">
                            <img alt="陈一冰公开DR族身份" src="/mimages/hd3.jpg" /></a>
                            <div class="cort_word">
                                <h3>
                                    陈一冰</h3>
                                <p>
                                    陈一冰公开DR族身份，表白爱妻“任性爱一辈子</p>
                            </div>
                        </li>
                    </ul>
                    <span class="img_pre"></span><span class="img_next"></span>
                </div>
            </div>
            <!--明星左右滑动end-->
            <!--实体店铺-->
			<div class="shop_fz fix">
				<p class="fr">
					<a href="/shop.aspx">
						查看更多实体店>
					</a>
				</p>
				<a href="/shop.aspx">
					<img src="/mimages/thestore.png" />
				</a>
			</div>
			<!--实体店铺end-->
        </div>
        <!--608区域内end-->
        <!--售后-->
		<div class="shou_servies">
			<img src="/mimages/shou.jpg" />
			<div class="shou_servies-cort">
				<img src="/mimages/wad.png" />
			</div>
		</div>
		<!--售后end-->

        <script type="text/javascript" src="/mjs/TouchSlide.1.1.js"></script>
        <script type="text/javascript">
	    TouchSlide({ 
		    slideCell:"#slideBox",
		    titCell:".hd ul", //开启自动分页 autoPage:true ，此时设置 titCell 为导航元素包裹层
		    mainCell:".bd ul", 
		    effect:"leftLoop", 
		    autoPage:true,//自动分页
		    autoPlay:true, //自动播放
		    interTime:4000
	    });
	    TouchSlide({ 
		    slideCell:"#slideBox2",
		    titCell:".hd ul", //开启自动分页 autoPage:true ，此时设置 titCell 为导航元素包裹层
		    mainCell:".bd ul", 
		    effect:"leftLoop", 
	    });
        </script>

        <%if (isShowInfo)
        {%>
		<!--温馨提示-->
		<div class="wx_show">
			<div class="wx_show-center">
				<img src="/mimages/wx.png" />
				<div class="wx_show-close"></div>
				<a href="javascript:void(0)" class="wx_show-kf"></a>
			</div>	
		</div>
        <script type="text/javascript">
            $(".bk_gray").show();
            $(function () {
                $(".wx_show-kf").click(function () {
                    NTKF.im_openInPageChat();
                    return false;
                });
                setTimeout(function () { $(".wx_show").click(); }, 30 * 1000);
            });
        </script>
		<!--温馨提示end-->
        <%} %>
</asp:Content>
