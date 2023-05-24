/*删除弹窗*/
$(function(){
	//删除商品时出现弹窗
	$('.delbut').click(function(){
		$('.bk_gray').fadeIn();
		$('.qrtc').fadeIn();
	});
	//删除商品时点击取消
	$('.detail_but a').click(function(){
		$('.bk_gray').fadeOut();
		$('.qrtc').fadeOut();
	})
});

/*个人中心*/
$(function(){
	//点击评价变色
	$('.mbask_two i').click(function(){
		$(this).toggleClass('ks_click')
	});
	//点击星星变色
	$('.mbask_one i').each(function(index){
		$(this).click(function(){
			$('.mbask_one i').removeClass('star_click');
			for(var i =0; i< index+1;i++){
				$('.mbask_one i').eq(i).addClass('star_click')
			}
		});
	});	
	//点击匿名评论变色
	$('.ask_people span').click(function(){
		$(this).toggleClass('box_click')
	});
});
/*收货地址*/
$(function(){

//	//点击取消(地址弹窗)
//	$('.detail_but a').click(function(){
//		$('.bk_gray').fadeOut();
//		$('.showtc').fadeOut();
//	});
//	//赋值
//	$('.dz_position').each(function(index){
//		$(this).click(function(){
//			$('.bk_gray').fadeIn();
//			$('.showtc').fadeIn();
//			$('.showtc_ul li').each(function(index){
//				$(this).off('click').on('click',function(){
//					$(this).addClass('tc_click').siblings().removeClass('tc_click');
//				});
//			});	
//			$('.sureit').off('click').on('click',function(){
//				$('.fz_span').eq(index).find('span').html($('.showtc_ul li.tc_click span').eq(0).html());
//				$('.bk_gray').fadeOut();
//				$('.showtc').fadeOut();
//			});
//		})
//	});
});

