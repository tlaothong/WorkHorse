<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        $("#Option_Video").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 500,
            title: "Option",
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        $("#Option_Click").click(function () {
            $("#Option_Video").dialog("open");
        });
    });
</script>
<div id="Option_Video"></div>