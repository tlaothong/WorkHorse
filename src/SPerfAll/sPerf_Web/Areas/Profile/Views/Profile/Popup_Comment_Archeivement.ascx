<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#Popup_Comment_Archeivement").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 300,
            height: 300,
            buttons: {
                "OK": function () {
                    $(this).dialog("close");
                },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $("#Comment_Archeivement").click(function () {
            $("#Popup_Comment_Archeivement").dialog("open");
            return false;
        });
    });
</script>
<div id="Popup_Comment_Archeivement" title="New Comment" style="z-index: 10;">
    <div>Pet Society</div>
    <div><input type="checkbox" /><label>Rating:</label></div>
    <div>Comment:</div>
    <div><textarea rows="5" cols="30">Comment text here</textarea></div>
</div>
