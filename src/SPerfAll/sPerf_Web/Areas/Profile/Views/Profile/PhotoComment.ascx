<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%--script for New comment--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#dialogphoto").dialog({
            autoOpen: false,
            width: 450,
            title: 'New Comment',
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
        $('#dialog_linkphoto').click(function () {
            $('#dialogphoto').dialog('open');
            return false;
        });
    });

</script>

<%--script for seeall--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#sellAll").dialog({
            autoOpen: false,
            width: 600,
            buttons: {
                "Ok": function () {
                    $(this).dialog("close");
                },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });

        // Dialog Link
        $('#seell').click(function () {
            $('#sellAll').dialog('open');
            return false;
        });
    });

</script>

<%--script for report--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#showReport").dialog({
            autoOpen: false,
            width: 450,
            title: 'Report Problem',
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
        $('.reports').click(function () {
            $('#showReport').dialog('open');
            return false;
        });
    });

</script>

<table><tr><td><div ><label id="dialog_linkphoto"style="background-color:#DEDFE1; padding:2px 2px 2px 2px;border:1px solid gray inherit;">Comment(50)</label></div></td><td><div id="seell" style="text-decoration: underline; color:Blue; margin-left:45px;">SeeAll</div></td></tr></table>
<%--div for comment dialog--%>
<div id="dialogphoto">
<table>
        <tr>
            <td valign="top">Pet Society<br /><input type="checkbox" />   Rating  : <img src="/Content/images/star.PNG" /><br />
                Comment :<br /><br />
                <textarea rows="10"; cols="45">Comment text here</textarea>
            </td>
        </tr>
    </table>
</div>

<%--div for seeall dialog--%>
<div id="sellAll">
testddddd
</div>

<%--div for report dialog--%>
<div id="showReport">
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

<div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin; width:150px;"></div>
<div id="listContent">
 <div>
        <table>
            <tr>
                <td valign="top">
                    <img src="/Content/images/e1.png" />
                </td>
                <td valign="top">
                    Wanida
                </td>
            </tr>
        </table>
        <div style="width:150px;">ทดสอบข้อความเพื่อใช้ทำงานของการเขียนคอมเม้น</div>
        <label class="reports" style="text-decoration: underline; color:Blue; margin-left:120px;">report</label>
        <div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin;  width:150px;"></div>

    </div>
    <div>
        <table>
            <tr>
                <td valign="top">
                    <img src="/Content/images/e1.png" />
                </td>
                <td valign="top">
                    Wanida
                </td>
            </tr>
        </table>
        <div style="width:150px;">ทดสอบข้อความเพื่อใช้ทำงานของการเขียนคอมเม้น</div>
        <label class="reports" style="text-decoration: underline; color:Blue; margin-left:120px;">report</label>
        <div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin;  width:150px;"></div>

    </div>
    <div>
        <table>
            <tr>
                <td valign="top">
                    <img src="/Content/images/e1.png" />
                </td>
                <td valign="top">
                    Wanida
                </td>
            </tr>
        </table>
        <div style="width:150px;">ทดสอบข้อความเพื่อใช้ทำงานของการเขียนคอมเม้น</div>
        <label class="reports" style="text-decoration: underline; color:Blue; margin-left:120px;">report</label>
        <div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin;width:150px;"></div>
    </div>
    <div>
        <table>
            <tr>
                <td valign="top">
                    <img src="/Content/images/e1.png" />
                </td>
                <td valign="top">
                    Wanida
                </td>
            </tr>
        </table>
        <div style="width:150px;">ทดสอบข้อความเพื่อใช้ทำงานของการเขียนคอมเม้น</div>
        <label class="reports" style="text-decoration: underline; color:Blue; margin-left:120px;">report</label>
        <div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin;width:150px;"></div>

    </div>
    <div>
        <table>
            <tr>
                <td valign="top">
                    <img src="/Content/images/e1.png" />
                </td>
                <td valign="top">
                    Wanida
                </td>
            </tr>
        </table>
        <div style="width:150px;">ทดสอบข้อความเพื่อใช้ทำงานของการเขียนคอมเม้น</div>
        <label class="reports" style="text-decoration: underline; color:Blue; margin-left:120px;">report</label>
        <div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin;width:150px;"></div>

    </div>

</div>
<br />
<table><tr><td></td><td><label style="text-decoration: underline; color:Blue">more..</label></td></tr></table>