<%@ Page Title="" Language="C#" MasterPageFile="~/master/nSite.Master" AutoEventWireup="true" CodeBehind="MyCollect.aspx.cs" Inherits="drmobile.MyCollect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="mjs/CustomControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        var a;
        var s;
        $(function () {
            a = new MyAlert();
            s = new Success();
            $(".mbdr_cp-word p").find("a").click(function () {
                var id = $(this).attr("fid");
                var self = this;
                a.SureEvent = function () {
                    $.post("/API/favorites.ashx?action=delete&id=" + id, function () {
                        s.Show("删除成功");
                        $(self).parents("li").remove();
                    });
                };
                a.Show("你确定要删除该收藏吗？");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			<div class="spwidth_608">
				<ul class="mbdr_cp fix">
<asp:Repeater runat="server" ID="rpCollect">
    <ItemTemplate>
<!--608区域内-->
					<li>
						<div class="mbdr_cp-img">
							<a href="<%#getUrl(GetDataItem() as DRM.Entity.view_myfavorites) %>">
								<img src="<%#Eval("imgurl") %>" width="140" height="140"/>
							</a>
						</div>
						<div class="mbdr_cp-word mbdr_sc-word">
							<p class="hsp-height"><%#Eval("title") %></p>
							<p>
								<span class="fl">￥<%#string.Format("{0:N0}", Eval("MemberPrice")) %></span><a href="javascript:void(0)" fid="<%#Eval("id") %>"><i class="iconfont delbut fr">&#xe612;</i></a>
							</p>
						</div>
					</li>            
                    </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
                        <div class="qrtc" style="display:none">
		        <p></p>
		        <div class="detail_but">
			        <a href="javascript:void(0)" class="bkwhirte fl">取消</a>
			        <a href="javascript:void(0)" class="fr">确定</a>
		        </div>
	        </div>
</asp:Content>
