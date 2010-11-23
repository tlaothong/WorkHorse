<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
<script src="../../../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
<script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#dialog").dialog({
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
        $('#dialog_link').click(function () {
            $('#dialog').dialog('open');
            return false;
        });
    });

</script>
<table><tr><td><div ><label id="dialog_link" style="background-color:Gray; padding:2px 2px 2px 2px;">Comment</label></div></td><td><div id="seell">SeeAll</div></td></tr></table>
<div id="dialog"></div>
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
        <div class="showReport"></div>
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
        <div class="showReport"></div>
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
        <div class="showReport"></div>
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
        <div class="showReport"></div>
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
        <div class="showReport"></div>
        <div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin;width:150px;"></div>

    </div>

</div>
<br />
<table><tr><td></td><td><label style="text-decoration: underline; color:Blue">more..</label></td></tr></table>
