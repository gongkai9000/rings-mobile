<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="Center.aspx.cs" Inherits="drmobile.CustomerService.Center" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <!--详细-->
			<div class="awhrite">
				<ul class="mbxx_all kfzx_all">
					<li>
						<a href="Detail.aspx?type=1">
							<span class="sp_store"></span>官网店铺
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li>
						<a href="Detail.aspx?type=2">
							<span class="sp_question"></span>真爱疑问
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
                    <li>
						<a href="Detail.aspx?type=3">
							<span class="sp_gmxz"></span>购买限制
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li>
						<a href="Detail.aspx?type=4">
							<span class="sp_cp"></span>产品疑问
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li>
						<a href="Detail.aspx?type=5">
							<span class="sp_dz"></span>关于定制
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li>
						<a href="Detail.aspx?type=6">
							<span class="sp_fh"></span>关于运输
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
                    <li>
						<a href="Detail.aspx?type=7">
							<span class="sp_gysh"></span>关于售后
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
                    <li>
						<a href="/Feedback.aspx">
							<span class="sp_yjfk"></span>意见反馈
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li style="border:none">
						<a href="javascript:NTKF.im_openInPageChat()">
							<span class="sp_zxkf"></span>在线客服
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
				</ul>
			</div>
			<!--详细end-->
			<div class="thetel">
				<p>如有更多问题，关注微信服务号<i>“DarryRing真爱戒指”</i>，随时咨询！</p>
			</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">
<script language="javascript" type="text/javascript">
    NTKF_PARAM = {
        siteid: "kf_9883",                            //Ntalker提供平台基础id,
        settingid: "kf_9883_1402631963601",          //Ntalker分配的缺省客服组id  
        uid: "<%=UserID %>",                                //用户id
        uname: "<%=NickName %>",                     //用户名              
        orderid: "",                     //订单id
        orderprice: "",                        //订单价格
    };
</script>
   <script type="text/javascript" src="http://dl.ntalker.com/js/xn6/ntkfstat.js?siteid=kf_9883" charset="utf-8"></script>
</asp:Content>
