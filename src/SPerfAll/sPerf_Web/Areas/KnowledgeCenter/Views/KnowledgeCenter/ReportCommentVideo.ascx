<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#ReportCommentVideo").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 450,
            height: 300,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "OK": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $(".ReportCommentVideo_Click").click(function () {
            $("#ReportCommentVideo").dialog("open");
            return false;
        });
    });
</script>

<div id="ReportCommentVideo" title="Report Comment" style="z-index: 10 ;"></div>