<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="OrderCreateSuccess.aspx.cs" Inherits="drmobile.OrderCreateSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
</asp:Content>

<asp:Content runat="server" ID="pageendjs" ContentPlaceHolderID="PageEndJs" >
 <script type="text/javascript">
    ga('require', 'ecommerce', 'ecommerce.js');   //固定引用ecommerce.js
    ga('ecommerce:addTransaction', {    //收集订单数据
        'id': '<%=OrderID %>',                    // 订单号（变量）。必填   
        'affiliation': '',                // 联盟商家名（变量）。一般不用填   
        'revenue': '<%=Order.ordertotal %>',              // 订单金额（变量）。一般需要填
        'shipping': '0',                // 运费（变量）。选填
        'tax': '',                     // 税（变量）。一般不用填
        'currency': 'CNY'                 // 货币代码 （变量）。一般为CNY
    });
    <%for(int i=0;i<DetailList.Count;i++){%>
        ga('ecommerce:addItem', {   //收集商品数据
            'id': '<%=DetailList[i].orderId %>',                    // 订单号。必填.   
            'name': '<%=DetailList[i].Title %>',   // 商品名称。必填   
            'sku': '',                // SKU号（变量）选填
            'category': '',        // 商品类目。选填   
            'price': '<%=DetailList[i].memberprice %>',                // 商品单价。
            'quantity': '1'                   // 商品数量   
        });
    <%}%>

    //如果一个订单中存在多个商品，需要为每个商品调用一次ga('ecommerce:addItem',{
    ga('ecommerce:send');  //发送电子商务跟踪数据
    </script>
</asp:Content>
