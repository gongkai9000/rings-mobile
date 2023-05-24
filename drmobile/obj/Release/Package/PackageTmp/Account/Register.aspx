<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="drmobile.Account.Register" %>

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
            $("#btnRegister").click(function () {

                var mobile = $("#txtMobile").val();
                if (mobile == "") {
                    w.Show("手机号不能为空");
                    return;
                }
                if (!checkMobile(mobile)) {
                    w.Show("手机号格式不正确");
                    return;
                }

                var code = $("#txtCode").val();
                if (code == "") {
                    w.Show("验证码不能为空。");
                    return;
                }

                var pwd = $("#txtPwd").val();
                var pwd1 = $("#txtPwd1").val();
                if (pwd == "" || pwd1 == "") {
                    w.Show("密码不能为空！");
                    $("#txtPwd1").val("");
                    return;
                }

                if (pwd.length < 6 || pwd.length > 20 || pwd1.length < 6 || pwd1.length > 20) {
                    w.Show("密码长度必须在6到20个字符。");
                    return;
                }

                if (pwd != pwd1) {
                    w.Show("两次密码不一致！");
                    $("#txtPwd").val("");
                    $("#txtPwd1").val("");
                    return;
                }

                $.post("../API/CreateUserAPI.ashx", { email: "", pwd: pwd, pwd1: pwd1, code: code, mobile: mobile, nickname: "" }, function (data) {
                    if (data == "true") {
                        s.Show("注册成功,即将进行跳转！");
                        $(":input").val("");
                        Redirect("/MemberCenter.aspx");
                        return;
                    }
                    if (data == "false") {
                        w.Show("注册失败！");
                        return;
                    }
                    w.Show(data);

                });

            });
        })
        $(function () {

            $(".hq_yzm").click(function () {
                if ($(".hq_yzm").hasClass("time_yzm")) {
                    return;
                }

                var mobile = $("#txtMobile").val();
                if (mobile == "") {
                    w.Show("手机号不能为空");
                    return;
                }

                if (!checkMobile(mobile)) {
                    w.Show("手机号格式不正确");
                    return;
                }

                $.post("../API/SendVerificationCode.ashx?mobile=" + mobile + "&type=reg", function (msg) {
                    if (msg == "") {
                        var s = 60;
                        var iid = setInterval(function () {
                            $(".hq_yzm").text("已发送您的手机（" + s + "）");
                            if (s == 0) {
                                $(".hq_yzm").removeClass("time_yzm");
                                $(".hq_yzm").text("获取验证码");
                                clearInterval(iid);
                            }
                            s--;
                        }, 1000);
                    }
                    else {
                        w.Show(msg);
                        $(".hq_yzm").removeClass("time_yzm");
                    }
                });
                $(".hq_yzm").addClass("time_yzm");
            });
        })
        function isEmail(strEmail) {
            if (strEmail.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0 -9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) !=-1)
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
				<!--登陆注册区域-->
				<div class="zcdl_all">
					<!--注册框-->
					<div class="zc_border">
						<div class="wa_position haveborder clear">
							<input type="text" class="dl_txt" placeholder="请输入手机号" id="txtMobile"/>
							<span class="iconfont">&#xe607;</span>
						</div>
						<div class="wa_position haveborder">
							<input type="text" class="dl_txt" placeholder="请输入验证码" id="txtCode"/>
							<div class="hq_yzm">获取验证码</div>
							<!--time_yzm这个样式是发送手机时需要加上的
								<div class="hq_yzm time_yzm">已发送您的手机（60秒）</div>
							-->
						</div>
						<div class="wa_position haveborder clear">
							<input type="password" class="dl_txt" placeholder="设置密码：请输入6-20位数字或字母" id="txtPwd" maxlength="20"/>
							<span class="iconfont">&#xe607;</span>
						</div>
						<div class="wa_position haveborder clear">
							<input type="password" class="dl_txt" placeholder="请确认新密码" id="txtPwd1" maxlength="20"/>
							<span class="iconfont">&#xe607;</span>
						</div>
					</div>
					<!--注册框end-->
					<!--登陆注册-->
					<div class="the_bt">
						<button type="button" id="btnRegister">注册</button>
					</div>
					<!--登陆注册end-->
					<!--第三方登陆-->
<%--					<div class="other_dl">
						<span>第三方账号登录：</span>
						<a href="/Account/LoginToQQ.aspx">
							<img src="/mimages/qq.png" />
						</a>
						<a href="<%=SinaURL %>">
							<img src="/mimages/wb.png" />
						</a>
					</div>--%>
					<!--第三方登陆end-->
				</div>
				<!--登陆注册区域end-->
				
			</div>
            
</asp:Content>
