<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuyControl.ascx.cs" Inherits="drmobile.muc.BuyControl" %>
<%@ Import Namespace="DRM.Common" %>
			<!--购买框-->
			<div class="forbuy">
				<div class="forbuy_all">
					<div class="forbuy_left fl">
						<a href="javascript:addCart()" class="tocart">加入购物车</a>
						<a href="javascript:toBuy()" class="tobuy">立即购买</a>
					</div>
					<div class="forbuy_right fr">
						<a href="javascript:NTKF.im_openInPageChat()">
							<img src="/mimages/dr_cp/lxkf.png" width="36" />
						</a>
					</div>
				</div>
			</div>
			<!--购买框end-->

         <!--返回顶部-->
        <div class="iconfont fh_top">
            &#xe601;</div>
        <!--返回顶部end-->
<script src="/mjs/fhdb.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    NTKF_PARAM = {
        siteid: "kf_9883",                            //Ntalker提供平台基础id,
        settingid: "kf_9883_1402631963601",          //Ntalker分配的缺省客服组id  
        uid: "<%=UserID %>",                                //用户id
        uname: "<%=NickName %>",                     //用户名              
        orderid: "",                     //订单id
        orderprice: "",                        //订单价格
    }
</script>
<script type="text/javascript" src="http://dl.ntalker.com/js/xn6/ntkfstat.js?siteid=kf_9883" charset="utf-8"></script>