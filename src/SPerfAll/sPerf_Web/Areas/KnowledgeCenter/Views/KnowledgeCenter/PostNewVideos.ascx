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
            show: "Transfer",
			hide: "Transfer",
            title: "Upload Video",
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        $("#New_Video").dialog({ zIndex: 3999 });
        $("#Popup").click(function () {
            $("#New_Video").dialog("open");
        });
    });
    $.maxZIndex = $.fn.maxZIndex = function (opt) {
        /// <summary>
        /// Returns the max zOrder in the document (no parameter)
        /// Sets max zOrder by passing a non-zero number
        /// which gets added to the highest zOrder.
        /// </summary>    
        /// <param name="opt" type="object">
        /// inc: increment value, 
        /// group: selector for zIndex elements to find max for
        /// </param>
        /// <returns type="jQuery" />
        var def = { inc: 10, group: "*" };
        $.extend(def, opt);
        var zmax = 0;
        $(def.group).each(function () {
            var cur = parseInt($(this).css('z-index'));
            zmax = cur > zmax ? cur : zmax;
        });
        if (!this.jquery)
            return zmax;

        return this.each(function () {
            zmax += def.inc;
            $(this).css("z-index", zmax);
        });
    }
</script>
<script type="text/javascript">
</script>
<div id="New_Video" style=" z-index: 9999999">
    <div>
        <fieldset style="border: 1px solid #A49F9F; padding: 10">
            <legend align="left" style="font-size: small; height: 30px; color: #A49F9F">
                Agreement</legend>
            <div style="padding-left: 80px">
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
