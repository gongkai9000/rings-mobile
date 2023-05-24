<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="AfterService.aspx.cs" Inherits="drmobile.AfterService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    var w;
    var s;
    $(document).ready(function () {
        w = new Wrong();
        s = new Success();
    });
    function ClearData() {
        $("#typeservice").val("");
        $("#txtDesc").val("");
    }
    var addressid = <%=CurrentAddress.SpAddressId %>;
    function SubmitForm() {
        if ($("#typeservice").val() == "") {
            w.Show("请选择售后项目");
            return;
        }
        if (addressid == 0) {
            w.Show("请选择地址");
            return;
        }

        var data = {
            "TypeService": $("#typeservice").val(),
            "KRemarks": $("#txtDesc").val(),
            "addressid":addressid
        };
        $.post("API/AfterServiceCMD.ashx?action=AddAfterService&odid=<%=OrderDetailId %>&orderid=<%=OrderID %>", data, function (e) {
            ClearData();
            s.Show("申请成功");
            Redirect("MyAfterService.aspx");
        });
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--产品-->
            <div class="spwhrite cmain">
                <a href="<%=getUrl(CurrentOrderDetail) %>" class="aposition"></a>
				<div class="thecp_img thecp_spimg fl">
					<img src="<%=DRM.Common.ImageURLFormat.Format(CurrentOrderDetail.imgurl) %>" />
				</div>
				<div class="thecp_word thecp_spword fl">
					<h3><%=CurrentOrderDetail.Title%>[<%=CurrentOrderDetail.productNo%>]</h3>
					<p><i>￥<%=Convert.ToDecimal(CurrentOrderDetail.memberprice).ToString("N0")%></i></p>
                    <p>材质：<%=CurrentOrderDetail.Material %></p>
                    <p>手寸：<%=CurrentOrderDetail.handsize%></p>
                    <p>刻字：<%=CurrentOrderDetail.fontstyle%></p>
					<p><span><%=CurrentOrderDetail.addtime %></span></p>
				</div>
                <div class="iconfont right_position">&#xe605;</div>
			</div>
			<!--产品end-->
			<!--退款选择-->
			<div class="awhrite">
				<ul class="reason_ul">
                    <li class="bt_shou dz_position">
                    <select id="typeservice">
                        <option value="">请选择售后项目</option>
                        <option value="更换手寸">更换手寸</option>
                        <option value="更换款式">更换款式</option>
                        <option value="修改刻字">修改刻字</option>
                        <option value="更换钻石">更换钻石</option>
                        <option value="钻石保养">钻石保养</option>
                        <option value="饰品保养">饰品保养</option>
                        <option value="其它售后">其它售后</option>
                    </select>
                    <i></i>
                    </li>
					<li>
						<div class="reason">
							<span>收到货享有15天退换货保证</span>
						</div>
					</li>
				</ul>
				<div class="dl_border ask_border mrgin_top">
					<textarea style="border:none;margin-top:10px;width:95%;height:100px;outline:none;font-size:16px;resize:none;padding:0 2%;font-family:'微软雅黑'" placeholder="说明：" id="txtDesc"></textarea>
				</div>
			</div>
			<!--退款选择end-->
            <!--收货人-->
			<div class="detail_number">
				完成售后，商品寄回地址
			</div>
			<div class="spwhrite cmain">
				<a href="MyAddressChoose.aspx?odid=<%=OrderDetailId %>" class="aposition"></a>
				<div class="detail_all">
					<p>收货人：<span><%=CurrentAddress.SpAddressName%></span></p>
					<p>手机：<span><%=CurrentAddress.SpAddressMobile%></span></p>
					<p>收货地址：<span><%=CurrentAddress.SpAddressStreet%></span></p>
				</div>
				<div class="iconfont right_position">&#xe605;</div>
			</div>
			<!--收货人end-->
			<div class="the_bt">
				<button id="btnSubmit" type="button" onclick="SubmitForm()">确认提交</button>
				<p class="red_color">售后申请审核需2-3个工作日，如有疑问请联系在线客服！</p>
			</div>
</asp:Content>
