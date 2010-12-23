<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
     <script type="text/javascript">
         $(function () {
             // Dialog			
             $("#tab").dialog({
                 bgiframe: true,
                 autoOpen: false,
                 modal: true,
                 width: 500,
                 height: 500
             });
             // Dialog Link
             $("#FriendList").click(function () {
                 $("#tab").dialog("open");
                 return false;
             });
         });
</script>
<script type="text/javascript">
    $(function () {
        $("#tab").tabs();
    });
  </script>

<div class="demo">
    <div id="tab" title="Message InBox" style="padding-top: 5px;">
        <div>
            <ul>                      <li><a href="#inbox"><span>Inbox</span></a></li>
                     <li><a href="#outbox"><span>Outbox</span></a></li>
                     <li><a href="#compose"><span>Compose</span></a></li>

                    <li><a href="#option"><span>Option</span></a></li>
            </ul>
        </div>
        <div id="inbox">
            <div id="r">
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
                </div>
            </div>
        </div>
        <div id="outbox">
            <div id="e">
 <div>
                    <div style="padding-bottom: 10px;">
                        <% Html.RenderPartial("Filter"); %></div>

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
        <div id="compose">
            <div id="v">
                <table>
                    <tr>
                         <td>
                         Friend : <select><option>สุดหล่อ</option><option>สุดสวย</option><option>สุดน่ารัก</option></select>
                         </td>
                    </tr>
                    <tr>
                         <td>
                         Topic : <input type="text" style="width:380px;"/>
                         </td>
                    </tr>
                    <tr>
                         <td>
                         <textarea rows="10" cols="76" style="margin-left:42px; overflow:hidden;"></textarea>
                         </td>
                    </tr>
                    <tr>
                         <td>
                            <input type="checkbox" />save to outbox<label id="sendMsg" style="color:Green; margin-left:350px;">Send</label>|<label id="cancelMsg" style="color:Red;">Cancel</label>
                         </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="option">
            <div id="a">
                <table>
                    <tr>
                         <td>
                            <div>Who can access :</div>
                            <div><input type="radio" />All users</div>
                            <div><input type="radio" />My friend only</div>
                            <div><input type="radio" />Me only</div>
                         </td>
                    </tr>
                    <tr>
                         <td>
                            <div>Comment :</div>
                            <div><input type="radio" />All users read only</div>
                            <div><input type="radio" />All users can read & write</div>
                            <div><input type="radio" />My friend read only</div>
                            <div><input type="radio" />My friend can read & write</div>
                            <div><input type="radio" />Only me can write</div>
                         </td>
                    </tr>
                    <tr>
                         <td>
                            <div>Notification :</div>
                            <div><input type="radio" />All</div>
                            <div><input type="radio" />Only self related</div>
                         </td>
                    </tr>
                    <tr>
                         <td>
                            <label id="Label1" style="color:Green; margin-left:350px;">Save</label>|<label id="Label2" style="color:Red;">Cancel</label>
                         </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
