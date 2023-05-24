/*返回消失出现*/
$(window).scroll(function(){
	if ($(window).scrollTop() >= 800) {
		$(".fh_top").show();
	}
	else {
		$(".fh_top").hide();
	};
	/*点击返回顶部*/
	$(".fh_top").click(function(){
		$("html,body").stop(true, false).animate({ "scrollTop": 0 + 'px' }, 300)
	})
});