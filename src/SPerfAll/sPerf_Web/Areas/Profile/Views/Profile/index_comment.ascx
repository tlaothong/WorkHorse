<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
<script src="../../../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
<script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
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
<style type="text/css">
    /* This CSS is just for presentational purposes. */
    #listContent
    {
        margin-top: 20px;
    }
    #wrap
    {
        font: 1.3em/1.3 Arial, Helvetica, sans-serif;
        width: 30em;
        margin: 0 auto;
        padding: 1em;
        background-color: #fff;
    }
    h1
    {
        font-size: 200%;
    }
    
    /* This CSS is used for the Show/Hide functionality. */
    .more
    {
        display: none;
    }
    a.showLink, a.hideLink
    {
        text-decoration: none;
        color: #36f;
        padding-left: 8px;
        background: transparent url(down.gif) no-repeat left;
    }
    a.hideLink
    {
        background: transparent url(up.gif) no-repeat left;
    }
    a.showLink:hover, a.hideLink:hover
    {
        border-bottom: 1px dotted #36f;
    }
</style>
<%--script for New comment--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#dialog").dialog({
            autoOpen: false,
            width: 450,
            modal: true,
            title:'New Comment',
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
        $('#dialog_link').click(function () {
            $('#dialog').dialog('open');
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
                <label id="dialog_link"style="background-color:#939597; padding:2px 4px 2px 4px;border: 1px solid gray; color:White;">comment  (251)</label>
            </div>
        </td>
        <td>
            <a href="#"><div id="seell" style="text-decoration: underline; color:Gray; margin-left:28px;">
                SeeAll
            </div></a>
       </td>
   </tr>
</table>
<%--div for comment dialog--%>
<div id="dialog">
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
        <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
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
        <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
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
        <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
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
        <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
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
        <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
        <div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin;width:150px;"></div>

    </div>
            <a href="#" id="example-show" class="showLink" onclick="showHide('example');return false;">
            SeeMore...</a>
        <div id="example" class="more showLink">

    <%--แสดงส่วนหลังเมื่อมีการตลิก more...--%>
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
            <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
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
            <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
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
            <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
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
            <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
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
            <a href="#"><label class="reports" style="text-decoration: underline; color:Gray; margin-left:115px;">report</label></a>
            <div style="border-bottom-color:#D2D5D2; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin;width:150px;"></div>

        </div>
    </div>
    <%--end more...--%>
</div>
