<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#Report_Archeivement").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 450,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $(".Report").click(function () {
            $("#Report_Archeivement").dialog("open");
            return false;
        });
    });
</script>
<div id="Report_Archeivement" title="Report Archeivement" style="z-index: 10;">
<table>
        <tr>
            <td valign="top">
                <img src="/Content/images/ProfileAvatar.png" />
            </td>
            <td valign="top">username: Wanida<br />DateTime(1/8/2552 12:50:45)<br />
                <select>
                      <option>Inappriate content</option>
                      <option>Bug</option>
                      <option>Error</option>
                </select><br /><br />
                Topic : <input type="text" title="Some Text"/>
                <textarea rows="10"; cols="27">Details.....</textarea>
            </td>
        </tr>
    </table>
</div>
