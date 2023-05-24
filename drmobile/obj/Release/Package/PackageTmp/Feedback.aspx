<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="drmobile.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
    var w;
    var s;
    $(function () {
        w = new Wrong();
        s = new Success();
    });
    $(function () {
        $("#btnSubmit").click(function () {
            var content = $("#txtFeedback").val();
            var mobile = $("#txtMobile").val();
            if (content == "") {
                w.Show("请先填写反馈信息");
                return;
            }
            if (mobile != "" && !checkMobile(mobile)) {
                w.Show("手机号格式不正确");
                return;
            }
            $.post("/API/Feedback.ashx", { content: content, mobile: mobile }, function () {
                $("#txtFeedback").val("");
                $("#mobile").val("");
                w.Exit();
                s.Show("提交成功");
            });
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <!--608区域内-->
			<div class="spwidth_608">
				<!--意见反馈区域-->
				<div class="zcdl_all">
					<!--意见反馈-->
					<div class="dl_border">
						<textarea placeholder="请在这输入..." style="border:none;margin-top:10px;width:95%;height:200px;outline:none;font-size:16px;resize:none;padding:0 2%;font-family:'微软雅黑'" id="txtFeedback" maxlength="500"></textarea>
						<div class="tel_advice">
							<span>手机号</span>
							<input type="text" placeholder="选填，方便我们与您联系" id="txtMobile" maxlength="18"/>
						</div>
					</div>
					<!--意见反馈end-->
				</div>
				<!--意见反馈区域end-->
				<!--提交意见-->
				<div class="the_bt havemarin">
					<button type="button" id="btnSubmit" >提交意见</button>
				</div>
				<!--提交意见end-->
			</div>
			<!--608区域内end-->
</asp:Content>
