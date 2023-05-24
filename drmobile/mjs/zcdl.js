/*注册登陆*/
$(function(){
	//点击消失报错
	function wrong_hide(){
		$('.wrong').fadeOut();
	};
	$('.wrong').click(function(){
		wrong_hide();
	});
//	//自动消失
//	setTimeout(wrong_hide,3000)
	//点击删除
	$('.clear span').each(function (index, el) {
		$(this).click(function(){
			$('.clear input').eq(index).val('');	
		});
	});
	//信息消失
	function news_hide(){
		$('.success').fadeOut();
	};
//	//自动消失
//	setTimeout(news_hide,3000)
});
