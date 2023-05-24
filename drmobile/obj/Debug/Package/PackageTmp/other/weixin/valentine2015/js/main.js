var step = 0;
var touchdown = 0;
var downY = 0;
var downY2 = 0;
var moveY = 0;
var moveing = 0;
var moveTop = 0;
var upORdown = 0;
var onoff = false;
var HH = $(window).height();
var ud = "";
var touchsize = $('#animwrap .anim-swip').size();
var obj = document.getElementById("ticket_wrap");
function notnull(i){
	return (''!=i)&&(i!='undefined')
}

$(function () {
    var params = getUrlVars();
    var start = params['start'];
    var end = params['end'];
    var triptime = params['gotime'];
    triptime = decodeURI(triptime)
    var d = new Date(triptime);
    if (notnull(start) && (notnull(end) & notnull(triptime)) && (d != 'Invalid Date')) {
        showticket()
    } else {
        setTimeout(function () {
            page_init();
        }, 1000);
    }

    // 设置视频top
    var bodyHeight = $('#animwrap').height();
    var drvideoTop = (bodyHeight / 2) - 140;
    $('#drvideo').css('top', drvideoTop + 'px');
    $('.btn-close').css('top', drvideoTop - 40 + 'px');

    //播放视频时禁止滑动屏幕
    $('.index-video').on('touchmove', function (e) {
        e.stopPropagation();
        e.preventDefault();
    });

    //    // 发送贺卡
    //	$('#sendBtn').click(function(){
    //		$(this).html('正在发送...').attr('disabled','true');
    //	})

    $('.card_fx').click(function () {
        $(this).hide();
    });
})
//显示票信息
function showticket(){
	$('#loadingwrap').fadeOut();
}

function page_init() {
	$('#loadingwrap').fadeOut();
	$('#animwrap').fadeIn(1000);
	$('#ticket_wrap,.anim-swip').css('height', HH);
	$('#animwrap .anim-swip').css('top',HH);
	$('#ticket_wrap .anim-swip:first').removeClass('hide').addClass('active').css('top',0);
	setTimeout(function(){enteracitve(0)},500);
	var today = new Date();
	//today.setDate(today.getDate() + 1)
	var year = today.getFullYear();
	var m = today.getMonth() + 1;
	var d = today.getDate();
	var time = year + '-' + m + '-' + d;
	$('#gotime').val(time);
	obj.addEventListener("mousedown", down, false);
	obj.addEventListener("mousemove", move, false);
	obj.addEventListener("mouseup", up, false);
	obj.addEventListener("touchstart", down, false);
	obj.addEventListener("touchmove", move, false);
	obj.addEventListener("touchend", up, false);
	document.getElementById('music').play();
	$('body').on('resize', function() {
		$('#ticket_wrap,#animwrap,body').css({
			'left': 0,
			'top': 0,
			'width':'100%',
			'height':HH
		})
	});
}

function down(event) {
	if (moveing == 1) return;
	if (step < 0) {
		step = 0;
		return
	} else if (step > touchsize - 1) {
		step = touchsize - 1;
		return
	}

	onoff = true;
	moveing = 0;
	if (event.targetTouches) {
		downY = event.targetTouches[0].pageY;
		downY2 = event.targetTouches[0].pageY;
	} else if (event.touches) {
		var touch = event.touches[0];
		downY = touch.pageY;
		downY2 = touch.pageY;
	} else {
		downY = event.pageY;
		downY2 = event.pageY;
	}
}

