<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>


<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#ReportProblem").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 450,
            height: 300,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Send": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $("#ReportProblem_Click").click(function () {
            $("#ReportProblem").dialog("open");
            return false;
        });
    });
</script>

<div id="ReportProblem" title="Report Problem" style="z-index: 10 ;">
    <div style="margin-top: 10">
        <div>
            <select>
                <option>Inappriate content</option>
                <option>Bug</option>
            </select>
        </div>
        <div><textarea rows="10" cols="50">Details</textarea></div>
    </div>
</div>