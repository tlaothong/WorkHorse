<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#Archeivement").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 500,
            height: 500,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $("#compare").click(function () {
            $("#Archeivement").dialog("open");
            return false;
        });
    });
</script>

<div id="Archeivement" title="Archeivement Point Comparer" style="z-index: 10 ;"></div>