function move(event) {
	if (step < 0 || step > touchsize - 1) {
		return
	}
	event.stopPropagation(); //
	event.preventDefault(); //
	if (event.targetTouches) {
		moveY = event.targetTouches[0].pageY;
	} else if (event.touches) {
		var touch = event.touches[0];
		moveY = touch.pageY;
	} else {
		moveY = event.pageY;
	}
	upORdown = moveY - downY; //
	if (onoff == true) {
		//向上滑或下滑
		var r = upORdown > 0 ? moveY : $(window).height() - moveY;
		if (upORdown > 0) {
			if (moveing == 0) {
				step--;
				$("#animwrap .anim-swip").addClass("hide");
				$("#animwrap .anim-swip").removeClass("show");
				$("#animwrap .anim-swip").removeClass("active");
				$("#animwrap .anim-swip").eq(step + 1).removeClass("active");
				$("#animwrap .anim-swip").eq(step + 1).addClass("show");
				$("#animwrap .anim-swip").eq(step).css({
					top: -HH
				}).removeClass("hide")
				$("#animwrap .anim-swip").eq(step).addClass("active");
				ud = "down";
				moveing = 1;
				// 视频层级升高
				if(step == 0){				
					$('.index-video video').css('zIndex','101');
				}
			} else {
				r = (1 - Math.abs(.1 * r / $(window).height())).toFixed(6);
				moveTop = parseInt($(".active").css("top"));
				$(".active").css({
					top: moveTop + upORdown
				});
				//$('.show').css('transform',"translate(0,"+a+"px) scale("+r+")");
			}
		} else if (upORdown <= 0) {
			if (moveing == 0) {
				if(step<=4){
					if($("#animwrap .anim-swip").eq(step).hasClass('addstep')){
						
						step++;
						$("#animwrap .anim-swip").addClass("hide");
						$("#animwrap .anim-swip").removeClass("show");
						$("#animwrap .anim-swip").removeClass("active");
						$("#animwrap .anim-swip").eq(step - 1).removeClass("active");
						$("#animwrap .anim-swip").eq(step - 1).addClass("show");
						$("#animwrap .anim-swip").eq(step).css({
							top: HH
						}).removeClass("hide")
						$("#animwrap .anim-swip").eq(step).addClass("active");
						ud = "up";
						moveing = 1;

						// 视频层级降低
						if(step == 1){				
							$('.index-video video').css('zIndex','0');
						}
					}else{
						//4以内没add
						$("#animwrap .anim-swip").eq(step).addClass('addstep');
					}
				}else{
					step++;
					$("#animwrap .anim-swip").addClass("hide");
					$("#animwrap .anim-swip").removeClass("show");
					$("#animwrap .anim-swip").removeClass("active");
					$("#animwrap .anim-swip").eq(step - 1).removeClass("active");
					$("#animwrap .anim-swip").eq(step - 1).addClass("show");
					$("#animwrap .anim-swip").eq(step).css({
						top: HH
					}).removeClass("hide")
					$("#animwrap .anim-swip").eq(step).addClass("active");
					ud = "up";
					moveing = 1;
				}
				

			} else {
				//a=-a;
				r = (1 - Math.abs(.1 * r / $(window).height())).toFixed(6);
				moveTop = parseInt($(".active").css("top"));
				$(".active").css({
					top: moveTop + upORdown
				});
				//	$('.show').css('transform',"translate(0,"+a+"px) scale("+r+")");
			}
		}

	}
	downY = moveY;
}

function up(event) {
	onoff = false;
	if (step < 0) {
		moveing = 0;
		step = 0;
		return;
	} else if (step > touchsize - 1) {
		moveing = 0;
		step = touchsize - 1;
		return;
	}
	var ylong = Math.abs(moveY - downY2)
	if (ud == "down") { //upORdown>0
		if (moveing == 1) {
			if (ylong > HH / 6) {
				$(".active").animate({
					top: "0px"
				},400, function() {
					moveing = 0;
					upORdown = 0;
					ud = "";
					enteracitve(step);
				})
			} else {
				$(".active").animate({
					top: -HH
				}, 400, function() {
					step++;
					$("#animwrap .anim-swip").addClass("hide");
					$("#animwrap .anim-swip").removeClass("show");
					$("#animwrap .anim-swip").removeClass("active");
					$("#animwrap .anim-swip").eq(step).removeClass("active");
					$("#animwrap .anim-swip").eq(step).addClass("show");
					$("#animwrap .anim-swip").eq(step - 1).css({
						top: -HH
					}).removeClass("hide")
					$("#animwrap .anim-swip").eq(step - 1).addClass("active");
					moveing = 0;
					upORdown = 0;
					ud = "";
				});
			}
		}
	} else if (ud = "up") { //upORdown <0
		if (moveing == 1) {
			if (ylong > HH / 6) {
				$(".active").animate({
					top: "0px"
				}, 400, function() {
					moveing = 0;
					upORdown = 0;
					ud = "";
					enteracitve(step);
				})
			} else {
				$(".active").animate({
					top: HH
				}, 400, function() {
					step--;
					$("#animwrap .anim-swip").addClass("hide");
					$("#animwrap .anim-swip").removeClass("show");
					$("#animwrap .anim-swip").removeClass("active");
					$("#animwrap .anim-swip").eq(step + 1).removeClass("active");
					$("#animwrap .anim-swip").eq(step + 1).css({
						top: HH
					}).addClass("show");
					$("#animwrap .anim-swip").eq(step).css({
						top: "0px"
					}).removeClass("hide")
					$("#animwrap .anim-swip").eq(step).addClass("active");
					moveing = 0;
					upORdown = 0;
					ud = "";
				});
			}

		}
	}
}

function musicplay(o){
	$(o).toggleClass('stop').find('span').toggle();
	if($(o).hasClass('stop')){
		document.getElementById('music').pause();
	}else{
		document.getElementById('music').play();
	}
	
}

function enteracitve(i) {
		$('#animwrap .anim-swip').removeClass('anim-star').eq(i).addClass('anim-star');
	}


 function getUrlVars(){ 

var vars =[], hash; 

var hashes = window.location.href.slice(window.location.href.indexOf('?')+1).split('&'); 

for(var i = 0; i < hashes.length; i++) { 

hash = hashes[i].split('='); 

vars.push(hash[0]); 

vars[hash[0]] = hash[1]; 

} 
return vars; 
} 

var drVideo = document.getElementById('drvideo');
function playVideo(){
  $('.index-video').show();
  if(drVideo.paused){
    drVideo.play();
  }  
  musicplay($('#audio'));
  $('#audio').css('zIndex','99');
}

function closeVideo(){
  $('.index-video').hide();
  drVideo.pause();
  musicplay($('#audio'));
  $('#audio').css('zIndex','101');
}


