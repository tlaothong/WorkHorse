<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<!--Script For HoverScroll-->
<script type="text/javascript">
    $(document).ready(function () {
        $('#listContent').hoverscroll({ vertical: true, height: 300, width: 150 });
    });        
</script>
<script type="text/javascript">
    $(function () {
        $('#survey').dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 500,
            resizable: true,
            title: "New comment"
        });
        $("#dialog").click(function () {
            $("#survey").dialog("open");
        });
    });
</script>

<script type="text/javascript">
    $(function () {
        var availableTags = [
			"ActionScript",
			"AppleScript",
			"Asp",
			"BASIC",
			"C",
			"C++",
			"Clojure",
			"COBOL",
			"ColdFusion",
			"Erlang",
			"Fortran",
			"Groovy",
			"Haskell",
			"Java",
			"JavaScript",
			"Lisp",
			"Perl",
			"PHP",
			"Python",
			"Ruby",
			"Scala",
			"Scheme"
		];
        $("#tags").autocomplete({
            source: availableTags
        });
    });
	</script>
    <table width="100" border="0" cellspacing="0" cellpadding="0">
<%--    <tr>
        <td>
            <div><label for="tags"></label><img src="/Content/images/1.png" /><img src="/Content/images/2.png" /><input id="tags" style="width:90px"><img src="/Content/images/go.jpg" /> </div>
        </td>
    </tr>--%>
    <tr>
        <td>
            <div id="survey" style="z-index: 9000;">
                <table style="text-align:center">
                    <tr>
                        <td align="left">Pet Society</td>
                    </tr>
                    <tr>
                        <td align="left">
                            <input type="checkbox" /> Rating : <img src="Content/images/star.png" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Comment : 
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                           <textarea cols="60" rows="25">Comment text here..</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <button>OK</button> 
                        </td>
                        <td align="right">
                            <button>Cancel</button>
                        </td>
                    </tr>
                </table>
            </div>  
        </td>
    </tr>
    <tr>
        <td valign="top">
            <button id="dialog">Comment</button>
            
        </td>
        <td><select id="Select1">
                <option> 1</option>
                <option> 2</option>
                <option> 3</option>
                <option> 4</option>
                <option> 5</option>
            </select> </td>
    </tr>
</table>
<div id="listContent">
    <table>
        <tbody>
            <tr><td valign="top"><img src="/Content/images/1.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/2.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/1.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/2.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/1.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/2.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/1.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/2.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/1.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/1.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/2.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
            <tr><td valign="top"><img src="/Content/images/1.png" /></td><td valign="top">(17 hours ago)<br />ทดสอบข้อความเพื่อใช้ทำงาน</td></tr>
        </tbody>
    </table>
</div>
<div id="AvarComment"></div> 