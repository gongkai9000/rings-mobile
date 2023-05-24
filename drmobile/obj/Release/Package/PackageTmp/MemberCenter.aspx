<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="MemberCenter.aspx.cs" Inherits="drmobile.MemberCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    var s;
    var timer;
    $(function () {
        s = new Success();
        //退出事件
        $(".tcdl").click(function () {
            $.post("/API/MemberAction.ashx?action=signout", function () {
                s.Show("退出登录成功");
                Redirect("/Account/Login.aspx");
            });
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

			<!--头像-->
			<div class="m_tx">
				<img src="/mimages/dr_member/hd.jpg" />
				<div class="m_txword"><%=LoginName %></div>
			</div>
			<!--头像end-->
			<nav class="mb_nav">
				<a href="MyCollect.aspx"><span class="iconfont">&#xe60b;</span>我的收藏</a>
				<a href="Cart.aspx" class="havething"><span class="iconfont">&#xe60c;</span>购物车
                <%if (CartCount > 0)
                  { %>
                <i><%=CartCount%></i>
                <%} %>
                </a>
				<a href="/Comment/MyComment.aspx" style="border:none"><span class="iconfont">&#xe609;</span>我要评价</a>
			</nav>
			<!--详细-->
			<div class="awhrite">
				<ul class="mbxx_all">
					<li>
						<a href="OrderList.aspx">
							<span class="iconfont">&#xe60a;</span>我的订单
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li>
						<a href="http://home.darryring.com/index/main/mid/<%=base64UID %>">
							<span class="sp_zone"></span>专属空间
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li>
						<a href="/Account/MyInfo.aspx">
							<span class="iconfont">&#xe600;</span>个人信息
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li>
						<a href="/Account/ChangePassword.aspx">
							<span class="iconfont">&#xe60e;</span>修改密码
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li>
						<a href="MyAddress.aspx">
							<span class="iconfont">&#xe610;</span>收货地址
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li>
						<a href="MyAfterService.aspx">
							<span class="iconfont">&#xe611;</span>售后办理
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
					<li style="border:none">
						<a href="/CustomerService/Center.aspx">
							<span class="iconfont">&#xe60d;</span>DR官方客服
							<i class="iconfont fr">&#xe605;</i>
						</a>
					</li>
				</ul>
			</div>
			<!--详细end-->
			<!--退出登录-->
			<div class="spwhrite mg_top">
				<a href="javascript:void(0)" class="tcdl">退出登录</a>
			</div>
</asp:Content>
