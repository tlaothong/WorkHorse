<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
<link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("#Upload_Popup").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 600,
            title: "Upload Video",
            buttons: {                
                "OK": function () {
                    $(this).dialog("close");
                },
                "Cancel": function () {
                    $(this).dialog("close");
                }

            }
        });
        $("#Upload_Click").click(function () {
            $("#Upload_Popup").dialog("open");
        });
    });
</script>
<script type="text/javascript">
</script>
<div id="Upload_Popup" style=" display: none">
    <div>
        <fieldset style="border: 1px solid #A49F9F; padding: 10">
            <legend align="left" style="font-size: small; height: 30px; color: #A49F9F">Agreement</legend>
            <div style="padding-left: 80px">
                1.You can upload Game/Without document
                <br />
                2.Rule is no Rule
                <br />
                3.Thank you
            </div>
        </fieldset>
    </div>
    <br />
    <div>
        <input type="checkbox" checked="checked" />I accept This agreement</div>
    <fieldset>
        <legend>Upload details</legend>
        <table>
            <tr>
                <td>
                    <div>
                        <label>
                            Application name:
                        </label>
                        <input type="text" /></div>
                    <div>
                        <label>
                            Application file:
                        </label>
                        <input type="file" value="Browse"/></div>
                    <div>
                        <label>
                            Application image:
                        </label>
                        <input type="file" /></div>
                </td>
                <td>
                    <label>
                        Description</label><textarea rows="4" cols="50"></textarea>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
