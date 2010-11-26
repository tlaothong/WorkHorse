<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<script type="text/javascript">
    $(function () {
        // Dialog			
        $("#tabs").dialog({
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
        $("#FriendList").click(function () {
            $("#tabs").dialog("open");
            return false;
        });
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#tabs").tabs();
    });
</script>
<div class="demo">
    <div id="tabs" title="FriendList" style="padding-top: 20px;">
        <div>
            <ul>
                <li style="float: right;"><a href="#tabs-3">Suggest</a></li>
                <li style="float: right;"><a href="#tabs-2">Request</a></li>
                <li style="float: right;"><a href="#tabs-1">FriendList</a></li>
            </ul>
        </div>
        <div id="tabs-1">
            <div id="FriendList">
                <div>
                    <div style="padding-bottom: 10px;">
                        <% Html.RenderPartial("Filter"); %></div>
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
            </div>
        </div>
        <div id="tabs-2">
            <div id="request">
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
            </div>
        </div>
        <div id="tabs-3">
            <div id="suggest">
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
            </div>
        </div>
        <div style="text-align: center;">
            <a href="#" style="text-decoration: none;">SeeMore...</a></div>
    </div>
</div>
