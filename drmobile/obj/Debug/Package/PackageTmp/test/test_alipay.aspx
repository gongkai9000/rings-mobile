<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master"  AutoEventWireup="true" CodeBehind="test_alipay.aspx.cs" Inherits="drmobile.test.test_alipay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="https://gw.alipayobjects.com/as/g/h5-lib/alipayjsapi/3.1.1/alipayjsapi.inc.min.js"></script>
    
    <script src="https://cdn.bootcss.com/vConsole/3.2.0/vconsole.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>支付宝支付</title>
</head>
<body>
    
     <div>
            <div id="body1" class="show" name="divcontent">
                <dl class="content">
                    <dt>商户订单号
：</dt>
                    <dd>
                        <asp:TextBox ID="WIDout_trade_no" name="WIDout_trade_no" runat="server">20230323</asp:TextBox>
                    </dd>
                    <hr class="one_line">
                    <dt>订单名称
：</dt>
                    <dd>
                         <asp:TextBox ID="WIDsubject" name="WIDsubject" runat="server">ring001</asp:TextBox>
                    </dd>
                    <hr class="one_line">
                    <dt>付款金额
：</dt>
                    <dd>
                         <asp:TextBox ID="WIDtotal_amount" name="WIDtotal_amount" runat="server">0.01</asp:TextBox>
                    </dd>
                    <hr class="one_line">
                    <dt>商品描述：</dt>
                    <dd>
                         <asp:TextBox ID="WIDbody" name="WIDbody" runat="server">111</asp:TextBox>
                    </dd>
                    <hr class="one_line">
                     <dt>付款退出回跳：</dt>
                    <dd>
                         <asp:TextBox ID="WIDquit_url" name="WIDquit_url" runat="server">http://mdev.ctloves.com/OrderList.aspx</asp:TextBox>
                    </dd>
                    <hr class="one_line">
                    <dt></dt>
                    <dd id="btn-dd">
                        <span class="new-btn-login-sp">
                            <asp:Button ID="BtnAlipay" name="BtnAlipay" class="new-btn-login" Text="确 认" Style="text-align: center;"
                                runat="server" OnClick="BtnAlipay_Click"/>
                        </span>
                        <span class="note-help">如果您点击“付款”按钮，即表示您同意该次的执行操作。</span>
                    </dd>
                </dl>
            </div>
    </div>

<script>
    var vConsole = new VConsole();
    console.log(1);
</script>

</body>
</html>

</asp:Content>