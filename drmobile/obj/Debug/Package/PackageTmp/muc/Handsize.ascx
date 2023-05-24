<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Handsize.ascx.cs" Inherits="drmobile.muc.Handsize" %>

	<select class="choose_num" style="font-family:微软雅黑" id="<%=UControlID %>">
		<option value="-1">请选择</option>
        <asp:Repeater runat="server" ID="rpHandsize">
            <ItemTemplate>
                <option price="<%#Eval("JsonMaterilPrice") %>" value="<%#Eval("HandSize")%>"><%#Eval("HandSize")%></option>
            </ItemTemplate>
        </asp:Repeater>
	</select>
    <script type="text/javascript">
    var <%=UControlID %>ChangeEvent = function(option,p){};
    $("#<%=UControlID %>").change(function () {
        if($(this).find(":checked").val() != "-1")
        {
            var s = $.parseJSON($(this).find(":checked").attr("price"));
            <%=UControlID %>ChangeEvent($(this), parseFloat(s[CurrentMaterial]));
        }
        else
        {
            <%=UControlID %>ChangeEvent($(this),0);
        }
    });
</script>