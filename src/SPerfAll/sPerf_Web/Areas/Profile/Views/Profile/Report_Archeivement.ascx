<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#Report_Archeivement").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 500,
            height: 500,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $(".Report").click(function () {
            $("#Report_Archeivement").dialog("open");
            return false;
        });
    });
</script>
<div id="Report_Archeivement" title="Report Archeivement" style="z-index: 10;">
    <div style="background-color: White; margin-bottom: 5px; border: 1px solid #5FB546;">
        <table>
            <tr>
                <td style="width: 200px;">
                    <label>
                        Ohh.! I'm your top Friend</label>
                </td>
                <td style="width: 200px;">
                    <img src="../../../../Content/profile/1.png" alt="" />
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: White; margin-bottom: 5px; border: 1px solid #5FB546;">
        <table>
            <tr>
                <td style="width: 200px;">
                    <label>
                        You are welcome</label>
                </td>
                <td style="width: 200px;">
                    <img src="../../../../Content/profile/1.png" alt="" />
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: White; margin-bottom: 5px; border: 1px solid #5FB546;">
        <table>
            <tr>
                <td style="width: 200px;">
                    <img src="../../../../Content/profile/2.png" alt="" />
                </td>
                <td style="width: 200px;">
                    <label>
                        Thanks,...Nanay...</label>
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: White; margin-bottom: 5px; border: 1px solid #5FB546;">
        <table>
            <tr>
                <td style="width: 200px;">
                     <label>
                        Hi,first comment</label>
                </td>
                <td style="width: 200px;">
                   <img src="../../../../Content/profile/1.png" alt="" />
                </td>
            </tr>
        </table>
    </div>
</div>
