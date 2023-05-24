<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommodityInfo.ascx.cs" Inherits="drmobile.muc.CommodityInfo" %>
<%try
  { %>
	<p>材质：<%=Data.Material%></p>
    <p<%=getDisplay("handsize") %>>手寸：<%=Data.handsize%></p>
    <p<%=getDisplay("fontstyle") %>>刻字：<%=Data.fontstyle%></p>
	<p<%=getDisplay("diamond") %>>搭配：<%=carat%>分  <%=color%>色  <%=clarity%>净度  <%=cut%>切工</p>
    <%} catch (Exception ex) { } %>