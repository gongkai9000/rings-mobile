<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="dring_list.aspx.cs" Inherits="drmobile.dring_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title></title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--返回选项-->
<div class="fhx">
	<a href="manr_list.html">返回</a>
    <span id="txt_title" runat="server"></span>
</div>
<!--购买详情-->
<!--大图-->
<div id="wrapper" class="wrapper">
	<div id="scroller" class="scroller">
		<ul id="thelist">
        	<li>
            	<img src="images/tr.jpg" width="124" height="174" />
            </li>
            <li>
            	<img src="images/tr.jpg" width="124" height="174" />
            </li>
		</ul>
	</div>
</div>
<!--选择栏-->
<ul class="nav_choose">
	<li class="orther_bk">详情</li>
    <li>参数</li>
    <li>评论</li>
    <li>购钻知识</li>
</ul>
<div class="all_ym">
    <!--购买页详情页-->
    <div class="buything" id="toit">
        <!--名字价钱-->
        <div class="thing_pirce thing_all">
            <p><%=pmodel.Title %></p>
            <span><%=pmodel.MemberPrice%></span>
        </div>
        <!--参数数字-->
        <div class="thing_all">
            <p>商品参数</p>
            <ul class="cs_ul">
                <li>
                    主钻重量：0.5ct
                </li>
                <li>
                    钻石净度：VS2
                </li>
                <li>
                    钻石颜色：H
                </li>
                <li>
                    钻石切工：3EX
                </li>
            </ul>
        </div>
        <!--选择大小-->
        <div class="thing_all">
            <div class="tall_top">
                <label>手寸</label>
                <select class="set_1">
                    <option>5</option>
                    <option>4</option>
                </select>
                <label>材质</label>
                <div class="cz_choose">18k白金</div>
                <div class="cz_choose to_color">pt950</div>
            </div>
            <div class="tall_bottom">
                <label>刻字</label>
                <input type="text" class="ipt_1" id="ipt_1"/>
                <div class="write_choose">&hearts;</div>
                <div class="write_choose">&amp;</div>
            </div>
        </div>
        <!--更换钻石-->
        <div class="thing_all">
            <p>更换钻石</p>
            <ul class="jewel_ul">
                <li class="lother">
                    1克拉J色
                </li>
                <li>
                    1克拉J色
                </li>
                <li>
                    1克拉J色
                </li>
                <li>
                    1克拉J色
                </li>
                <li>
                    1克拉J色
                </li>
                <li>
                    1克拉J色
                </li>
            </ul>
        </div>
        <!--购买和购物车-->
        <div class="buy_it">
            <a href="#" class="buy">立即购买</a>
            <a href="#">加入购物车</a>
        </div>
        <!--列表-->
        <ul class="list">
            <li>
                <span>></span>
                <a href="#" target="_blank">商品详情</a>
            </li>
            <li>
                <span>></span>
                <a href="#" target="_blank">购钻知识</a>
            </li>
            <li>
                <span><i>好评率 97.01%</i>></span>
                <a href="#" target="_blank">客户评价</a>
            </li>
            <li>
                <span>></span>
                <a href="#" target="_blank">售后服务</a>
            </li>
        </ul>
        <!--其他选择-->
        <div class="thing_all orther_ring">
            <p>浏览过此商品的用户还看了</p>
            <ul class="ring_ul">
                <li>
                	<a href="#" target="_blank">
                    	<img src="images/sp_ring.jpg" width="41" height="51"/>
                    </a>    
                </li>
                <li>
                    <a href="#" target="_blank">
                    	<img src="images/sp_ring.jpg" width="41" height="51"/>
                    </a>  
                </li>
                <li>
                    <a href="#" target="_blank">
                    	<img src="images/sp_ring.jpg" width="41" height="51"/>
                    </a>  
                </li>
                <li>
                    <a href="#" target="_blank">
                    	<img src="images/sp_ring.jpg" width="41" height="51"/>
                    </a>  
                </li>
            </ul>
        </div>
    </div>
    
    <!--参数详情页-->
    <div class="to_know" style="display:none" id="toit">
        <!--参数数字-->
        <div class="thing_all">
            <p>款式信息：</p>
            <ul class="cs_ul">
                <li>
                    产品编号：DNJ0061
                </li>
                <li>
                    证书类型： GIA
                </li>
                <li>
                    证书号：
                </li>
                <li>
                    金重：2.5
                </li>
                <li>
                    材质：18K白金,PT950	
                </li>
            </ul>
        </div>
        <!--参数数字-->
        <div class="thing_all">
            <p>钻石信息：</p>
            <ul class="cs_ul">
                <li>
                    总克拉重量：0.5ct
                </li>
            </ul>
        </div>
        <!--参数数字-->
        <div class="thing_all">
            <p>主钻信息：</p>
            <ul class="cs_ul">
                <li>
                    主钻总重量：0.5
                </li>
                <li>
                    主钻数量：1
                </li>
                <li>
                    平均净度：VS2
                </li>
                <li>
                    平均颜色：H
                </li>
                <li>
                    平均切工：3EX
                </li>
            </ul>
        </div>
        <!--参数数字-->
        <div class="thing_all special_ring">
            <p>副钻信息：</p>
            <ul class="cs_ul">
                <li>
                    副钻总重量：
                </li>
                <li>
                    副钻数量：
                </li>
                <li>
                    平均净度： 
                </li>
                <li>
                    平均颜色：
                </li>
                <li>
                    平均切工：
                </li>
            </ul>
        </div>
    </div>
    
    <!--评论页-->
    <div class="talk_it" style="display:none" id="toit">
        <!--评论-->
        <div class="thing_all talk_ring">
            <p>颜色color</p>
            <span>2014/3/10 15:31:18</span>
            <div class="know_ring">
                <p>昨天发货今天收到，快递很给力，钻石很闪，就是感觉没图片的大，当然大家都知道，图片是要放大的，感觉指环稍微细了点，总的来说，还是很满意，有机会一定推荐!</p>
            </div>
        </div>    
        <!--评论-->
        <div class="thing_all talk_ring">
            <p>颜色color</p>
            <span>2014/3/10 15:31:18</span>
            <div class="know_ring">
                <p>昨天发货今天收到，快递很给力，钻石很闪，就是感觉没图片的大，当然大家都知道，图片是要放大的，感觉指环稍微细了点，总的来说，还是很满意，有机会一定推荐!</p>
            </div>
        </div>    
        <!--评论-->
        <div class="thing_all talk_ring">
            <p>颜色color</p>
            <span>2014/3/10 15:31:18</span>
            <div class="know_ring">
                <p>昨天发货今天收到，快递很给力，钻石很闪，就是感觉没图片的大，当然大家都知道，图片是要放大的，感觉指环稍微细了点，总的来说，还是很满意，有机会一定推荐!</p>
            </div>
        </div>    
    </div>
    
    <!--购钻知识页-->
    <div class="buyr_know" style="display:none" id="toit">
        <!--参数数字-->
        <div class="thing_all">
            <p>重量Carat</p>
            <div class="know_ring">
                <p>钻石的重量是4c中最容易度量的特征，与其它宝石一样，钻石的重量也用克拉来计量。一克拉等于0.2g，每一克拉分为一百分（或相当于200毫克），因此一颗25分的钻石重0.25克拉。同等品质的钻石，重量越大越珍贵，一颗某级品质的2克拉钻石常常要比2颗同样品质的1克拉钻石要来得昂贵。</p>
            </div>
        </div>
        <!--参数数字-->
        <div class="thing_all">
            <p>净度Clarity</p>
            <div class="know_ring">
                <p>当注视钻石时， 有可能会看见“瑕疵”或“内含物”——通常随着晶体组成或扭曲时而形成。净度代表钻石的透明程度，主要是从它的体积、位置和内含物的数量与瑕疵来评级。宝石学家在检视钻石时，会使用 10 倍放大镜来鉴定钻石净度的 11 个等级。</p>
            </div>
        </div>
        <!--参数数字-->
        <div class="thing_all">
            <p>颜色color</p>
            <div class="know_ring">
                <p>D级：完全无色。最高色级，极其稀有。</p>
                <p>E级：无色。仅仅只有宝石鉴定专家能够检测到微量颜色。是非常稀有的钻石。</p>
                <p>F级：无色。少量的颜色只有珠宝专家可检测到，但是仍被认为是无色级。属于高品质钻石。</p>
                <p>G—H级：接近无色。当和较高色级钻石比较时，有轻微的颜色。但是这种色级的钻石仍然拥有很高的价值。</p>
                <p>I—J级：接近无色。可检测到轻微的颜色。价值较高。</p>
            </div>
        </div>    
        <!--参数数字-->
        <div class="thing_all special_ring">
            <p>切工cut</p>
            <div class="know_ring">
                <p>切工是指它的切磨比率的精确性和修饰完工后的完美性。好的切工应该尽可能的体现钻石的亮度和火彩，并且尽量保持原石重量。</p>
                <p>GIA把钻石切工分为5个级别:</p>
                <p>Excellent(完美)   Verygood(非常好)</p>
                <p>Good(好)     Fair(一般)    Poor(差)</p>
                <p>中国国检分为:</p>
                <p>EX(优)　VG(很好)　G(好) </p>
                <p>官方配置切工EX：切工、抛光、对称保证一项参数EX，剩余两项VG。如需指定或升级切工三项参数，可联系客服询价。</p>
            </div>
        </div>
    </div>
</div>
<!--底下导航-->
<ul class="foot_ul">
	<li>
    	<a href="#">登录</a>
    </li>
    <li>
    	<a href="#">标准版</a>
    </li>
    <li>
    	<a href="#">电脑版</a>
    </li>
    <li>
    	<a href="#">意见反馈</a>
    </li>
    <li class="ful_sp">
    	<a href="#top">Top</a>
    </li>
</ul>

<script type="text/javascript" src="Scripts/jquery.js"></script>
<script type="text/javascript" src="Scripts/buyit.js"></script>
<script type="text/javascript" src="Scripts/iscroll.js"></script>
<script type="text/javascript" src="Scripts/to_hd.js"></script>
</asp:Content>
