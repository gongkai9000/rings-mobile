<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true"
    CodeBehind="Address.aspx.cs" Inherits="drmobile.Address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/Scripts.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <link href="Styles/member.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Wrong.js" type="text/javascript"></script>
    <%-- 绑定地址数据模板--%>
    <script type="text/x-jquery-tmpl" id="divTemp">
         <div class="border">
             <div onclick="AddressClick(${SpAddressId},'<%= ReturnUrl%>','<%= Type%>')">
                <p>
                    ${SpAddressName}<span>${SpAddressMobile}</span></p>
                <p>
                    ${SpAddressCity}${SpAddressStreet}</p>
            </div>
            <div class="fr">
               <label for="def">  <input  type="radio" name="def" id="${SpAddressId}" checked="${SpAddressDefault}" class="ipt_5" onclick="setDefault('<%= ReturnUrl%>')" />设为默认</label>
                <a href="javascript:void(0)"onclick="deleteById(${SpAddressId})"  class="ljt"></a>
            </div>
        </div>
    </script>
    <script type="text/javascript">
        var w;
        $(document).ready(
        function () {
            w = new Wrong();
            w.Insert(".fhx");
        });
        //<%--check Type 是否有Choose 判断添加新地址是否显示 --%>
        $(function () {
            var ty = "<%=Type %>";
//            if (ty == "Choose") {
//                $("#addressId").hide();
//            } else {
//                $("#addressId").show();
//            }
            //<%--单击 填写新地址按钮 显示出 添加地址div 显示与隐藏切换 --%>
            $("#addNew").click(function () {
                if ($("#addressId").is(":hidden")) {
                    $("#addressId").show();
                }
                else {
                    $("#addressId").hide();
                }

            });
        });
        $(function () {

            //<%--省市区三级联动 --%>
            citySelector.Init($("#province"), $("#city"), $("#district"), $("#pre_province"), $("#pre_city"), $("#pre_district"), true);
            initData();
            /*<%--提交功能:添加新地址 --%>*/
            $("#btnAdd").click(function () {
                var province = $("#province option:selected").text();
                var city = $("#city option:selected").text();
                var district = $("#district option:selected").text();
                var detailAddres = $("#txtdetail").val();
                var zipcode = $("#txtzipCode").val();
                var tel = $("#txtTel").val();
                var rido = $("input[type='radio']:checked").val();
                var name = $("#txtName").val();
                if (name == "") {
                    w.Show("请输入姓名！");
                    return false;
                }
                if (province == "请选择省份") {
                    w.Show("请选择省份！");
                    return false;
                }
                if (city == "请选择城市") {
                    w.Show("请选择城市！");
                    return false;
                }
                if (district == "请选择区县") {
                    w.Show("请选择区县！");
                    return false;
                }
                if (detailAddres == "") {
                    w.Show("请填写详细信息！");
                    return false;
                }
                if (!checkcode(zipcode)) {
                    w.Show("邮编不正确！");
                    return false;
                }
                if (!checkTel(tel)) {
                    w.Show("联系方式不正确！");
                    return false;
                }
                var citys = province + city + district;
                $.post("API/AddCartAddressAPI.ashx", { name: name, city: citys, street: detailAddres, code: zipcode, tel: tel, rido: rido }, function (data) {
                  
                    if (data == "name") {
                      
                        w.Show("姓名获取错误！");
                        return false;
                    }
                    if (data == "city") {
                    
                        w.Show("城市获取错误！");
                        return false;
                    }
                    if (data == "street") {
                        
                        w.Show("详细信息获取出错！");
                        return false;
                    }
                    if (data == "name") {
                        w.Show("姓名获取错误！");
                       
                        return false;
                    }
                    if (data == "true") {

                        w.Show("创建地址成功！");
                        initData();
                        clear();
                        return false;
                    }
                    if (data == "false") {
                        w.Show("创建地址失败！");
                        return false;
                    }
                })

            });
        });
        //<%--清空input标签数据 --%>
        function clear() {

            $(":input").val(""); 

        }
        //<%--验证是否为手机号 --%>
        function checkTel(tel) {
            var mobile = /^1[3-8]+\d{9}$/;
            return mobile.test(tel);
        }
        //<%--验证邮编 --%>
        function checkcode(zipcode) {
            var MyNumber = /^[1-9]{1}[0-9]{5}$/;
            return MyNumber.test(zipcode);

        }
        //<%--绑定收货地址 --%>
        function initData() {
            $("#address").html("");
            $.post("API/GetAllAddressAPI.ashx", function (data) {

                var json = $.parseJSON(data);
                $("#divTemp").tmpl(json).appendTo("#address");
            });
        }
        //<%--设置默认地址--%>
        function setDefault(url) {
            var rid = $("input[type='radio']:checked").attr("id");
            $.post("API/UpdateAddressStatusAPI.ashx", { id: rid }, function (data) {
                if (data == "true") {
                    //window.location.href = url + "?AddressId=" + rid;

                    w.Show("设置默认成功！");
                    return false;
                }
                if (data == "wrong") {
                    w.Show("地址Id获取错误！");
                    return false;
                }
                if (data == "false") {
                    w.Show("默认选项设置失败！");
                    return false;
                }

            })
        }
        //<%--选择地址--%>
        function AddressClick(rid, url, type) {
            if (type == "Choose") {
                window.location.href = url + "?AddressId=" + rid;
            } else {

            }

        }
        //<%--绑定单击删除事件 --%>
        function deleteById(id) {
            var msg = "您真的确定要删除吗?\n\n请确认！";
            if (confirm(msg)==true) {
                $.post("API/DeleteAddressAPI.ashx", { id: id }, function (data) {
                    if (data == "noid") {
                        w.Show("收货地址编号获取错误！");
                        return false;
                    }
                    if (data == "wrong") {

                        w.Show("删除失败！");
                        return false;
                    }
                    if (data == "ok") {
                        w.Show("删除成功！");
                        initData();
                        return false;
                    }
                });
            }

        }
        $(function () {
            $(".wrong").click(function () {
                w.Exit();
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--返回选项-->
    <div class="fhx">
        <a href="javascript:history.go(-1);">返回</a> <span>收货地址</span>
    </div>
    <!--边框外-->
    <div class="dl_corent">
        <!--地址-->
        <div id="address">
            <%--<div class="border">
                <p>
                    王小利<span>186824568541</span></p>
                <p>
                    广东省深圳市罗湖区人民北路永通大厦1016室</p>
                <div class="fr">
                    <input type="radio" name="def" class="ipt_5" /><label>设为默认</label>
                    <a href="javascript:void(0)" onclick="deleteById()" class="ljt"></a>
                </div>
            </div>--%>
        </div>
        <div class="new_ad" id="addNew">
            填写新地址
        </div>
        <!--新地址-->
        <div class="border" id="addressId">
            <input type="text" id="txtName" class="ipt_3" placeholder="姓名：" />
            <select id="province">
                <option value="0">请选择省份</option>
            </select>
            <select id="city">
                <option value="0">请选择城市</option>
            </select>
            <select id="district">
                <option value="0">请选择区县</option>
            </select>
            <textarea id="txtdetail" placeholder="请填详细地址："></textarea>
            <input type="text" id="txtzipCode" class="ipt_3" placeholder="邮编：" />
            <input type="text" id="txtTel" class="ipt_3" placeholder="手机：" />
            <div id="btnAdd" class="button">
                提交</div>
        </div>
    </div>
</asp:Content>
