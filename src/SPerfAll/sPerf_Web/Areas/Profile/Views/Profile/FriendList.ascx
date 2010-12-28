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
    <div id="tab" title="Friends List" style="padding-top: 5px;">
        <div>
            <ul>     
                     <li><a href="#FriendsLists"><span>Friends List</span></a></li>
                     <li><a href="#request"><span>Request</span></a></li>
                     <li><a href="#suggest"><span>Suggest</span></a></li>
            </ul>
        </div>
        <div id="FriendsLists">
            <div id="FriendDetail">
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
        <div id="request">
            <div id="requestDetail">
             <div>
                    <div style="padding-bottom: 10px;">
                        <% Html.RenderPartial("Filter"); %></div>
                    <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                        <img src="/Content/Profile/pic_friend/2.png" alt="" />
                        <label>
                            Bua Kornkanok</label>
                    </div>
                    <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                        <img src="/Content/Profile/pic_friend/1.png" alt="" />
                        <label>
                            nanny</label>
                    </div>
                    <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                        <img src="/Content/Profile/pic_friend/4.png" alt="" />
                        <label>
                            This Lovestory</label>
                    </div>

                    <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                        <img src="/Content/Profile/pic_friend/3.png" alt="" />
                        <label>
                            โอ่งเหลือง เห็ดม่อ</label>
                    </div>
                    <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                        <img src="/Content/Profile/pic_friend/5.png" alt="" />
                        <label>
                            Peemai Shr</label>
                    </div>
                </div>
            </div>
        </div>
        <div id="suggest">
            <div id="suggestDetail">
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
                        <img src="/Content/Profile/pic_friend/4.png" alt="" />
                        <label>
                            This Lovestory</label>
                    </div>                    
                    <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                        <img src="/Content/Profile/pic_friend/3.png" alt="" />
                        <label>
                            โอ่งเหลือง เห็ดม่อ</label>
                    </div>

                    <div style="padding-top: 5px; margin-bottom: 5px; width: 430px; border-top: 1px solid gray;">
                        <img src="/Content/Profile/pic_friend/5.png" alt="" />
                        <label>
                            Peemai Shr</label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
