<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="MyInfo.aspx.cs" Inherits="drmobile.Account.MyInfo" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <script type="text/javascript">
       $(function () {
           var w = Wrong();
           var s = Success();
           $("#btnSave").click(function () {
               var nickname = $("#<%=txtNickname.ClientID %>").val();
               var realname = $("#<%=txtRealname.ClientID %>").val();
               var email = $("#<%=txtEmail.ClientID %>").val();
               var mobile = $("#<%=txtMobile.ClientID %>").val()

               if (nickname == "") {
                   w.Show("请填写昵称");
                   return;
               }
               if (realname == "") {
                   w.Show("请填写姓名");
                   return;
               }
               if (email != "" && !checkEmail(email)) {
                   w.Show("邮箱格式不正确");
                   return;
               }
               if (mobile != "" && !checkMobile(mobile)) {
                   w.Show("手机格式不正确");
                   return;
               }
               $.post("/API/MyInfoCMD.ashx", { nickname: nickname, realname: realname, gender: $("input:radio:checked").val(), email: email, mobile: mobile }, function (msg) {
                   if (msg == "") {
                       s.Show("保存成功");
                       Redirect("/MemberCenter.aspx");
                   }
                   else {
                       w.Show(msg);
                   }
               });
           });
       });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--608区域内-->
			<div class="spwidth_608 mb_whrite">
				<!--绑定账号区域-->
				<div class="mbnew_all">
					<!--绑定账号框-->
					<div class="zc_border">
						<div class="wa_position haveborder clear">
							<input type="text" class="dl_txt" placeholder="昵称：" id="txtNickname" runat="server" maxlength="20"/>
							<span class="iconfont">&#xe607;</span>
						</div>
						<div class="wa_position haveborder clear">
							<input type="text" class="dl_txt" placeholder="姓名：" id="txtRealname" runat="server" maxlength="20" />
							<span class="iconfont">&#xe607;</span>
						</div>
						<div class="sex_choose">
							<span>性别：</span>
							<input type="radio" id="man" runat="server"/>
							<label for="<%=man.ClientID %>">男</label>
							<input type="radio" id="woman" runat="server"/>
							<label for="<%=woman.ClientID %>">女</label>
						</div>
						<div class="wa_position haveborder clear">
							<input type="text" class="dl_txt" placeholder="邮箱：" id="txtEmail" runat="server" maxlength="50"/>
						</div>
						<div class="wa_position haveborder clear">
							<input type="text" class="dl_txt" placeholder="手机：" id="txtMobile" runat="server" maxlength="18"/>
						</div>
					</div>
					<!--绑定账号框end-->
				</div>
				<!--绑定账号区域end-->
			</div>
			<!--608区域内end-->
            <!--登陆注册-->
			<div class="the_bt">
				<button type="button" id="btnSave">保存</button>
			</div>
</asp:Content>
