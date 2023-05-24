<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="ctyz.aspx.cs" Inherits="drmobile.dryz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <!--验证-->    
            <div class="dyyz_cort" style="margin-top:620px;">
                <div class="dyyz_word">
                    <p>
                        CTloves严格限制一生只能购买一次，</p>
                        <p>一生仅能定制一枚，</p>
                    <p>
                        寓意"一生唯一真爱"的至高承诺！</p>
                    <p>
                        只有经过官网数据库查询验证该姓名,</p>
                    <p>
                        没有与之绑定的钻戒编码，才可以进行购买。</p>
                </div>
                <div class="dyyz_yz">
                    <div class="input-tx">
                        <input type="text" id="textName" placeholder="姓名" />
                        <input type="text" id="textIDCard" placeholder="身份证号码" />
                        <p class="mbwrong" style="display: none">
                            请输入身份证号码.</p>
                    </div>
                    <span class="yz-button" id="yz" style="cursor: pointer">
                        开始验证</span>
                </div>
            </div>
            <!--验证end-->
</asp:Content>
<asp:Content ContentPlaceHolderID="PageEndJs" ID="pageend" runat="server">
<script type="text/javascript">
    $(function () {
        $("#textName").focus(function () {
            $(".mbwrong").hide();
        });
        $("#textIDCard").focus(function () {
            $(".mbwrong").hide();
        });
        $("#yz").click(function () {

            var txtCard = $("#textIDCard").val();
            var txtName = $("#textName").val();

            if (txtName == "") {
                $(".mbwrong").html("");
                $(".mbwrong").html("请输入姓名！");
                $(".mbwrong").show();
                return false;
            }
            if (txtCard == "") {
                $(".mbwrong").html("");
                $(".mbwrong").html("请输入身份证号！");
                $(".mbwrong").show();
                return false;
            }
            if (!(/(^\d{15}$)|(^\d{17}([0-9]|X)$)/.test(txtCard))) {
                $(".mbwrong").html("");
                $(".mbwrong").html("身份证号不正确！");
                $(".mbwrong").show();
                return false;
            }
            $.post("/API/darrycheck.ashx", { action: "yz", card: txtCard, name: txtName }, function (data) {
                window.location = data;
            });

        });
    });
</script>
</asp:Content>