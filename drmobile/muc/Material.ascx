<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Material.ascx.cs" Inherits="drmobile.muc.Material" %>

<p class="cz_choose">
   <span class="fl">材质：</span>
   <b class="fl">
    <asp:Repeater runat="server" ID="rpMaterial">
        <ItemTemplate>
            <i value="<%#Eval("price") %>"><%#Eval("name") %></i>
        </ItemTemplate>
    </asp:Repeater>
    </b>
</p>
<script type="text/javascript">
    var MaterialChoosedEvent = function (m, p) { };
    $(".cz_choose i").click(function () {
        MaterialChoosedEvent($(this).text(), parseFloat($(this).attr("value")));
        $(this).addClass("cp_click");
    });
    $(function () {
        $(".cz_choose i").eq(0).click();
    });
</script>