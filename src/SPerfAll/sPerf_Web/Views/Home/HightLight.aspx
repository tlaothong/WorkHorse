<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	HightLight
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tagosphere.js" type="text/javascript"></script>
    <style type="text/css">
#tagSphere{
	position:absolute;
}
ul li{
	list-style:none;
	position:absolute;
}
a{text-decoration:none;}
#wrapper{
	background:#FFF;
	height:400px;
	margin:0 auto;
	padding:0;
	position:relative;
	text-align:center;
	width:400px;
}
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $('#tagoSphere').tagoSphere();
    });
</script>
<br />
<br />
<div style="background-color:#4F4D4C; width:625px; height:18px; color:White; margin-left:3px; margin-top:-30px;">HightLight</div>
<center>
<div id="wrapper">
	<div id="tagoSphere">
	  <ul>
	    <li><a href="#"><img src="/Content/HightLight/App1.png" /></a></li>
	    <li><a href="#"><img src="/Content/HightLight/App2.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/App3.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/Cook.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/Math.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/App1.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/App2.png" /></a></li>	   
        <li><a href="#"><img src="/Content/HightLight/App3.png" /></a></li>
	    <li><a href="#"><img src="/Content/HightLight/Cook.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/Math.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/App1.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/App2.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/App3.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/Cook.png" /></a></li>	   
	    <li><a href="#"><img src="/Content/HightLight/Math.png" /></a></li>	   
	  </ul>
	</div>
</div>
</center>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
<% Html.RenderPartial("SubMenu"); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
<% Html.RenderPartial("AdvanceSearch"); %>
<% Html.RenderPartial("Banners"); %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="startMenu" runat="server">
<% Html.RenderPartial("StartMenu"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="newsbar" runat="server">
<% Html.RenderPartial("newsBar"); %>
</asp:Content>
