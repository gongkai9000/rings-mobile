<%@ Page Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="AddAddress.aspx.cs" Inherits="drmobile.AddAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript" src="mjs/member.js" ></script>
<script type="text/javascript" src="mjs/CustomControl.js" ></script>
<script type="text/javascript">
        var w;
        var a;
        var s;
        $(function () {
            w = new Wrong();
            a = new MyAlert();
            s = new Success();
        });

        var ProvinceDataLoadEvent = function(){};
        //市数据加载事件
        var CityDataLoadEvent = function () { };
        var DistrictDataLoadEvent = function () { };

        function setAddress(data) {
            $("#txtName").val(data.name);//收货人

            ProvinceDataLoadEvent = function(){
                $("#province option").each(function () {
                    if (data.city.indexOf($(this).text()) != -1) {
                        $("#province").val($(this).val());
                        $("#province").change();
                    }
                });
            };

            CityDataLoadEvent = function () {
                $("#city option").each(function () {
                    if (data.city.indexOf($(this).text()) != -1) {
                        $("#city").val($(this).val());
                        $("#city").change();
                    }
                });
            };
            DistrictDataLoadEvent = function () {
                $("#district option").each(function () {
                    if (data.city.indexOf($(this).text()) != -1) {
                        $("#district").val($(this).val());
                    }
                });
            };

            $("#txtdetail").val(data.street);//详细地址
            $("#txtzipCode").val(data.code);//邮编
            $("#txtTel").val(data.mobile);//手机号
//            $("#telephone").val(data.phone);
//            $("#cbDefaultAddress").attr("checked", data.IsDefault);
        }

        function addressSelectLoad()
        {
            //省下拉框ID
            var province = "#province";
            var city = "#city";
            var district = "#district";
            //加载省信息
            $.get("/API/AddressInfo.ashx?action=province", function (data) {
                $(data).each(function () {
                    bindDdlData(province, this);
                });
                ProvinceDataLoadEvent();
            });
            //省下拉框onchange事件
            $(province).change(function () {
                var dataLoad = function (data) {
                    $(city + " option:not(:first)").remove();
                    $(data).each(function () {
                        bindDdlData(city, this);
                    });
                    CityDataLoadEvent();
                };

                $.get("/API/AddressInfo.ashx?action=city&code=" + $(this).val(), function (data) {
                    dataLoad(data);
                });

            });
            //市下拉框onchange事件
            $(city).change(function () {
                var dataLoad = function (data) {
                    $(district + " option:not(:first)").remove();
                    $(data).each(function () {
                        bindDdlData(district, this);
                    });
                    DistrictDataLoadEvent();
                };
                $.get("/API/AddressInfo.ashx?action=district&code=" + $(this).val(), function (data) {
                    dataLoad(data);
                });
            });
        }

        $(function () {
            if('<%=Action %>' == "save")
            {
                $.get("/API/AddressInfo.ashx?action=getbyid&id=<%=Request.QueryString["id"] %>", function (data) {
                    addressSelectLoad();
                    setAddress(data);
                });
            }
            else
            {
                addressSelectLoad();
            }

            /*<%--提交功能:添加新地址 --%>*/
            $("#btnAdd").click(function () {
                var province = $("#province option:selected").text();
                var city = $("#city option:selected").text();
                var district = $("#district option:selected").text();
                var detailAddres = $("#txtdetail").val();
                var zipcode = $("#txtzipCode").val();
                var tel = $("#txtTel").val();
//                var rido = $("input[type='radio']:checked").val();
                var name = $("#txtName").val();
                if (name == "") {
                    w.Show("请输入姓名！");
                    return;
                }
                if (province == "请选择省份") {
                    w.Show("请选择省份！");
                    return;
                }
                if (city == "请选择城市") {
                    w.Show("请选择城市！");
                    return;
                }
                if (district == "请选择区县") {
                    w.Show("请选择区县！");
                    return;
                }
                if (detailAddres == "") {
                    w.Show("请填写详细地址！");
                    return;
                }
                if (!checkCode(zipcode)) {
                    w.Show("邮编不正确！");
                    return;
                }
                if (tel == "") {
                    w.Show("手机号不能为空！");
                    return;
                }
                if (!checkMobile(tel)) {
                    w.Show("手机号不正确！");
                    return;
                }
                var citys = province + city + district;

                $.post("API/AddressInfo.ashx?action=<%=Action %>", { id:"<%=Request.QueryString["id"] %>", name: name, province:province,city:city,district:district,street:detailAddres,postcode:zipcode,mobile:tel }, function (data) {
                    s.Show("保存地址成功");
                    clear();
                    var url = "<%=ReturnURL %>";
                    if(url.indexOf("addressid")>-1&&url.length == url.indexOf("addressid")+10)
                    {
                        url += data.id;
                    }
                    Redirect(url);
                })

            });
        });

        function bindDdlData(cid, data) {
            $(cid).append($("<option value=\"" + data.code + "\">" + data.name + "</option>"));
        }

        //<%--清空input标签数据 --%>
        function clear() {
            $(":input").val(""); 
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--填写收货地址-->
			<div class="awhrite">
				<ul class="adress_ul">
					<li>
						<span>姓名：</span>
						<input type="text" maxlength="25" id="txtName" />
					</li>
					<li>
						<span>手机：</span>
						<input type="text" maxlength="14" id="txtTel" />
					</li>
					<li class="dz_position">
						<span>省份：</span>
                        <div class="sfdz">
						    <select id="province"><option value="-1">请选择省份</option></select>
                        </div>
                        <i></i>
					</li>
					<li class="dz_position">
						<span>城市：</span>
                        <div class="sfdz">
						    <select id="city"><option value="-1">请选择城市</option></select>    
                        </div>
                        <i></i>
					</li>
					<li class="dz_position">
						<span>区县：</span>
                        <div class="sfdz">
						    <select id="district"><option value="-1">请选择区县</option></select>
                        </div>
                        <i></i>
					</li>
					<li>
						<span>详细地址：</span>
						<input type="text" id="txtdetail" maxlength="100" />
					</li>
					<li style="border:none">
						<span>邮编：</span>
						<input type="text" maxlength="6" id="txtzipCode" />
					</li>
				</ul>
			</div>	
			<!--填写收货地址end-->	
			<div class="spwidth_608 sm_pad">
				<a href="javascript:void(0)" class="to_shop" id="btnAdd">保存</a>
			</div>
</asp:Content>