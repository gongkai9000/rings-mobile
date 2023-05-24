<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Recommen.ascx.cs" Inherits="drmobile.us.uc_Recommen" %>
<!--更换钻石-->
        <div class="thing_all">
            <p>更换钻石</p>
            <ul class="jewel_ul">
              <asp:Repeater ID="rp_product" runat="server">
    <ItemTemplate>
     <li>
                    <%#Eval("text_1") %>克拉<%#Eval("text_5") %>色
                </li>
    </ItemTemplate>
    </asp:Repeater>
               
            </ul>
        </div>