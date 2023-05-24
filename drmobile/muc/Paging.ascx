<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Paging.ascx.cs" Inherits="drmobile.muc.Paging" %>
<script src="/Scripts/iscroll.js" type="text/javascript"></script>
<script type="text/javascript">
    var <%=ClientObjectName %> = {};
    $(function () { 
        <%=ClientObjectName %>.CurrentPageNum = <%=CurrentPageNum %>;

        var pullUpEl = $("#pullUp");	
	    pullUpOffset = $(pullUpEl).height();
        var myScroll = new iScroll("<%=SrollControlID %>",{
            topOffset:pullUpOffset,
            onRefresh:function(){
                if (pullUpEl.hasClass('loading')) {
				    pullUpEl.removeClass("loading");
			    }
            },
            onScrollMove:function(){
                if (this.y < (this.maxScrollY - 5) && !pullUpEl.hasClass('flip')) {
                    pullUpEl.addClass("flip");
				    this.maxScrollY = this.maxScrollY;
			    } else if (this.y > (this.maxScrollY + 5) && pullUpEl.hasClass('flip')) {
				    pullUpEl.removeClass("flip");
				    this.maxScrollY = pullUpOffset;
			    }
            },
            onScrollEnd:function(){
                if (pullUpEl.hasClass('flip')) {
                    pullUpEl.removeClass("flip");
                    pullUpEl.addClass("loading");
//				    pullUpEl.querySelector('.pullUpLabel').innerHTML = 'Loading...';				
				    pullUpAction();	// Execute custom function (ajax call?)
			    }
            }
        });
        <%=ClientObjectName %>.LoadComplete = function(){
            myScroll.refresh();
        };
        function pullUpAction(){  
            <%=ClientObjectName %>.CustomChanged(<%=ClientObjectName %>.CurrentPageNum + 1);
        }
    });
</script>