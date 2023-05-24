    /*nav_choose的切换*/
	$(function(){
	$('.nav_choose li').each(function(index, element) {   //循环遍历.tobuy_ul li
        $(this).bind('click',function(){   //绑定单击事件
			$(this).addClass('orther_bk').siblings().removeClass('orther_bk');   //给单击的li元素添加class:soit,其他的li移除class:soit	
			$('.all_ym #toit').eq(index).show().siblings().hide();					
		});
	});
	})
	/*材质的变色*/
	$(function(){
	$('.cz_choose').each(function(index, element) { 	 
        $(this).click(function(){									
			$(this).addClass("to_color").siblings().removeClass("to_color"); 
		});
    });
	})
	/*变换钻石的变色*/
	$(function(){
	$('.jewel_ul li').each(function(index, element) { 	 //获取到.jewel_ul 下面所有class为pos的Li，然后循环这Li
        $(this).click(function(){							//设置每个获取到的Li,设置单击事件		
			$(this).addClass("lother").siblings().removeClass("lother"); 
		});
    });
	})
    /*刻字新改*/
    $(function () {
        $(".write_choose").click(function () {
            $(".ipt_1").val($(".ipt_1").val() + ($(this).text()).charAt());
            //html改成text也可以执行
        });
    });
	
	