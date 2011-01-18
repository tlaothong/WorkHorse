<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%--script for report--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#HomeOption").dialog({
            autoOpen: false,
            modal: true,
            width: 450,
            title: 'Option',
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
        $('#homeOption').click(function () {
            $('#HomeOption').dialog('open');
            return false;
        });
    });
</script>

<%--div for report dialog--%>
<div id="HomeOption">
    <table>
                    <tr>
                         <td>
                            <div>Who can access :</div>
                            <div><input type="radio" />All users</div>
                            <div><input type="radio" />My friend only</div>
                            <div><input type="radio" />Me only</div>
                         </td>
                    </tr>
                    <tr>
                         <td>
                            <div>Comment :</div>
                            <div><input type="radio" />All users read only</div>
                            <div><input type="radio" />All users can read & write</div>
                            <div><input type="radio" />My friend read only</div>
                            <div><input type="radio" />My friend can read & write</div>
                            <div><input type="radio" />Only me can write</div>
                         </td>
                    </tr>
                    <tr>
                         <td>
                            <div>Notification :</div>
                            <div><input type="radio" />All</div>
                            <div><input type="radio" />Only self related</div>
                         </td>
                    </tr>
                   <%-- <tr>
                         <td>
                            <label id="Label1" style="color:Green; margin-left:350px;">Save</label>|<label id="Label2" style="color:Red;">Cancel</label>
                         </td>
                    </tr>--%>
                </table>
</div>

