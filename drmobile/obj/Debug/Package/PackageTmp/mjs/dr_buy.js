//商品详情
$(function () {
    //点击消失报错
    function wrong_hide() {
        $('.wrong').fadeOut();
    };
    $('.wrong').click(function () {
        wrong_hide();
    });
    //自动消失
    setTimeout(wrong_hide, 3000)
    //点击删除
    $('.clear span').each(function (index, el) {
        $(this).click(function () {
            $('.clear input').eq(index).val('');
        });
    });
    //信息消失
    function news_hide() {
        $('.success').fadeOut();
    };
    //自动消失
    setTimeout(news_hide, 3000);
    //商品导航切换
    $('.thenav_ul-all').each(function (index, el) {
        $(this).click(function () {
            //            $(".shop_one img").show();
            $('html,body').scrollTop($(window).scrollTop() + 100);
            $(this).parent().toggleClass('thenav_clickshow');
            $(this).parent().find(".shop_allit").slideToggle();
        })
    });
    //材质等选项
    $('.cz_choose i').each(function (index, el) {
        $(this).click(function () {
            $(this).addClass('cp_click').siblings().removeClass('cp_click');
        })
    });
    $('.qt_zs i').each(function (index, el) {
        $(this).click(function () {
            $(this).addClass('cp_click').siblings().removeClass('cp_click');
        })
    });
    $('.morechoose_it i').click(function () {
        $(this).toggleClass('cp_click');
    });
    //点击出现更多选择
    $('.more_but').click(function () {
        $(this).toggleClass('hidemore_but')
        $('.morechoose').toggle()
    });
    //刻字     
    $(".write_choose").click(function () {
        if ($(".kz_txt").length == 1)
            $(".kz_txt").val($(".kz_txt").val() + ($(this).text()).charAt());
        //html改成text也可以执行
    });
    //支付方式
    $('.payway_ul li').each(function (index, el) {
        $(this).click(function () {
            $(this).addClass('theclick_d').siblings().removeClass('theclick_d');
        })
    });
})
