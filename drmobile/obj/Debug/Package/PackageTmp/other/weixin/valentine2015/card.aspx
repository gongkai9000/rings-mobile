<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="card.aspx.cs" Inherits="drmobile.other.weixin.valentine2015.card" %>

<!DOCTYPE html>
<html lang="en">
	<head>
		<meta charset="utf-8">
		<title>20150214情人节</title>
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
			
	<div id="animwrap" style="display:block">
		<div class="anim-swip anim18 active anim-star">
              <div class="card">
                <p class="card_head">亲爱的：<input class="input card_to" type="text" readonly="readonly" value="<%=msgto %>" /></p>                
                <p class="card_content"><textarea readonly="readonly"><%=content%></textarea></p>
                <p class="card_footer">爱你的：<input class="input card_to" type="text" readonly="readonly" value="<%=msgfrom%>"/></p>
              </div>
			<span class="radius anim18-img1" onclick="javascript:location.href='index.aspx'"><img src="img/hk/lbutton.jpg"/></span>
		</div>		
	</div>
</div>

</body>
</html>

