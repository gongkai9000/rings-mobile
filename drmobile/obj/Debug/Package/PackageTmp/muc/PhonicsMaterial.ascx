<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhonicsMaterial.ascx.cs" Inherits="drmobile.muc.PhonicsMaterial" %>
<script type="text/javascript">
    var MaterialChoosedEvent = function (m, mp, wp) { };
    $(function () {
        $(".cz_choose i").click(function () {
            MaterialChoosedEvent($(this).text(), parseFloat($(this).attr("manprice")), parseFloat($(this).attr("womanprice")));
            $(this).addClass("cp_click");
        });
        $(".cz_choose i").eq(0).click();
    });
</script>
<p class="cz_choose">
   <span class="fl">材质：</span>
   <b class="fl">
    <asp:Repeater runat="server" ID="rpMaterial">
        <ItemTemplate>
           <i manprice="<%#Eval("manprice") %>" womanprice="<%#Eval("womanprice") %>"><%#Eval("name") %></i>
        </ItemTemplate>
    </asp:Repeater>
    </b>
</p>