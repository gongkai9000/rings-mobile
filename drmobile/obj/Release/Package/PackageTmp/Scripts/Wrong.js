function Wrong() {
    return {
        Insert: function (c) {
            var html = "<div class='wrong' style='display:none'><p id='warnMessage'></p></div>";
            $(c).after(html);
        },
        Show: function (msg) {
            $("html,body").stop(true, false).animate({ "scrollTop": 0 + 'px' }, 300);
            $(".wrong #warnMessage").text(msg);
            $(".wrong").slideDown();
        },
        Exit: function () {
            $(".wrong").slideUp();
        }
    }
}