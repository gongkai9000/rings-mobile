<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiamondSearch.ascx.cs" Inherits="drmobile.muc.DiamondSearch" %>
<script type="text/javascript">
    var isSpot = false;
    var currentDiamondPage = 1;
    $(function () {
        $(".search_xh").click(function () {
            isSpot = true;
            loadData(1);
        });
        $(".search_lk").click(function () {
            isSpot = false;
            loadData(1);
        });
        $(".search_it-right i").click(function () {
            if ($(this).hasClass("search_it-xs") || $(this).hasClass("search_it-xx")) {
                if ($(this).hasClass("search_it-xs")) {
                    $(this).removeClass("search_it-xs");
                    $(this).addClass("search_it-xx");
                }
                else {
                    $(this).removeClass("search_it-xx");
                    $(this).addClass("search_it-xs");
                }
            }
            else {
                var c = $(this).addClass("search_it-xx");
                c.siblings().removeClass('search_it-xx');
                c.siblings().removeClass('search_it-xs');
            }
            loadData(currentDiamondPage);
        });
        $(".cp_lzfy a").eq(0).click(function () {
            if ($(this).hasClass("cp_nopage")) {
                return;
            }
            loadData(currentDiamondPage-1);
        });
        $(".cp_lzfy a").eq(1).click(function () {
            if ($(this).hasClass("cp_nopage")) {
                return;
            }
            loadData(currentDiamondPage+1);
        });
    });

    function getOrderbyArgs() {
        var by = "";
        var descby = $.trim($(".search_it-xx").attr("orderby"));
        var ascby = $.trim($(".search_it-xs").attr("orderby"));

        if (descby != "") {
            by = descby + " desc";
        }
        else if (ascby != "") {
            by = ascby + " asc";
        }

        var data = [];
        data.push("orderby");
        data["orderby"] = by;

        return data;
    }
    function loadData(num) {
        var checkbl = true;
        $(".morechoose_it input").each(function () {
            if (isNaN($(this).val())) {
                w.Show($(this).parent().find("span").text() + "不是正确数字");
                checkbl = false;
                return false;
            }
        });
        if (!checkbl) {
            return;
        }
        var paras = [];
        paras.push(dToGetArgs());
        paras.push(getOrderbyArgs());
        var url = "";
        $(paras).each(function (index) {
            var item = this;
            $(item).each(function () {
                var key = this.toString();
                var value = item[key];
                url += "&" + key + "=" + value;
            });
        });

        $.get("/API/DiamondAPI.aspx?isSpot=" + isSpot + "&pid=<%=ProductID %>&pagenum=" + num + url + "&mprice=" + CurrentMaterialPrice + "&Material=" + CurrentMaterial, function (data) {
            $(".mbdr_cp").html(data);
            $("#divDiamond").show();
            currentDiamondPage = num;
            if (currentDiamondPage <= 1) {
                $(".cp_lzfy a").eq(0).addClass("cp_nopage");
            }
            else {
                $(".cp_lzfy a").eq(0).removeClass("cp_nopage");
            }
            if (currentDiamondPage >= ZSSearchPageCount) {
                $(".cp_lzfy a").eq(1).addClass("cp_nopage");
            }
            else {
                $(".cp_lzfy a").eq(1).removeClass("cp_nopage");
            }
        });
    }

    function dToGetArgs() {
        var dSearchStartBudget = $(".morechoose .morechoose_it").eq(0).find("input").eq(0).val();
        var dSearchEndBudget = $(".morechoose .morechoose_it").eq(0).find("input").eq(1).val();

        var dSearchStartWeight = $(".morechoose .morechoose_it").eq(1).find("input").eq(0).val();
        var dSearchEndWeight = $(".morechoose .morechoose_it").eq(1).find("input").eq(1).val();

        var dSearchColorArray = [];
        $("#morechoose_one .cp_click").each(function () { dSearchColorArray.push($(this).text()); });
        var dSearchQiegongArray = [];
        $("#morechoose_sec .cp_click").each(function () { dSearchQiegongArray.push($(this).text()); });
        var dSearchJingduArray = [];
        $("#morechoose_third .cp_click").each(function () { dSearchJingduArray.push($(this).text()); });
        var dSearchPaoguangArray = [];
        $("#morechoose_four .cp_click").each(function () { dSearchPaoguangArray.push($(this).text()); });
        var dSearchDuichenArray = [];
        $("#morechoose_five .cp_click").each(function () { dSearchDuichenArray.push($(this).text()); });
        var dSearchYingguangArray = [];
        $("#morechoose_six .cp_click").each(function () { dSearchYingguangArray.push($(this).text()); });

        var data = [];
        data.push("startBudget");
        data["startBudget"] = dSearchStartBudget;
        data.push("endBudget");
        data["endBudget"] = dSearchEndBudget;
        data.push("startWeight");
        data["startWeight"] = dSearchStartWeight;
        data.push("endWeight");
        data["endWeight"] = dSearchEndWeight;

        data.push("color");
        data["color"] = dSearchColorArray.join(',');
        data.push("jingdu");
        data["jingdu"] = dSearchJingduArray.join(',');
        data.push("qiegong");
        data["qiegong"] = dSearchQiegongArray.join(',');

        data.push("duichen");
        data["duichen"] = dSearchDuichenArray.join(',');
        data.push("paoguang");
        data["paoguang"] = dSearchPaoguangArray.join(',');
        data.push("yingguang");
        data["yingguang"] = dSearchYingguangArray.join(',');

        return data;
    }
