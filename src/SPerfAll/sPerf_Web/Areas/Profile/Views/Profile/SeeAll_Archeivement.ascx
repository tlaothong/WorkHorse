<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#SeeAll_Archeivement").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 400,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $(".SeeAll").click(function () {
            $("#SeeAll_Archeivement").dialog("open");
            return false;
        });
    });
</script>
<div id="SeeAll_Archeivement" title="SeeAll Archeiement">
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
                 <tr>
            <td valign="top">
                <img src="/Content/profile/pic_friend/6.png" />
            </td>
            <td valign="top">Harnnongbour<br />ได้แสดงข้อความของคุณเมื่อ (17/11/2510) เวลา 12.00 น.
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