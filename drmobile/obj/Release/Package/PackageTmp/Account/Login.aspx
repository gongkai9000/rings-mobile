<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="drmobile.Account.Login" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var w;
        $(document).ready(function () {
            w = new Wrong();
        });
        //<%--登陆按钮点击事件 --%>
        $(function () {
            $(".all_dl").click(function () {
                var email = $("#txtEmail").val();
                var pwd = $("#txtPwd").val();
                if (email == "") {
                    w.Exit();
                    w.Show("请输入账号!");
                    return false;
                }
                if (pwd == "") {
                    w.Exit();
                    w.Show("请输入密码!");
                    return false;
                }
                $.post("../API/LoginAPI.ashx", { email: email, pwd: pwd }, function (data) {

                    if (data == "email") {
                        w.Show("请输入邮箱或手机号");
                        return false;
                    }
                    if (data == "pwd") {

                        w.Show("请输入密码!");

                        return false;
                    }
                    if (data == "lock") {

                        w.Show("账号已被锁定!");
                        return false;
                    }
                    if (data == "null") {

                        w.Show("账号不存在!");
                        $("#txtPwd").val("");

                        return false;
                    }
                    if (data == "wrong") {
                        w.Show("密码错误!");
                        $("txtPwd").val("");
                        return false;
                    }
                    var returnUrl = "<%=this.ReturnUrl %>";
                    if (returnUrl != "") {
                        window.location.href = returnUrl;
                    } else {
                        window.location.href = "/MemberCenter.aspx";
                    }
                    $(":input").val("");
                })
            })
        })


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--大的宽度-->

		<!--头部end-->
		<!--灰色区域内-->
		<div class="gray-cort">
			<!--608区域内-->
			<div class="spwidth_608">
				<!--登陆注册区域-->
				<div class="zcdl_all">
					<!--登陆框-->
					<div class="dl_border">
						<div class="wa_position border-bottom clear">
							<input type="text" class="dl_txt" placeholder="请输入邮箱或手机号" id="txtEmail"/>
							<span class="iconfont">&#xe607;</span>
						</div>
						<div class="wa_position clear">
							<input type="password" class="dl_txt" placeholder="请输入密码" id="txtPwd" maxlength="20"/>
							<span class="iconfont">&#xe607;</span>
						</div>
					</div>
					<!--登陆框end-->
					<!--登陆注册-->
					<div class="choose_bt">
						<button class="all_dl fl" type="button">登录</button>
						<a class="all_zc fr" href="Register.aspx">
							注册
						</a>
					</div>
					<!--登陆注册end-->
					<!--第三方登陆-->
					<div class="other_dl">
						<span>第三方账号登录：</span>
						<a href="/Account/LoginToQQ.aspx">
							<img src="/mimages/qq.png" />
						</a>
						<a href="<%=SinaURL %>">
							<img src="/mimages/wb.png" />
						</a>
					</div>
					<!--第三方登陆end-->
					<!--忘记密码-->
					<div class="other_xx">
						<p>
							<a href="ForgetPwd.aspx">忘记密码>></a>
						</p>
						<p>
							<a href="/Feedback.aspx">意见反馈>></a>
						</p>
					</div>
					<!--底下图标-->
					<div class="foot_tb">
						<img src="/mimages/db.png" />
					</div>
					<!--底下图标end-->
				</div>
				<!--登陆注册区域end-->
			</div>
			<!--608区域内end-->
			<!--底部-->
		<!--灰色区域内end-->
</div>
   
	<!--大的宽度end-->
</asp:Content>
