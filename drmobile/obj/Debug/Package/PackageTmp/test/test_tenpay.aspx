<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master"  AutoEventWireup="true" CodeBehind="test_tenpay.aspx.cs" Inherits="drmobile.test.test_tenpay" Async="true" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <dd id="btn-dd">
                        <span class="new-btn-login-sp">
                            <asp:Button ID="BtnAlipay" name="BtnAlipay" class="new-btn-login" Text="确 认" Style="text-align: center;"
                                runat="server" OnClick="BtnAlipay_Click"/>
                        </span>
                        <span class="note-help">如果您点击“付款”按钮，即表示您同意该次的执行操作。</span>
                    </dd>
</asp:Content>
