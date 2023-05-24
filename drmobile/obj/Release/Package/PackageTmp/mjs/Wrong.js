function Wrong() {
    return {
        Show: function (msg) {
//            $("html,body").stop(true, false).animate({ "scrollTop": 0 + 'px' }, 300);
            $(".wrong span").text(msg);
            $(".wrong").slideDown();
            var _self = this;
            setTimeout(function () {
                _self.Exit();
            }, 5000);
        },
        Exit: function () {
            $(".wrong").slideUp();
        }
    }
}

//$(".wrong").click(function () {
//    w.Exit();
//})

function checkMobile(mobile) {
    var myreg = /^(((1[0-9]{1}))+\d{9})$/;
    if (mobile == "") {
        return false;
    }
    if (!myreg.test(mobile)) {
        return false;
    }
    return true;
}

//<%--验证邮编 --%>
function checkCode(zipcode) {
    var MyNumber = /^[0-9]{1}[0-9]{5}$/;
    return MyNumber.test(zipcode);

}

function checkEmail(strEmail) {
    if (strEmail.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
        return true;
    else {
        return false;
    }
}

var Redirect = function (page) {
    clearTimeout(this.redirectTimer);
    this.redirectTimer = setTimeout(function () { window.location = page; }, 1000);
}