<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="drmobile.Account.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var w;
        var s;
        $(document).ready(function () {
            w = new Wrong();
            s = new Success();
        });
        var timer = null;
        $(function () {
            //        <%-- 注册按钮点击事件 --%>
            $("#btnSubmit").click(function () {

                var oldpwd = $("#oldpwd").val();
                var newpwd = $("#newpwd").val();
                var newpwd2 = $("#newpwd2").val();

                if (oldpwd == "" || newpwd == "" || newpwd2 == "") {
                    w.Show("密码不能为空！");
                    return;
                }

                if (oldpwd.length < 6 || oldpwd.length > 20 || newpwd.length < 6 || newpwd.length > 20 || newpwd2.length < 6 || newpwd2.length > 20) {
                    w.Show("密码长度必须在6到20个字符。");
                    return;
                }

                if (newpwd != newpwd2) {
                    w.Show("新密码不一致。");
                    $("#newpwd").val("");
                    $("#newpwd2").val("");
                    return;
                }

                $.post("../API/MemberAction.ashx?action=changepwd", { oldpwd: oldpwd, newpwd: newpwd, newpwd2: newpwd2 }, function (data) {
                    if (data == "") {
                        s.Show("修改成功，即将进行跳转！");
                        $(":input").val("");
                        Redirect("/MemberCenter.aspx");
                    }
                    else {
                        $("#oldpwd").val("");
                        w.Show(data);
                    }
                });
            });
        })
     
        function isEmail(strEmail) {
            if (strEmail.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
                return true;
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--608区域内-->
			<div class="spwidth_608">
				<!--绑定账号区域-->
				<div class="zcdl_all">
					<!--绑定账号框-->
					<div class="zc_border">
						<div class="wa_position haveborder clear">
							<input type="password" class="dl_txt" placeholder="请输入旧密码" id="oldpwd"/>
							<span class="iconfont">&#xe607;</span>
						</div>
						<div class="wa_position haveborder clear">
							<input type="password" class="dl_txt" placeholder="请输入新密码" id="newpwd" maxlength="20"/>
							<span class="iconfont">&#xe607;</span>
						</div>
						<div class="wa_position haveborder clear">
							<input type="password" class="dl_txt" placeholder="请确认新密码" id="newpwd2" maxlength="20"/>
							<span class="iconfont">&#xe607;</span>
						</div>
						<p>
							<a href="ForgetPwd.aspx">忘记密码？</a>
						</p>
					</div>
					<!--绑定账号框end-->
					<!--登陆注册-->
					<div class="the_bt">
						<button type="button" id="btnSubmit">提交</button>
					</div>
					<!--登陆注册end-->
				</div>
				<!--绑定账号区域end-->
			</div>
</asp:Content>
