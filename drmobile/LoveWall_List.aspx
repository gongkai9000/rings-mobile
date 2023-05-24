<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true"
    CodeBehind="LoveWall_List.aspx.cs" Inherits="drmobile.LoveWall_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--返回选项-->
    <div class="fhx">
        <a href="Propose.aspx">返回</a> <span>求婚墙</span>
    </div>
    <!--活动列表-->
    <ul class="hd_list">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li><a href="Lovewall_Article.aspx">
                    <!--左边-->
                    <div class="hdl_left">
                        <div class="fl">
                            <img src="images/st.jpg" width="60" height="60" />
                        </div>
                        <div class="bt_right">
                            <h4>
                                活动标题活动标题活动标题</h4>
                            <p>
                                活动标题活动标题活动标题</p>
                        </div>
                    </div>
                    <!--右边-->
                    <div class="hdl_right">
                        <span>></span>
                    </div>
                </a></li>
            </ItemTemplate>
        </asp:Repeater>
        <%--<li>
    	<a href="lovewall_article.html">
    	<!--左边-->
    	<div class="hdl_left">
        	<div class="fl">
        		<img src="img/st.jpg" width="60" height="60" />
            </div>
            <div class="bt_right">
                <h4>活动标题活动标题活动标题</h4>
                <p>活动标题活动标题活动标题</p>
            </div>
        </div>
        <!--右边-->
    	<div class="hdl_right">
        	<span>></span>
        </div> 
        </a>
    </li>
   	<li>
    	<a href="lovewall_article.html">
    	<!--左边-->
    	<div class="hdl_left">
        	<div class="fl">
        		<img src="img/st.jpg" width="60" height="60" />
            </div>
            <div class="bt_right">
                <h4>活动标题活动标题活动标题</h4>
                <p>活动标题活动标题活动标题</p>
            </div>
        </div>
        <!--右边-->
    	<div class="hdl_right">
        	<span>></span>
        </div> 
        </a>
    </li>
    <li>
    	<a href="lovewall_article.html">
    	<!--左边-->
    	<div class="hdl_left">
        	<div class="fl">
        		<img src="img/st.jpg" width="60" height="60" />
            </div>
            <div class="bt_right">
                <h4>活动标题活动标题活动标题</h4>
                <p>活动标题活动标题活动标题</p>
            </div>
        </div>
        <!--右边-->
    	<div class="hdl_right">
        	<span>></span>
        </div> 
        </a>
    </li>
    <li>
    	<a href="lovewall_article.html">
    	<!--左边-->
    	<div class="hdl_left">
        	<div class="fl">
        		<img src="img/st.jpg" width="60" height="60" />
            </div>
            <div class="bt_right">
                <h4>活动标题活动标题活动标题</h4>
                <p>活动标题活动标题活动标题</p>
            </div>
        </div>
        <!--右边-->
    	<div class="hdl_right">
        	<span>></span>
        </div> 
        </a>
    </li>
    <li>
    	<a href="lovewall_article.html">
    	<!--左边-->
    	<div class="hdl_left">
        	<div class="fl">
        		<img src="img/st.jpg" width="60" height="60" />
            </div>
            <div class="bt_right">
                <h4>活动标题活动标题活动标题</h4>
                <p>活动标题活动标题活动标题</p>
            </div>
        </div>
        <!--右边-->
    	<div class="hdl_right">
        	<span>></span>
        </div> 
        </a>
    </li>
    <li>
    	<a href="lovewall_article.html">
    	<!--左边-->
    	<div class="hdl_left">
        	<div class="fl">
        		<img src="img/st.jpg" width="60" height="60" />
            </div>
            <div class="bt_right">
                <h4>活动标题活动标题活动标题</h4>
                <p>活动标题活动标题活动标题</p>
            </div>
        </div>
        <!--右边-->
    	<div class="hdl_right">
        	<span>></span>
        </div> 
        </a>
    </li>
    <li>
    	<a href="lovewall_article.html">
    	<!--左边-->
    	<div class="hdl_left">
        	<div class="fl">
        		<img src="img/st.jpg" width="60" height="60" />
            </div>
            <div class="bt_right">
                <h4>活动标题活动标题活动标题</h4>
                <p>活动标题活动标题活动标题</p>
            </div>
        </div>
        <!--右边-->
    	<div class="hdl_right">
        	<span>></span>
        </div> 
        </a>
    </li>--%>
    </ul>
</asp:Content>
