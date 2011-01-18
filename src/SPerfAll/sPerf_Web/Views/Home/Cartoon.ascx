<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script src="../../Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
<script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
<script src="../../Scripts/easySlider1.5.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#slider").easySlider();
    });	
	</script>


<style type="text/css"> 

	#slider ul, #slider li{
		padding:0;
		list-style:none;
		overflow:hidden;
		}
	#slider li{ 
		width:630px;
		height:211px;
		overflow:hidden; 
		}
	span#prevBtn{}
	span#nextBtn{}					
</style>
	

<%--script for New comment--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#dialog_cartoons").dialog({
            autoOpen: false,
            position:'center',
            width:630,
            height: 370,
            modal: true,
            title: 'All Cartoon',
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Ok": function () {
                    $(this).dialog("close");
                }
            }
        });

        // Dialog Link
        $('#clickAll').click(function () {
            $('#dialog_cartoons').dialog('open');
            return false;
        });
    });
</script>
<div style="margin-left:0px"><img src="/Content/images/home_.jpg" /></div>
<div style="margin-left:0px;  width:607px; height:15px; background-color:#504B4B;">
<div id="clickAll"  style="margin-left:566px; color:White;">SeeAll</div></div>
<div id="dialog_cartoons">  
   <%--start scroll images--%>
           <div id="container">
	        <div id="content">
		        <div id="slider">
			        <ul>				
				        <li><a href="#"><img src="/Content/cartoon/01.jpg" alt="Css Template Preview" /></a></li>
				        <li><a href="#"><img src="/Content/cartoon/02.jpg" alt="Css Template Preview" /></a></li>
				        <li><a href="#"><img src="/Content/cartoon/03.jpg" alt="Css Template Preview" /></a></li>
				        <li><a href="#"><img src="/Content/cartoon/04.jpg" alt="Css Template Preview" /></a></li>
				        <li><a href="#"><img src="/Content/cartoon/05.jpg" alt="Css Template Preview" /></a></li>			
			        </ul>
		        </div>
          </div>
         </div>

           <%--end scroll images--%>
</div>