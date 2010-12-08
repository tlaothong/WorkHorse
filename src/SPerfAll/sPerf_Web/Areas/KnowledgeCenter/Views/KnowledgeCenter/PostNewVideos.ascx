<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
<script src="../../../../Scripts/JCore.js" type="text/javascript"></script>
<link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("#New_Video").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 600,
            title: "Upload Video",
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        $("#Popup").click(function () {
            $("#New_Video").dialog("open");
        });
    });
</script>
<script type="text/javascript">
</script>
<div id="New_Video">
    <div>
        <fieldset style="border: 1px solid #A49F9F; padding: 10">
            <legend align="left" style="font-size: small; height: 30px;"><font color=" #A49F9F">
                Agreement</font> </legend>
            <div style='padding-left: 80px'>
                <br />
                <p>
                    <br />
                    1. Agreement<br />
                    2. Agreement<br />
                    3. Agreement<br />
                    4. Agreement<br />
                    5. Agreement<br />
                    6. Agreement<br />
                    7. Agreement<br />
                    8. Agreement<br />
                    9. Agreement<br />
                    10. Agreement<br />
                </p>
                <br />
                <input type="checkbox" /><label>I Agree</label><br />
                <input type="checkbox" /><label>I Disagree</label>
            </div>
        </fieldset>
    </div>
    <br />
    <table style="text-align: center">
        <tr>
            <td align="left">
                Back
            </td>
            <td align="right">
                Next
            </td>
        </tr>
        <br />
        <tr>
            <td align="left">
                <button type="button">
                    Step 1</button>
                <button type="button">
                    Step 2</button>
                <button type="button">
                    Step 3</button>
            </td>
        </tr>
    </table>
    <fieldset>
        <legend>Upload details</legend>
        <table id="FileList">
            <tr>
                <td>
                    <form action="" method="post" enctype="multipart/form-data">
                    <label for="file">
                        Location:
                        <input type="file" name="file" id="file" /></label>
                    <input type="submit" value="upload" />
                    </form>
                </td>
                <td>
                    <div style="float: left;">
                        Tags<input type="text" value="Tag1; Tag2; Tag3;" /></div>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <div>
                        Video name<input type="text" /></div>
                    <div>
                        Group<select><option>Please select</option>
                        </select></div>
                    <div>
                        Sub Group<select><option>Please select</option>
                        </select></div>
                </td>
                <td>
                    <div>
                        <label>
                            Description</label><textarea rows="4" cols="50"></textarea></div>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
