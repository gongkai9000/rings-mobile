<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="AfterServiceView.aspx.cs" Inherits="drmobile.AfterServiceView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--退款选择-->
			<div class="awhrite">
				<p class="bt_shou">
					发起售后申请
				</p>
				<ul class="reason_ul">
					<li>
						<div class="reason">
							<span>服务单号：<%=CurrentService.AfterServiceNo%></span>
						</div>
					</li>
					<li>
						<div class="reason">
							<span>相关订单：<%=CurrentService.Orderid%></span>
						</div>
					</li>
					<li>
						<div class="reason">
							<span>制单日期：<%=CurrentService.AfterServiceDate%></span>
						</div>
					</li>
					<li style="border:none">
						<div class="reason">
							<span>原因类型：<%=CurrentService.TypeService%></span>
						</div>
					</li>
				</ul>
			</div>
			<!--退款选择end-->
			<!--收货人-->
			<div class="detail_number">
				售后说明
			</div>
			<div class="spwhrite cmain">
				<div class="detail_all">
					<p class="the_margin"><%=CurrentService.KRemarks%></p>
				</div>
			</div>
            <div class="spwhrite cmain">
                <div class="detail_all">
                    <p>售后申请通过后，客服会与您进行联系！</p>
                </div>
            </div>
			<!--收货人end-->
			<div class="detail_but detail_onebut">
				<%--<a href="#" class="fl">取消申请</a>--%>
				<a href="">联系客服</a>
			</div>
 
</asp:Content>
