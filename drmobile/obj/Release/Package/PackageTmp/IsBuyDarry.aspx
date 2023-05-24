<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true"
    CodeBehind="IsBuyDarry.aspx.cs" Inherits="drmobile.IsBuyDarry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var w, s;
        $(function () {
            w = new Wrong();
            s = new Success();
        });
        function isBuyDarry() {
            var txtName = $("#txtName").val();
            var txtCardId = $("#txtCardID").val();

            if (txtName == "" || txtCardId == "") {
                w.Show("姓名或身份证不能为空。");
                return;
            }
            if (!(/(^\d{15}$)|(^\d{17}([0-9]|X)$)/.test(txtCardId))) {
                w.Show("身份证不合法。");
                return;
            }

            $.post('/API/buycheck.ashx?action=drcard&type=<%=Request.QueryString["type"] %>', {
                 "sirName": txtName,
                 "sirCard": txtCardId,
                 "pid":<%=Request.QueryString["pid"] %>,
                 "did":<%=Request.QueryString["did"] %>,
                 "material":"<%=Request.QueryString["material"] %>",
                 "handsize":<%=Request.QueryString["handsize"] %>,
                 "font":"<%=Request.QueryString["font"] %>"
            }, function (data) {
                try{
                    var d = $.parseJSON(data);
                    if(d.result == "true")
                    {
                        s.Show("已添加到购物车");
                        Redirect(d.data);
                    }
                    else
                    {
                        window.location = d.data;
                    }
                }
                catch(ex)
                {
                    w.Show(data);
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <!--验证查询导航-->
			<!--验证查询导航end-->
			<div class="spwhrite">
				<div class="detail_ring fl">
					<img src="<%=CurrentProduct.imgurl %>" />
				</div>
				<div class="detail_word thecp_word fl">
					<h3><%=CurrentProduct.title%>[<%=CurrentProduct.productNo%>]</h3>
                    <p>材质：<%=Request.QueryString["material"]%></p>
                    <p>手寸：<%=Request.QueryString["handsize"]%></p>
                    <p>刻字：<%=Request.QueryString["font"]%></p>
	                <p>搭配：<%= CurrentProduct.zct *100%>分  <%=CurrentProduct.zcolor %>色  <%=CurrentProduct.zclarity%>净度  <%=CurrentProduct.zcut%>切工</p>
					<p>
						<i>￥<%=CurrentProduct.MemberPrice.Value.ToString("N0")%></i>
					</p>
				</div>
			</div>
			<div class="spwhrite">
				<div class="theyz_word">
					<p>Darry Ring严格限制男士一生仅能定制一枚，<br/>
					象征男人一生真爱的最高承诺！<br/>
					只有经过官网数据库查询验证该姓名没有与之<br/>
					绑定的钻戒编码，才可以进行购买。</p>
				</div>
				<div class="wa_position haveborder clear">
					<input type="text" class="dl_txt" placeholder="姓名：" id="txtName" maxlength="20"/>
					<span class="iconfont">&#xe607;</span>
				</div>
				<div class="wa_position haveborder clear">
					<input type="text" class="dl_txt" placeholder="身份证号码：" id="txtCardID" maxlength="30"/>
					<span class="iconfont">&#xe607;</span>
				</div>
			</div>
			<div class="theyz_bt">
				<button type="button" class="yz-button" onclick="isBuyDarry();">开始验证</button>
			</div>
			<!--底部-->
</asp:Content>
