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
						<a href="http://p.qiao.baidu.com/cps/chat?siteId=7987903&userId=10961419&siteToken=b07c4b73bf804aab414c172651a4e5d3">
							<span class="sp_zxkf"></span>在线客服
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
				</ul>
			</div>
			<!--详细end-->
			<div class="thetel">
				<p>如有更多问题，关注微信服务号<i>“CTloves006”</i>，随时咨询！</p>
			</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">

</asp:Content>
