<%@ Page Title="" Language="C#" MasterPageFile="~/master/mSite.Master" AutoEventWireup="true"
    CodeBehind="mactivity.aspx.cs" Inherits="drmobile.mactivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--活动左右滑动-->
    <div id="slideBox4" class="slideBox slideBox4">
        <div class="bd">
            <ul>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <li><a class="pic" href="<%#Eval("artulr")%>">
                            <img src="<%#Eval("mimgurl")%>" /></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="hd sp_hd">
            <ul>
            </ul>
        </div>
    </div>
    <!--活动左右滑动end-->
    <!--粉色区域内-->
    <div class="gray-cort">
        <!--608区域内-->
        <div class="spwidth_608">
            <!--晒粉钻-->
            <div class="show_fz">
                <a href="http://www.darryring.com/goodman/gm.html">
                    <img src="/mimages/dr_ative/pink_it.jpg" />
                </a>
            </div>
            <!--晒粉钻end-->
            <!--明星左右滑动-->
            <div id="slideBox5" class="slideBox">
                <div class="bd">
                    <ul>
                        <li><a class="pic" href="/mstartdetail.aspx?id=2670">
                            <img alt="DR见证：戚薇&李承铉真爱" src="mimages/hd1.jpg" /></a>
                            <div class="cort_word spcort_word">
                                <h3>
                                    戚薇&李承铉</h3>
                                <div class="theword">
                                    <p>
                                        李承铉大胆表白Darry Ring式爱情的一生唯一真爱承诺</p>
                                    <p>
                                        DR见证：戚薇&李承铉真爱
                                    </p>
                                </div>
                                <div class="more_cp star_samecp">
                                    <a href="/dring_detail.aspx?id=348">查看明星同款钻戒</a>
                                </div>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=2675">
                            <img alt=" 著名影星 何晟铭" src="/mimages/m.jpg" /></a>
                            <div class="cort_word spcort_word">
                                <h3>
                                    著名影星 何晟铭</h3>
                                <div class="theword">
                                    <p>
                                        这里面装的不仅仅是一枚钻戒......而是我毕生所有的真爱.....</p>
                                </div>
                                <div class="more_cp star_samecp">
                                    <a href="http://www.darryring.com/mobile/pink_index.aspx">查看明星同款钻戒</a>
                                </div>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=2676">
                            <img alt="《小时代》御用钻戒" src="mimages/xsd.jpg" /></a>
                            <div class="cort_word spcort_word">
                                <h3>
                                    《小时代》御用钻戒</h3>
                                <div class="theword">
                                    <p>
                                        奢侈是精神上的唯一，是真爱的唯一。Darry Ring与小时代也开启了奢侈新定义......
                                    </p>
                                </div>
                                <div class="more_cp star_samecp">
                                    <a href="http://www.darryring.com/mobile/pink_index.aspx">查看明星同款钻戒</a>
                                </div>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=2674">
                            <img alt="情感作家 陆琪" src="mimages/5a.jpg" /></a>
                            <div class="cort_word spcort_word">
                                <h3>
                                    情感作家 陆琪</h3>
                                <div class="theword">
                                    <p>
                                    “一生”的约定，“唯一”的爱人，“真爱”的信仰，这就是Darry Ring式爱情......</p>
                                </div>
                                <div class="more_cp star_samecp">
                                    <a href="/dring_detail.aspx?id=140">查看明星同款钻戒</a>
                                </div>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=3175">
                            <img alt="杜海涛晒Darry Ring" src="/mimages/hd2.jpg" /></a>
                            <div class="cort_word">
                                <h3>
                                    杜海涛</h3>
                                <div class="theword">
                                    <p>
                                    杜海涛晒Darry Ring感慨父母感情好，宣布加入DR族</p>
                                </div>
                                <div class="more_cp star_samecp">
                                    <a href="/dring_detail.aspx?id=379">查看明星同款钻戒</a>
                                </div>
                            </div>
                        </li>
                        <li><a class="pic" href="/mstartdetail.aspx?id=3176">
                            <img alt="陈一冰公开DR族身份" src="/mimages/hd3.jpg" /></a>
                            <div class="cort_word">
                                <h3>
                                    陈一冰</h3>
                                <div class="theword">
                                    <p>
                                    陈一冰公开DR族身份，表白爱妻“任性爱一辈子</p>
                                </div>
                                <div class="more_cp star_samecp">
                                    <a href="/dring_detail.aspx?id=323">查看明星同款钻戒</a>
                                </div>
                            </div>
                        </li>
                    </ul>
                    <span class="img_pre"></span><span class="img_next"></span>
                </div>
            </div>
            <!--明星左右滑动end-->
        </div>
        <!--608区域内end-->
        <script type="text/javascript" src="mjs/TouchSlide.1.1.js"></script>
        <script type="text/javascript">
	TouchSlide({ 
		slideCell:"#slideBox4",
		titCell:".hd ul", //开启自动分页 autoPage:true ，此时设置 titCell 为导航元素包裹层
		mainCell:".bd ul", 
		effect:"leftLoop", 
		autoPage:true,//自动分页
		autoPlay:true, //自动播放
		interTime:4000
	});
	TouchSlide({ 
		slideCell:"#slideBox5",
		titCell:".hd ul", //开启自动分页 autoPage:true ，此时设置 titCell 为导航元素包裹层
		mainCell:".bd ul", 
		effect:"leftLoop", 
	});
        </script>
</asp:Content>
