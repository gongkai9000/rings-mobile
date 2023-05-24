<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="MyInfo.aspx.cs" Inherits="drmobile.MyInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>会员中心</title>
<link type="text/css" rel="stylesheet" href="styles/member.css" />
<script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
<script src="Scripts/Wrong.js" type="text/javascript"></script>
<script type="text/javascript">
    var w;
    $(document).ready(function () {
        w = new Wrong();
        w.Insert(".fhx");
    });

    function submit() {
        if (isNaN($("#qq").val())) {
            w.Show("请输入正确的QQ号。");
        }
        else {
            $('#form1').submit();
        }
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <!--返回选项-->
<div class="fhx">
	<a href="javascript:history.go(-1)">返回</a>
    <span>我的信息</span>
</div>
    <!--出错-->
    
<!--边框外-->
<div class="dl_corent">
	<!--框内信息-->
	<div class="border">
    	<div class="thew_wod">
        	账号：<%=Member.email %>
        </div>
		<input type="text" name="nickname" class="ipt_3" placeholder="昵称：" value="<%=Member.nickname %>"/>
        <input type="text" name="realname" class="ipt_3" placeholder="姓名：" value="<%=Member.realname %>"/>
        <div class="thew_wod">
        	<span>性别：</span>
        	<input type="radio" name="gender" id="genderMan" class="ipt_5" <%=Gender(Member.gender,"男") %> value="男"/><label for="genderMan">男</label>
            <input type="radio" name="gender" id="genderWoman" class="ipt_5" <%=Gender(Member.gender,"女") %> value="女"/><label for="genderWoman">女</label>
        </div>
        <input type="text" name="birthday" class="ipt_3" placeholder="生日：" value="<%=Member.birthday %>"/>
        <input type="text" name="address" class="ipt_3" placeholder="地址：" value="<%=Member.address %>"/>
        <input type="text" name="postcode" class="ipt_3" placeholder="邮编：" value="<%=Member.postcode %>"/>
        <input type="text" name="mobile" class="ipt_3" placeholder="手机：" value="<%=Member.mobile %>"/>
        <input type="text" id="qq" name="qq" class="ipt_3" placeholder="Q Q：" value="<%=Member.qq %>"/>
        <div class="button" onclick="submit()">提交</div>
    </div>
</div>

</asp:Content>
