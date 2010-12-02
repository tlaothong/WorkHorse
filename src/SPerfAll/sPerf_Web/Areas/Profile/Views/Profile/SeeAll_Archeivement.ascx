<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#SeeAll_Archeivement").dialog({
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
        $(".SeeAll").click(function () {
            $("#SeeAll_Archeivement").dialog("open");
            return false;
        });
    });
</script>
<div id="SeeAll_Archeivement" title="SeeAll Archeiement"></div>