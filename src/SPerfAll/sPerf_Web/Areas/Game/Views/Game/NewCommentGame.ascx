<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#NewCommentGame").dialog({
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
        $("#NewComment_Click").click(function () {
            $("#NewCommentGame").dialog("open");
            return false;
        });
    });
</script>

<div id="NewCommentGame" title="New Comment" style="z-index: 10 ;">
    <div>
        <div><label>Pet Society</label></div>
        <div><input type="checkbox" />Rating:</div>
        <div>Comment:</div>
        <div><textarea rows="10" cols="50">Comment text Here</textarea></div>
    </div>
</div>