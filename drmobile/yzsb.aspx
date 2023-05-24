<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="yzsb.aspx.cs" Inherits="drmobile.yzsb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <!--验证的消息-->
    <div class="ctyz_newbk">
        <!--购买过-->
        <div class="ctyz-buy">
            <p class="hmargin sphmargin">
                <span>
                    <%=HttpUtility.HtmlDecode(Request["name"]) %></span>的CTloves还未赠出</p>
            <p>
                这枚象征一生唯一真爱的珍贵 求婚钻戒 / 真爱信物</p>
            <p>
                将会属于谁呢？</p>
        </div>
        <!--购买过end-->
    </div>
    <!--验证的消息end-->
    <!--查看专属页面-->
    
    <!--查看专属页面end-->
    <!--600区域内-->
    <div class="spwidth_600 the_line">
        <!--产品左右滑动-->
        <div id="slideBox3" class="slideBox">
            <div class="bd">
                <ul>
                   <li>
                        <div class="cp_img fl">
                            <img src="/mimages/ct_yz/ring_cp.png" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                CT钻戒 Just you系列 经典款 30分 J色</p>
                            <p>
                                <span>￥8120</span></p>
                            <a href="/ctring_detail.aspx?id=132" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                    <li>
                        <div class="cp_img fl">
                            <img src="/mimages/ct_yz/Forever.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                CT钻戒 Forever系列 经典款50分H色</p>
                            <p>
                                <span>￥23600</span></p>
                            <a href="/ctring_detail.aspx?id=78" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                    <li>
                        <div class="cp_img fl">
                            <img src="mimages/ct_yz/My Heartjd.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                 My Heart系列 经典款 100分 H色</p>
                            <p>
                                <span>￥46800</span></p>
                            <a href="/ctring_detail.aspx?id=93" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                    <li>
                        <div class="cp_img fl">
                            <img src="mimages/ct_yz/My heartsh.jpg" />
                        </div>
                        <div class="cp_word fr">
                            <p>
                                CT钻戒My heart系列 奢华款100f分F色</p>
                            <p>
                                <span>￥50600</span></p>
                            <a href="/ctring_detail.aspx?id=169" class="cpxq_more">商品详情</a>
                        </div>
                    </li>
                </ul>
            </div>
            <span class="img_pre spimg_pre"></span><span class="img_next spimg_next"></span>
        </div>
        <!--产品左右滑动end-->
        <div class="more_cp">
            <a href="/diamondring_list.aspx">选购更多求婚钻戒</a>
        </div>
        <script type="text/javascript" src="mjs/TouchSlide.1.1.js"></script>
        <script type="text/javascript">
            TouchSlide({
                slideCell: "#slideBox3",
                titCell: ".hd ul", //开启自动分页 autoPage:true ，此时设置 titCell 为导航元素包裹层
                mainCell: ".bd ul",
                effect: "leftLoop",
                autoPlay: true, //自动播放
                interTime: 4000
            });
        </script>
</asp:Content>
