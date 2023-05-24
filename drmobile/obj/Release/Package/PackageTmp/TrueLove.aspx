<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="TrueLove.aspx.cs" Inherits="drmobile.TrueLove" %>

<%@ Register Src="muc/workflow.ascx" TagName="ucWorkflow" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function DayNumOfMonth(Year, Month) {
        var d = new Date(Year, Month, 0);
        return d.getDate();
    }
    function InitDayOption() {
        var c = $(this);
        var year = c.parent().find("select").eq(0);
        var month = c.parent().find("select").eq(1);
        var day = c.parent().find("select").eq(2);

        var yearValue = parseInt(year.val());
        var monthValue = parseInt(month.val());
        if(yearValue != -1 && monthValue != -1)
        {
            var daynum = DayNumOfMonth(yearValue, monthValue);
            day.find("option[value!=-1]").remove();
            for(var i =1;i<=daynum;i++)
            {
                day.append("<option value=\"" + i + "\">" + i + "</option>");
            }
        }
    }

    function checkDate() {
        var year1 = $("#date1Year").val();
        var month1 = $("#date1Month").val();
        var day1 = $("#date1Day").val();
        var year2 = $("#date2Year").val();
        var month2 = $("#date2Month").val();
        var day2 = $("#date2Day").val();
        var year3 = $("#date3Year").val();
        var month3 = $("#date3Month").val();
        var day3 = $("#date3Day").val();
        if (!((year1 == "-1" && month1 == "-1" && day1 == "-1") || (year1 !="-1" && month1 != "-1" && day1 !="-1"))) {
            w.Show("生日填写不完整");
            return false;
        }
        if (!((year2 == "-1" && month2 == "-1" && day2 == "-1") || (year2 != "-1" && month2 != "-1" && day2 != "-1"))) {
            w.Show("纪念日一填写不完整");
            return false;
        }
        if (!((year3 == "-1" && month3 == "-1" && day3 == "-1") || (year3 != "-1" && month3 != "-1" && day3 != "-1"))) {
            w.Show("纪念日二填写不完整");
            return false;
        }
        return true;
    }
    var s, w;
    $(function () {
        s = new Success();
        w = new Wrong();
        $("#date1Year").change(InitDayOption);
        $("#date1Month").change(InitDayOption);
        $("#date2Year").change(InitDayOption);
        $("#date2Month").change(InitDayOption);
        $("#date3Year").change(InitDayOption);
        $("#date3Month").change(InitDayOption);

        var submitFunction = function () {
            if (!checkDate())
            { return; }
            if ($("#ladyName").val() == "") {
                w.Show("必须填写女士姓名");
                return;
            }
            var year1 = $("#date1Year").val();
            var month1 = $("#date1Month").val();
            var day1 = $("#date1Day").val();
            var year2 = $("#date2Year").val();
            var month2 = $("#date2Month").val();
            var day2 = $("#date2Day").val();
            var year3 = $("#date3Year").val();
            var month3 = $("#date3Month").val();
            var day3 = $("#date3Day").val();

            var sirName = "<%=DarryCart.sirName %>";
            var sirCode = "<%=DarryCart.sirCode %>";
            var ladyName = $("#ladyName").val();
            var sheBirthday = year1 == "-1" ? "" : year1 + "-" + month1 + "-" + day1;
            var sheDate1 = year2 == "-1" ? "" : year2 + "-" + month2 + "-" + day2;
            var sheDate2 = year3 == "-1" ? "" : year3 + "-" + month3 + "-" + day3;

            $.post("/API/truelove.ashx", { "sirName": sirName, "ladyName": ladyName, "sirCode": sirCode, "sheBirthday": sheBirthday, "sheDate1": sheDate1, "sheDate2": sheDate2 }, function () {
                window.location = "<%=ucWorkflow.NextUrl %>";
            });
        }
        $(".yz-button").click(submitFunction);

    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <uc1:ucWorkflow runat="server" id="ucWorkflow"></uc1:ucWorkflow>
<!--真爱协议-->
			<div class="love_zs txxy_bk">
				<div class="lovezs_all">
					<div class="lovezs_all-top">
						<img src="mimages/dr_cp/b_Top.jpg" />
					</div>
					<!--中间内容-->
					<div class="lovezs_all-center">
						<!--文字部分-->
						<div class="lovezs_all-word">
							<h3>真爱协议</h3>
							<p>Darry Ring 真爱戒指男士凭身  <br/>
							份证号一生仅可购买一枚，<br/>
							作为一生唯一真爱的最高承诺。<br/>
							签署该协议则表示您已经过<br/>
							慎重考虑，决定自购买之日起，<br/>
							将您的身份证号与Darry Ring 编码绑定，<br/>
							并接受亲友对购买信息的验证查询。<br/>
							此购买信息将终身留存在<br/>
							Darry Ring 数据库中并无法更改。<br/>
							请用心呵护您的真爱！</p>
						</div>
						<!--文字部分end-->
						<div class="the_txk">
							<div class="wa_position thenewborder clear">
								<input type="text" class="dl_txt" value="<%=DarryCart.sirName %>" readonly="readonly"/>
								<i>先生姓名：</i>
							</div>
							<div class="wa_position thenewborder clear">
								<input type="text" class="dl_txt" id="ladyName" maxlength="20"/>
								<i>女士姓名：</i>
								<span class="iconfont">&#xe607;</span>
							</div>
							<div class="wa_position thenewborder clear">
								<input type="text" class="dl_txt" value="<%=DarryCart.sirCode %>" readonly="readonly"/>
								<i>身份证号码：</i>
							</div>
						</div>
					</div>
					<!--中间内容end-->
					<div class="lovezs_all-top">
						<img src="mimages/dr_cp/b_bot.jpg" />
					</div>
				</div>
			</div>
			<!--真爱协议end-->
			<!--选填项目-->
			<div class="detail_number">
				<i>选填项目：</i>
			</div>
			<div class="txxy_bk the_xt">
				<p>女生会很在乎您记得这些重要的日子。<br/>
				不一定要送礼，一句问候或是<br/>
				一份惊喜都能给爱情加分。<br/>
				如果有重要的节日让Darry Ring帮您提醒。</p>
				<p>
					<span>她的生日：</span>
                    <select id="date1Year" style="width:70px;">
						<option value="-1">-</option>
                        <asp:Repeater runat="server" ID="rpDate1Year">
                            <ItemTemplate>
                                <option <%#Eval("Attribute") %> value="<%#Eval("value") %>"><%#Eval("Text") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
					</select>
					<span>年</span>
					<select id="date1Month" style="width:50px;">
						<option value="-1">-</option>
                        <asp:Repeater runat="server" ID="rpDate1Month">
                            <ItemTemplate>
                                <option value="<%#Eval("value") %>"><%#Eval("Text") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
					</select>
					<span>月</span>
					<select id="date1Day">
						<option value="-1">-</option>
                        <asp:Repeater runat="server" ID="rpDate1Day">
                            <ItemTemplate>
                                <option value="<%#Eval("value") %>"><%#Eval("Text") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
					</select>
					<span>日</span>
				</p>
				<p>
					<span>纪念日一：</span>
                    <select id="date2Year" style="width:70px;">
						<option value="-1">-</option>
                        <asp:Repeater runat="server" ID="rpDate2Year">
                            <ItemTemplate>
                                <option <%#Eval("Attribute") %> value="<%#Eval("value") %>"><%#Eval("Text") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
					</select>
					<span>年</span>
					<select id="date2Month" style="width:50px;">
						<option value="-1">-</option>
                        <asp:Repeater runat="server" ID="rpDate2Month">
                            <ItemTemplate>
                                <option value="<%#Eval("value") %>"><%#Eval("Text") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
					</select>
					<span>月</span>
					<select id="date2Day">
						<option value="-1">-</option>
                        <asp:Repeater runat="server" ID="rpDate2Day">
                            <ItemTemplate>
                                <option value="<%#Eval("value") %>"><%#Eval("Text") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
					</select>
					<span>日</span>
				</p>
				<p>
					<span>纪念日二：</span>
                    <select id="date3Year" style="width:70px;">
						<option value="-1">-</option>
                        <asp:Repeater runat="server" ID="rpDate3Year">
                            <ItemTemplate>
                                <option <%#Eval("Attribute") %> value="<%#Eval("value") %>"><%#Eval("Text") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
					</select>
					<span>年</span>
					<select id="date3Month" style="width:50px;">
						<option value="-1">-</option>
                        <asp:Repeater runat="server" ID="rpDate3Month">
                            <ItemTemplate>
                                <option value="<%#Eval("value") %>"><%#Eval("Text") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
					</select>
					<span>月</span>
					<select id="date3Day">
						<option value="-1">-</option>
                        <asp:Repeater runat="server" ID="rpDate3Day">
                            <ItemTemplate>
                                <option value="<%#Eval("value") %>"><%#Eval("Text") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
					</select>
					<span>日</span>
				</p>
			</div>
			<!--选填项目end-->
			<div class="theyz_bt">
				<button type="button" class="yz-button">提交</button>
			</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageEndJs" runat="server">
</asp:Content>
