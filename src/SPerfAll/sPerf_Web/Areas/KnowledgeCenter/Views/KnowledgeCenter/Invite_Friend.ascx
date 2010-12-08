<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#InviteFriend").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 500,
            height: 500,
            title:"Invite Friend",
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "OK": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $("#InviteFriend_Click").click(function () {
            $("#InviteFriend").dialog("open");
            return false;
        });
    });
</script>
    <div id="InviteFriend">
        <% Html.RenderPartial("Invite_Friend"); %>
        <div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/1.png" alt="" />
                <label>
                    nanny</label>
            </div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/2.png" alt="" />
                <label>
                    Bua Kornkanok</label>
            </div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/3.png" alt="" />
                <label>
                    โอ่งเหลือง เห็ดม่อ</label>
            </div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/4.png" alt="" />
                <label>
                    This Lovestory</label>
            </div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/5.png" alt="" />
                <label>
                    Peemai Shr</label>
            </div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/7.png" alt="" />
                <label>
                    Miiwremy Pareerat</label>
            </div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/8.png" alt="" />
                <label>
                    Ma-ey Titapura</label>
            </div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/9.png" alt="" />
                <label>
                    Ojoyso Phonbun</label>
            </div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/10.png" alt="" />
                <label>
                    Suchada Suptawon</label>
            </div>
            <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                <img src="/Content/Profile/pic_friend/11.png" alt="" />
                <label>
                    Geann' Elf</label>
            </div>
        </div>    
        <div style="text-align: center;">
        <a href="#" style="text-decoration: none;">SeeMore...</a></div>
    </div>
