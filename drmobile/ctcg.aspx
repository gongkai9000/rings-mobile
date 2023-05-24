<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="drcg.aspx.cs" Inherits="drmobile.drcg" %>

<%@ Import Namespace="DRM.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>已经购买过CTloves戒指-CTloves官网</title>
    <script type="text/javascript" src="mjs/TouchSlide.1.1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--验证的消息-->
    <div class="ctyz_newbk">
        <!--购买过-->
        <div class="ctyz-buy">
            <p class="hmargin">
                <span>
                    <%=HttpUtility.HtmlDecode(Request["name"]) %></span> 的CTloves已经赠出</p>
            <p>
                钻戒绑定爱人姓名:
                <%=HttpUtility.HtmlDecode(Request["gName"]) %></p>
            <p>
                钻戒定制日期：
                <%=HttpUtility.HtmlDecode(Request["date"]) %></p>
            <p>
                以上CTloves绑定信息终生不可更改</p>
        </div>
        <!--购买过end-->
    </div>
    <!--验证的消息end-->
    <!--查看专属页面-->
    <div class="look_other">
        <a href="http://z.ctloves.com/index.php/index/index/mid/<%=Base64Helper.Base64Encrypt(HttpUtility.HtmlDecode(Request["id"]??"MQ==")) %>">
            查看专属页面</a>
    </div>
    <!--查看专属页面end-->
    <!--600区域内-->
    <div class="spwidth_6002">
    
    <div class="loveSay">
						<p><em style="color:;font-weight:bold;"><%=HttpUtility.HtmlDecode(Request["name"]) %></em>，愿意将代表自己一生唯一真爱的CTloves赠予他的真爱 <em style="color:;font-weight:bold;"><%=HttpUtility.HtmlDecode(Request["gName"]) %></em> ，自协议生效之后，无论发生任何变动，CTloves的赠送对象信息都不可有任何变动。</p>
						<p>CTloves编码与<%=HttpUtility.HtmlDecode(Request["name"]) %>的身份证号绑定，可以随时在官网查询。</p>
					</div>
					<div class="love_people">
						<dl class="clearfix">
							<dd class="man"><img src="http://z.ctloves.com/bundles/acmefrontend/images/top/sect_zhenai01.jpg"><label><%=HttpUtility.HtmlDecode(Request["name"]) %></label></dd>
							<dd class="cen"><img src="http://m.ctloves.com/mimages/logoctzc.png"></dd>
							<dd class="women"><img src="http://z.ctloves.com/bundles/acmefrontend/images/top/sect_zhenai01.jpg"><label><%=HttpUtility.HtmlDecode(Request["gName"]) %></label></dd>
						</dl>
					</div>
					<div class="love_sales">定制于： <%=HttpUtility.HtmlDecode(Request["date"]) %></div>
    
    </div>
        <!--产品左右滑动-->
        <!--<div id="slideBox3" class="slideBox">
            <div class="bd">
                <ul>
                    <li>
                        <div class="cp_img fl">
                            <img src="/mimages/dr_yz/5.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                CTloves对戒My heart系列 简约对戒</p>
                            <p>
                                <span>￥5980</span></p>
                            <a href="/phonics_details.aspx?id=328" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                    <li>
                        <div class="cp_img fl">
                            <img src="/mimages/dr_yz/6.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                CTloves对戒Forever系列 挚爱对戒</p>
                            <p>
                                <span>￥4860</span></p>
                            <a href="/phonics_details.aspx?id=365" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                    <li>
                        <div class="cp_img fl">
                            <img src="mimages/dr_yz/7.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                               CTloves男戒 勇者男戒 10分H色</p>
                            <p>
                                <span>￥6556</span></p>
                            <a href="/manring_detail.aspx?id=369" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                    <li>
                        <div class="cp_img fl">
                            <img src="mimages/dr_yz/8.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                CTloves男戒 天骄男戒 15分H色</p>
                            <p>
                                <span>￥7400</span></p>
                            <a href="/manring_detail.aspx?id=368" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                </ul>
            </div>
            <span class="img_pre spimg_pre"></span><span class="img_next spimg_next"></span>
        </div>
        产品左右滑动end
        <div class="more_cp">
            <a href="/phonics_list.aspx">选购更多对戒饰品</a>
        </div>
        <script type="text/javascript" src="/mjs/TouchSlide.1.1.js"></script>
        <script type="text/javascript">
            TouchSlide({
                slideCell: "#slideBox3",
                titCell: ".hd ul", //开启自动分页 autoPage:true ，此时设置 titCell 为导航元素包裹层
                mainCell: ".bd ul",
                effect: "leftLoop",
		        autoPlay:true, //自动播放
		        interTime:4000
            });
        </script>-->



</asp:Content>
