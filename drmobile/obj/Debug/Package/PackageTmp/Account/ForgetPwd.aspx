<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="ForgetPwd.aspx.cs" Inherits="drmobile.Account.ForgetPwd" %>

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
            $("#btnReset").click(function () {

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

                $.post("../API/MemberAction.ashx?action=findpwd", { email: "", pwd: pwd, pwd1: pwd1, code: code, mobile: mobile, nickname: "" }, function (data) {
                    if (data == "") {
                        s.Show("修改成功，即将进行跳转！");
                        $(":input").val("");
                        Redirect("/MemberCenter.aspx");
                    }
                    else {
                        w.Show(data);
                    }

                });

            });
        })
        //<%--点击错误提示进行关闭 --%>
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

                $.post("../API/SendVerificationCode.ashx?mobile=" + mobile + "&type=findpwd", function (msg) {
                    if (msg != "") {
                        w.Show(msg);
                        $(".hq_yzm").removeClass("time_yzm");
                        return;
                    }
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
                });
                $(".hq_yzm").addClass("time_yzm");
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
				<!--登陆注册区域-->
				<div class="zcdl_all">
					<!--登陆框-->
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
							<input type="password" class="dl_txt" placeholder="请输入新密码" id="txtPwd" maxlength="20"/>
							<span class="iconfont">&#xe607;</span>
						</div>
						<div class="wa_position haveborder clear">
							<input type="password" class="dl_txt" placeholder="请确认新密码" id="txtPwd1" maxlength="20"/>
							<span class="iconfont">&#xe607;</span>
						</div>
					</div>
					<!--登陆框end-->
					<!--登陆注册-->
					<div class="the_bt">
						<button type="button" id="btnReset">确认重置</button>
					</div>
					<!--登陆注册end-->
				</div>
				<!--登陆注册区域end-->
			</div>
</asp:Content>
