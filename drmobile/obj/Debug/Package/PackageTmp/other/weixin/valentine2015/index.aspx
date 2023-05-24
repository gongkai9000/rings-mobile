<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="drmobile.other.weixin.valentine2015.index" %>

<!DOCTYPE html>
<html lang="en">
	<head>
		<meta charset="utf-8">
		<title>嫁给我！一生与你相伴-CTloves 真爱钻戒</title>
		<meta name="description" content="嫁给我！一生与你相伴" />
		<meta name="apple-touch-fullscreen" content="YES" />
		<meta name="format-detection" content="telephone=no" />
		<meta name="apple-mobile-web-app-capable" content="yes" />
		<meta name="apple-mobile-web-app-status-bar-style" content="black" />
		<meta http-equiv="Expires" content="0" />
		<meta http-equiv="Cache-Control" content="no-cache" />
		<meta http-equiv="Access-Control-Allow-Origin" content="*">
		<meta http-equiv="Pragma" content="no-cache" /> 
		<link rel="stylesheet" type="text/css" href="css/main.css"/>
		<script src="js/theviemport.js" type="text/javascript" charset="utf-8"></script>		
</head>
<body>
<div id="ticket_wrap">
	<div id="loadingwrap">
		<div class="alert-loading z-move">
			<div class="loader">加载中...</div>
		</div>
	</div>			
			
	<div id="animwrap"  class="">
		<div id="audio" onclick="musicplay(this)">
			<audio src="http://resource.ctloves.com/video/ILoveYouTooMuch.mp3" autoplay="autoplay" loop="loop" data-src="media/baidu.mp3" id="music"></audio>
		</div>
				
		<div class="anim-swip hide anim1">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim1-img1"><img src="img/index/logo.png"/></span>
			<span class="radius anim1-img2"><img src="img/index/h1-word.png"/></span>
			<em class="radius playBtn" onClick="playVideo();"></em>
			<div class="index-video">
				<div class="index-video-bg"></div>
				<button class="btn-close" onClick="closeVideo();"></button>
				<video id="drvideo">
				  <source src="http://resource.ctloves.com/video/m2.webm" type="video/webm" />
				  <source src="http://resource.ctloves.com/video/m2.mp4" type="video/mp4" />
				  您的设备不支持HTML5 Video.
				</video>
			</div>
		</div>	
		<!-- 求婚篇	 -->
		<div class="anim-swip hide anim2">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim2-img1"><img src="img/qhp/s1_word.png"/></span>
		</div>
		<div class="anim-swip hide anim3">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim3-img1"><img src="img/qhp/f1_word.png"/></span>
			<span class="radius anim3-img2"><img src="img/qhp/f1_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim4">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim4-img1"><img src="img/qhp/f2_word.png"/></span>
			<span class="radius anim4-img2"><img src="img/qhp/f2_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim5">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim5-img1"><img src="img/qhp/f3_word.png"/></span>
			<span class="radius anim5-img2"><img src="img/qhp/f3_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim6">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim6-img1"><img src="img/qhp/f4_word.png"/></span>
			<span class="radius anim6-img2"><img src="img/qhp/f4_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim7">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim7-img1"><img src="img/qhp/f5_word.png"/></span>
			<span class="radius anim7-img2"><img src="img/qhp/f5_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim8">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim8-img1"><img src="img/qhp/f6_word.png"/></span>
			<span class="radius anim8-img2"><img src="img/qhp/f6_ring.png"/></span>
			<span class="radius anim8-img3" onclick="javascript:location.href='/diamondring_list.aspx'"><img src="img/qhp/sbutton.jpg"/></span>
		</div>	
		<!-- 结婚篇 -->
		<div class="anim-swip hide anim9">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim9-img1"><img src="img/jhp/j1_word.png"/></span>
		</div>
		<div class="anim-swip hide anim10">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim10-img1"><img src="img/jhp/h1_word.png"/></span>
			<span class="radius anim10-img2"><img src="img/jhp/h1_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim11">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim11-img1"><img src="img/jhp/h2_word.png"/></span>
			<span class="radius anim11-img2"><img src="img/jhp/h2_ring.png"/></span>
			<span class="radius anim11-img3" onclick="javascript:location.href='/phonics_list.aspx?type=3'"><img src="img/jhp/jbutton.jpg"/></span>
		</div>
		<!-- 相伴篇 -->
		<div class="anim-swip hide anim12">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim12-img1"><img src="img/xbp/x1_word.png"/></span>
		</div>
		<div class="anim-swip hide anim13">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim13-img1"><img src="img/xbp/b1_word.png"/></span>
			<span class="radius anim13-img2"><img src="img/xbp/b1_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim14">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim14-img1"><img src="img/xbp/b2_word.png"/></span>
			<span class="radius anim14-img2"><img src="img/xbp/b2_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim15">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim15-img1"><img src="img/xbp/b3_word.png"/></span>
			<span class="radius anim15-img2"><img src="img/xbp/b3_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim16">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim16-img1"><img src="img/xbp/b4_word.png"/></span>
			<span class="radius anim16-img2"><img src="img/xbp/b4_ring.png"/></span>
		</div>
		<div class="anim-swip hide anim17">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
			<span class="radius anim17-img1"><img src="img/xbp/b5_word.png"/></span>
			<span class="radius anim17-img2"><img src="img/xbp/b5_ring.png"/></span>
			<span class="radius anim17-img3" onclick="javascript:location.href='/phonics_list.aspx'"><img src="img/xbp/xbutton.jpg"/></span>
		</div>
		<div class="anim-swip hide anim18">
			<span class="swiparrow"><img src="img/arrow.png" alt="" /></span>
              <div class="card">
                <p class="card_head">亲爱的：<input class="input card_to" type="text" /></p>                
                <p class="card_content"><textarea></textarea></p>
                <p class="card_footer">爱你的：<input class="input card_to" type="text" /></p>
              </div>
			<span class="radius anim18-img1 submit" id="sendBtn" onclick="shareOther();">立即发送贺卡</span>
		</div>		
	</div>
