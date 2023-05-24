<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="underGoods.aspx.cs" Inherits="drmobile.underGoods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="spwidth_608">
                <div class="noshop">
                    <img src="/mimages/dr_cp/smile.png" />
                    <p>
                        抱歉，您查看的物品不存在，可能已下架或被转移</p>
                    <a href="/" class="to_shop">去首页找商品</a>
                </div>
            </div>
</asp:Content>