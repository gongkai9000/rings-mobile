/*轮播图*/

var thisImgIndex = 0;  //当前显示的图片的下标下标
var $nums = $('.num li');  //列表集
var $content = $('.content');  //列表容器
var $imgs = $('.content img');   //图片集
var pagewidth = document.body.clientWidth; //获得屏幕的宽度
var timer = null; //定时器
$(function () {
    $(window).resize(function () {
        pagewidth = document.body.clientWidth; //获得屏幕的宽度
        $('.main').width(pagewidth);  //设置外层容器的宽度
        $imgs.width(pagewidth);       //设置图片的宽度
        $content.width(pagewidth * $imgs.length);  //设置容器的宽度
    });

    $('.main').width(pagewidth);  //设置外层容器的宽度
    $imgs.width(pagewidth);       //设置图片的宽度
    $content.width(pagewidth * $imgs.length);  //设置容器的宽度
    function show() {
        if (timer) { clearInterval(show); }
        $nums.eq(thisImgIndex).addClass('on').siblings().removeClass('on');
        $content.stop(true, false).animate({ marginLeft: -(thisImgIndex * pagewidth) + 'px' }, 400, function () {	 //移动图片，速度为1秒	
            timer = setInterval(function () {
                show();
            }, 3000);  //每 秒钟切换图片
        });
    }
    timer = setInterval(function () {
        thisImgIndex = thisImgIndex + 1 > $imgs.length - 1 ? 0 : thisImgIndex + 1;
        show();
    }, 3000);  //每3秒钟切换图片	

});

