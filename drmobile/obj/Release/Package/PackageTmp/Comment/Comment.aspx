<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="drmobile.Comment.Comment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript" src="/mjs/member.js" ></script>
    <script type="text/javascript">
        var s;
        var w;
        $(function () {
            s = new Success();
            w = new Wrong();
            $(".to_ask").click(function () {
                var sa = $(".star_click").length;
                var satisfaction = "";
                if (sa == 5) {
                    satisfaction = "verylike";
                }
                else if (sa == 4) {
                    satisfaction = "aboutlike";
                }
                else if (sa == 3) {
                    satisfaction = "somelike";
                }
                else if (sa == 2) {
                    satisfaction = "nolike";
                }
                else if (sa == 1) {
                    satisfaction = "noverylike";
                }
                var evaluation = "";
                 $(".ks_click").each(function(){
                    evaluation += $(this).text()+";";
                });
                var recontent = $("#txtContent").val();
                if (recontent == "") {
                    w.Show("请填写评论");
                    return;
                }
                $.post("/API/Comment.ashx?action=add", { satisfaction: satisfaction, evaluation: evaluation, recontent: recontent, orderDetailId: <%=OrderDetailID %>,orderid:"<%=OrderId %>",pid:<%=PID %> }, function (msg) {
                    if(msg == "")
                    {
                        s.Show("发表成功");
                        Redirect("MyComment.aspx");
                    }
                    else
                    {
                        w.Show(msg);
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--产品-->
			<div class="spwhrite cmain">
				        <div class="thecp_img theask_img fl">
					        <img src="<%= DRM.Common.ImageURLFormat.Format(Convert.ToString(CurrentDetail.imgurl)) %>" />
				        </div>
				        <div class="thecp_word theask_word fl">
					        <h3><%=CurrentDetail.Title%>[<%= CurrentDetail.productNo%>]</h3>
					        <p><i>￥<%=CurrentDetail.memberprice%></i></p>
                            <p>材质：<%=CurrentDetail.Material%></p>
     <%--                       <p>手寸：<%=CurrentDetail.handsize%></p>
                            <p>刻字：<%=CurrentDetail.fontstyle%></p>--%>
					        <p><span><%=CurrentDetail.addtime%></span></p>
				        </div>  
				<!--产品评价-->
				<div class="mbask_all">
					<div class="mbask_one">
						<span>满意度：</span>
						<i class="star_click"></i><i class="star_click"></i><i class="star_click"></i><i class="star_click"></i><i class="star_click"></i>
					</div>
					<div class="mbask_two">
						<span>商品评价：</span>
						<i>百搭</i>
						<i>简约大气</i>
						<i>古典奢华</i>
					</div>
				</div>
				<!--产品评价end-->
			</div>
			<!--产品end-->
			<!--评论框-->
			<div class="dl_border ask_border">
				<textarea style="border:none;margin-top:10px;width:95%;height:100px;outline:none;font-size:16px;resize:none;padding:0 2%;font-family:'微软雅黑'" id="txtContent"></textarea>
			</div>
			<!--评论框end-->
			<div class="spwidth_608 sm_pad">
				<a href="javascript:void(0)" class="to_shop to_ask">发表评价</a>
			</div>
</asp:Content>