</script>
<!--更多参数选择-->
				<div class="morechoose">
					<div class="morechoose_it">
						<span>预算</span>
						<img src="/mimages/ct_cp/money.png" style="margin:0 4px 0 3px"/>
						<input type="text" /><label>元</label>
						<input type="text" /><label>元</label>
					</div>
					<div class="morechoose_it">
						<span>钻重</span>
						<img src="/mimages/ct_cp/zs.png" />
						<input type="text" /><label>克拉</label>
						<input type="text" /><label>克拉</label>
					</div>
					<div class="morechoose_it morechoose_one" id="morechoose_one">
						<span>颜色</span>
						<b>
							<i>D</i><i>E</i><i>F</i><i>G</i><i>H</i><i>I</i><i>J</i><i class="nobder">K</i>
						</b>
					</div>
					<div class="morechoose_it morechoose_one" id="morechoose_sec">
						<span>切工</span>
						<b>
							<i>Ideal</i><i>EX</i><i>VG</i><i>GD</i><i class="nobder">Fair</i>
						</b>
					</div>
					<div class="morechoose_it morechoose_one" id="morechoose_third">
						<span>净度</span>
						<b>
							<i>IF</i><i>VVS1</i><i>VVS2</i><i>VS1</i><i>VS2</i><i>SI1</i><i class="nobder">SI2</i>
						</b>
					</div>
					<div class="morechoose_it morechoose_one" id="morechoose_four">
						<span>抛光</span>
						<b>
							<i>EX</i><i>VG</i><i>GD</i><i class="nobder">Fair</i>
						</b>
					</div>
					<div class="morechoose_it morechoose_one" id="morechoose_five">
						<span>对称</span>
						<b>
							<i>EX</i><i>VG</i><i>GD</i><i class="nobder">Fair</i>
						</b>
					</div>
					<div class="morechoose_it morechoose_one" id="morechoose_six">
						<span>荧光</span>
						<b>
							<i>NON</i><i>FNT</i><i>MED</i><i class="nobder">STG</i>
						</b>
					</div>
					<div class="thechoose_but">
						<a href="javascript:void(0)" class="search_xh fl">现货搜索</a>
						<a href="javascript:void(0)" class="search_lk fr">立即搜索</a>
					</div>
         		</div>
				<!--更多参数选择end-->

