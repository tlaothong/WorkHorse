<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
<link href="../../Content/smoothDivScroll.css" rel="stylesheet" type="text/css" />
<script src="../../../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
<script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
<script src="../../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
<script src="../../Scripts/jquery.smoothDivScroll-1.1-min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("div#makeMeScrollable").smoothDivScroll({ autoScroll: "onstart",
            autoScrollDirection: "backandforth",
            autoScrollStep: 1,
            autoScrollInterval: 15,
            startAtElementId: "startAtMe",
            visibleHotSpots: "always"
        });

    });
	</script>
<style type="text/css">
	
	#makeMeScrollable
	{
		width:400;
		height: 330px;
		position: relative;
	}
	
	#makeMeScrollable div.scrollableArea *
	{
		position: relative;
		float: left;
		margin: 0;
		padding: 0;
	}
	
	</style>

<%--script for New comment--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#dialog_cartoons").dialog({
            autoOpen: false,
            position:'center',
            width:620,
            height:250,
            modal: true,
            title: 'New Comment',
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
           <div id="wrapper">
                <div id="mainColumn">
	                <div id="makeMeScrollable">
		                <div class="scrollingHotSpotLeft"></div>
		                <div class="scrollingHotSpotRight"></div>
		                <div class="scrollWrapper">
			                <div class="scrollableArea">
				                <img src="/Content/images/field.jpg" alt="Demo image" width="150" height="100" />
				                <img src="/Content/images/gnome.jpg" alt="Demo image" width="150" height="100" />
				                <img src="/Content/images/pencils.jpg" alt="Demo image" width="150" height="100" />
				                <img src="/Content/images/golf.jpg" alt="Demo image" width="150" height="100" id="startAtMe" />
				                <img src="/Content/images/river.jpg" alt="Demo image" width="150" height="100" />
				                <img src="/Content/images/train.jpg" alt="Demo image" width="150" height="100" />
				                <img src="/Content/images/leaf.jpg" alt="Demo image" width="150" height="100" />
				                <img src="/Content/images/dog.jpg" alt="Demo image" width="150" height="100"/>
			                </div>
		                </div>
	                </div>
	            <br/>
                </div>
            </div>
           <%--end scroll images--%>
</div>