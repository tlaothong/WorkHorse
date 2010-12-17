<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        $('#survey').dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 500,
            resizable: true,
            title: "Upload Video"
        });
        $(function () {
            $("#tabs").tabs();
        });
        $("#Popup").click(function () {
            $("#survey").dialog("open");
        });
    });
</script>
<div id="survey" style="z-index: 9000;">
    <div>
    <fieldset style="border:1px solid #A49F9F; padding:10" >
        <legend align="left" style="font-size:small ; height:30px;">
            <font color=" #A49F9F">Agreement</font>
        </legend>
        <div style='padding-left:80px'>
            <font>
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
                 10. Agreement<br /></p>
                <br />
            </font>
            <input type="checkbox"><label>I Agree</label></input><br />
            <input type="checkbox"><label>I Disagree</label></input>
        </div>
    </fieldset>
    </div>
    <br />
    <table style="text-align:center">
        <tr>
            <td align="left">
            Back
            </td>
            <td align="right" >Next</td>
        </tr>
        <br />
        <tr>
            <td align="left">
                <button type="button">Step 1</button><button type="button">Step 2</button><button type="button">Step 3</button>
            </td>
        </tr>
    </table>
</div>
