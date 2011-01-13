<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script language="javascript" type="text/javascript">
    function showHide(shID) {
        if (document.getElementById(shID)) {
            if (document.getElementById(shID + '-show').style.display != 'none') {
                document.getElementById(shID + '-show').style.display = 'none';
                document.getElementById(shID).style.display = 'block';
            }
            else {
                document.getElementById(shID + '-show').style.display = 'inline';
                document.getElementById(shID).style.display = 'none';
            }
        }
    }
</script>
<%--script for New comment--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#dialogphoto").dialog({
            autoOpen: false,
            modal: true,
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
            modal: true,
            width: 400,
            title: "ความคิดเห็น"
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
            modal: true,
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
<table>
    <tr>
        <td>
            <div >
                <label id="dialog_linkphoto"style="background-color:#939597; padding:2px 4px 2px 4px;border: 1px solid gray; color:White;">comment  (251)</label>
            </div>
        </td>
        <td>
            <a href="#"><div id="seell" style="text-decoration: underline; color:Gray; margin-left:28px;">
                SeeAll
            </div></a>
       </td>
   </tr>
</table><%--div for comment dialog--%>
<div id="dialogphoto">
<table>
        <tr>
            <td valign="top">Pet Society<br />
                Comment :<br /><br />
                <textarea rows="10"; cols="45">Comment text here</textarea>
            </td>
        </tr>
    </table>
</div>

<%--div for seeall dialog--%>
<div id="sellAll">
    <table>
            <tr>
            <td valign="top">
                <img src="/Content/profile/pic_friend/1.png" />
            </td>
            <td valign="top">Wanida<br />ได้แสดงข้อความของคุณเมื่อ (17/11/2510) เวลา 12.00 น.
            </td>
        </tr>
        <tr>
            <td valign="top">
                <img src="/Content/profile/pic_friend/1.png" />
            </td>
            <td valign="top">Wanida<br />ได้แสดงข้อความของคุณเมื่อ (17/11/2510) เวลา 12.00 น.
            </td>
        </tr>
         <tr>
            <td valign="top">
                <img src="/Content/profile/pic_friend/2.png" />
            </td>
            <td valign="top">Jitti<br />ได้แสดงข้อความของคุณเมื่อ (17/11/2510) เวลา 12.00 น.
            </td>
        </tr>
         <tr>
            <td valign="top">
                <img src="/Content/profile/pic_friend/3.png" />
            </td>
            <td valign="top">Siriluk<br />ได้แสดงข้อความของคุณเมื่อ (17/11/2510) เวลา 12.00 น.
            </td>
        </tr>
         <tr>
            <td valign="top">
                <img src="/Content/profile/pic_friend/4.png" />
            </td>
            <td valign="top">Jibjawg<br />ได้แสดงข้อความของคุณเมื่อ (17/11/2510) เวลา 12.00 น.
            </td>
        </tr>
         <tr>
            <td valign="top">
                <img src="/Content/profile/pic_friend/5.png" />
            </td>
            <td valign="top">Kapita<br />ได้แสดงข้อความของคุณเมื่อ (17/11/2510) เวลา 12.00 น.
            </td>
        </tr>
         <tr>
            <td valign="top">
                <img src="/Content/profile/pic_friend/6.png" />
            </td>
            <td valign="top">Harnnongbour<br />ได้แสดงข้อความของคุณเมื่อ (17/11/2510) เวลา 12.00 น.
            </td>
        </tr>
    </table>
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
            <label class="reports" style="color:Gray; margin-left:115px;">report</label>
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
            <label class="reports" style="color:Gray; margin-left:115px;">report</label>
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
            <label class="reports" style="color:Gray; margin-left:115px;">report</label>
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
            <label class="reports" style="color:Gray; margin-left:115px;">report</label>
        <div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin;width:150px;"></div>

    </div>

                <a href="#" id="example-show" class="showLink" onclick="showHide('example');return false;">
            SeeMore...</a>
