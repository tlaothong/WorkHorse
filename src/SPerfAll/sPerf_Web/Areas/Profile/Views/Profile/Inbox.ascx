<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
    <script type="text/javascript">
        $(function () {
            // Dialog			
            $("#tabInbox").dialog({
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
            $("#Message").click(function () {
                $("#tabInbox").dialog("open");
                return false;
            });
        });
</script>
<script type="text/javascript">
    $(function () {
        $("#tabInbox").tabs();
    });
  </script>

<div class="MsgInbox">
    <div id="tabInbox" title="Message InBox" style="padding-top: 5px;">
        <div>
            <ul>
                    <li><a href="#fragment-compose"><span>Compose</span></a></li>
                    <li><a href="#fragment-inbox"><span>Inbox</span></a></li>
                    <li><a href="#fragment-option"><span>Option</span></a></li>
            </ul>
        </div>
        <div id="fragment-compose">
            <div id="Compose">
                <%--<div>
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
                </div>--%>
                รอการออกแบบจากพี่พาย และนำข้อมูลใส่  1
            </div>
        </div>
        <div id="fragment-inbox">
            <div id="Inbox">
                <%--<div>
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
                </div>--%>
                รอการออกแบบจากพี่พาย และนำข้อมูลใส่  2
            </div>
        </div>
        <div id="fragment-option">
            <div id="OptionInbox">
                <%--<div>
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
                </div>--%>
                รอการออกแบบจากพี่พาย และนำข้อมูลใส่  3
            </div>
        </div>
        <div style="text-align: center;">
            <a href="#" style="text-decoration: none;">SeeMore...</a></div>
    </div>
</div>
