//设置手指左右滑动
    $(function(){
        $(".scroller img").click(function(event) {
            return false;
        });
        var _wwww = $("#wrapper").width();
        $(".scroller li").css("width",_wwww+"px");
        $(".scroller").css("width",_wwww * $(".scroller li").length +"px");
        var myScroll = new iScroll('wrapper', {
			zoom:false,
            snap: true,
            hScroll:true,
			vScroll:false,
            momentum: false,
            Scrollbar: false,
            hScrollbar: false,
            vScrollbar: false,
			//onBeforeScrollStart: null,  去掉的话支持UC浏览器左右滑动，但是无法上下拖动
   		 });
	});