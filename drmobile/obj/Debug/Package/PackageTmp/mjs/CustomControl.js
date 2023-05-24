function MyAlert() {

    var result = {
        Show: function (msg) {
            $(".qrtc p").html(msg);
            $(".qrtc").slideDown();
            $(".bk_gray").slideDown();
        },
        Sure: function () {
            this.SureEvent();
            exit();
        },
        Cancel: function () {
            exit();
        },
        SureEvent: function(){
            
        }
    }
    var exit = function () { 
        $(".qrtc").slideUp();
        $(".bk_gray").slideUp();
    }

    $(".qrtc .detail_but .fr").click(function () {
        result.Sure();
    });
    $(".qrtc .detail_but .bkwhirte").click(function () {
        result.Cancel();
    });
    return result;
}