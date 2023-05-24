<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="infoview.ascx.cs" Inherits="drmobile.muc.infoview" %>
<%if (!IsPhonics)
  { %>
  	<p>产品编号： <%=CurrentProduct.productNo %></p>
	<p>证书类型： <%=CurrentProduct.CertificateType%></p>
	<p>金 重： <%=CurrentProduct.KimWeigth%></p>
	<p>材 质： <%=CurrentProduct.Material %></p>
	<p>钻石信息</p>
	<p>主钻重量： <%=CurrentProduct.zct%>克拉</p>
	<p>副钻重量： <%=CurrentProduct.fct %>克拉</p>
	<p>净 度： <%=CurrentProduct.zclarity %></p>
	<p>颜 色： <%=CurrentProduct.zcolor %></p>
	<p>切 工： <%=CurrentProduct.zcut %></p>
<%}else{ %>
<div class="shop_allit-word fl">
    <p><strong>男戒</strong></p>
  	<p>产品编号： <%=ManProduct.productNo%></p>
	<p>证书类型： <%=ManProduct.CertificateType%></p>
	<p>金 重： <%=ManProduct.KimWeigth%></p>
	<p>材 质： <%=ManProduct.Material%></p>
	<p>钻石信息</p>
	<p>主钻重量： <%=ManProduct.zct%>克拉</p>
	<p>副钻重量： <%=ManProduct.fct%>克拉</p>
	<p>净 度： <%=ManProduct.zclarity%></p>
	<p>颜 色： <%=ManProduct.zcolor%></p>
	<p>切 工： <%=ManProduct.zcut%></p>
</div>
<div class="shop_allit-word fr">
    <p><strong>女戒</strong></p>
  	<p>产品编号： <%=WomanProduct.productNo%></p>
	<p>证书类型： <%=WomanProduct.CertificateType%></p>
	<p>金 重： <%=WomanProduct.KimWeigth%></p>
	<p>材 质： <%=WomanProduct.Material%></p>
	<p>钻石信息</p>
	<p>主钻重量： <%=WomanProduct.zct%>克拉</p>
	<p>副钻重量： <%=WomanProduct.fct%>克拉</p>
	<p>净 度： <%=WomanProduct.zclarity%></p>
	<p>颜 色： <%=WomanProduct.zcolor%></p>
	<p>切 工： <%=WomanProduct.zcut%></p>
</div>
<%} %>