<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#ReportCommentGame").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 350,
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
        $(".ReportCommentGame_Click").click(function () {
            $("#ReportCommentGame").dialog("open");
            return false;
        });
    });
</script>
<div id="ReportCommentGame" title="Report Comment" style="z-index: 10; display: none">
    <table>
        <tr>
            <td valign="top">
                <div>
                    <img src="../../../../Content/images/wanida.jpg" alt="" />
                </div>
                <div>
                    Wanida</div>
            </td>
            <td>
                <div>
                    <label>
                        UserName: Wanida</label>
                </div>
                <div>
                    DateTime(1/8/2552 12:50:45)</div>
                <div>
                    <select>
                        <option>Inappriate content</option>
                        <option>Bug</option>
                        <option>Error</option>
                    </select>
                </div>
                <div>
                    <label>
                        Topic:</label><input type="text" value="Some text" size="25" /></div>
                <div>
                    <textarea rows="7" cols="30">Details</textarea></div>
            </td>
        </tr>
    </table>
</div>
