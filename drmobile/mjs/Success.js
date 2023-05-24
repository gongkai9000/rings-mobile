function Success() {
    return {
        Show: function (msg) {
            //            $("html,body").stop(true, false).animate({ "scrollTop": 0 + 'px' }, 300);
            $(".success").text(msg);
            $(".success").slideDown();
            var _self = this;
            setTimeout(function () {
                _self.Exit();
            }, 5000);
        },
        Exit: function () {
            $(".success").slideUp();
        }
    }
}