<div class="card_fx"></div>
</div>
	
<script src="js/jquery-1.9.1.min.js" type="text/javascript" charset="utf-8"></script>
<script src="js/main.js" type="text/javascript" charset="utf-8"></script>
<script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"> </script>
<script type="text/javascript">
    var msgTitle = "嫁给我！一生与你相伴";
    var msgDesc = "CTloves真爱钻戒，男士一生仅能定制一枚";
    var msgLink = "";
    var msgImgurl = "<%=host %>/other/weixin/valentine2015/img/weixinshare.jpg";
    function shareOther() {
        msgTitle = "亲爱的"+$(".card_head input").val() + '，我想对你说……';

        msgDesc = $(".card_content textarea").val();

        var to = $(".card_head input").val();
        var from = $(".card_footer input").val();
        var content = $(".card_content textarea").val();
        msgLink = '<%=host %>/other/weixin/valentine2015/card.aspx?msgfrom=' + encodeURIComponent(from) + "&msgto=" + encodeURIComponent(to) + "&content=" + encodeURIComponent(content)

        msgImgurl = '<%=host %>/other/weixin/valentine2015/img/weixinshare.jpg';

        share();

        $('.card_fx').show();
    }

    function share()
    {
        //分享给朋友
        wx.onMenuShareAppMessage({
            title: msgTitle, // 分享标题
            desc: msgDesc, // 分享描述
            link: msgLink,
            imgUrl: msgImgurl,
            success: function () {
                // 用户确认分享后执行的回调函数
            },
            fail: function () {
                alert("分享失败");
            }
        });
        //分享到朋友圈
        wx.onMenuShareTimeline({
            title: msgTitle, // 分享标题
            link: msgLink,
            imgUrl: msgImgurl,
            success: function (res) {
            },
            fail: function () {
                alert("分享失败");
            }
        });
        wx.onMenuShareQQ({
            title: msgTitle, // 分享标题
            desc: msgDesc, // 分享描述
            link: msgLink,
            imgUrl: msgImgurl,
            success: function (res) {
            },
            fail: function () {
                alert("分享失败");
            }
        });
        wx.onMenuShareWeibo({
            title: msgTitle, // 分享标题
            desc: msgDesc, // 分享描述
            link: msgLink,
            imgUrl: msgImgurl,
            success: function (res) {
            },
            fail: function () {
                alert("分享失败");
            }
        });
    }

    $(function () {
        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: '<%=appid %>', // 必填，公众号的唯一标识
            timestamp: "<%=timestamp %>", // 必填，生成签名的时间戳
            nonceStr: '<%=nonceStr %>', // 必填，生成签名的随机串
            signature: '<%=signature %>', // 必填，签名，见附录1
            jsApiList: [
                'onMenuShareTimeline',
                'onMenuShareAppMessage',
                'onMenuShareQQ',
                'onMenuShareWeibo',
            ] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
        wx.ready(function () {
            share();
        });

    });

</script>
</body>
</html>

