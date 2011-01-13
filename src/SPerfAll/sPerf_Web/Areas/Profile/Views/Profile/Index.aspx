<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%--script for edit profile dialog--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#showEditProfile").dialog({
            autoOpen: false,
            modal: true,
            width: 450,
            title: 'Edit Profile',
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Save": function () {
                    $(this).dialog("close");
                }
            }
        });

        // Dialog Link
        $('#editProfile').click(function () {
            $('#showEditProfile').dialog('open');
            return false;
        });
    });

</script>
<div id="showEditProfile">
    <table>
        <tr>
            <td style="float: left; margin-top:5px;">
                <table>
                    <tr>
                        <td><a href="#">All/None</a></td><td></td>
                    </tr>

                    <tr>
                        <td>Name :</td><td><input type="text" style="width:170px;"/></td>
                    </tr>
                    <tr>
                        <td>Email :</td><td><input type="text" style="width:170px;"/></td>
                    </tr>
                    <tr>
                        <td>Birtday :</td><td><input id="birthday" type="text" style="width:170px;"/></td>
                    </tr>
                    <tr>
                        <td>Gender :</td><td><select style="width:177px;"><option>Male</option><option>Female</option></select></td>
                    </tr>
                    <tr>
                        <td>Location :</td><td><select style="width:177px;"><option>Khon Kaen</option><option>BankKok</option></select></td>
                    </tr>
                    <tr>
                        <td>School :</td><td><input type="text" style="width:170px;"/></td>
                    </tr>
                </table>
            </td>
            <td>
                <div>
                    <table>
                            <tr>
                                <td  style="width:150px;"><input type="checkbox"/>Show</td>
                            </tr>
                            <tr>
                                <td><input type="checkbox"/>Show</td>
                            </tr>
                            <tr>
                                <td><input type="checkbox"/>Show</td>
                            </tr>
                            <tr>
                                <td><input type="checkbox" />Show</td>
                            </tr>
                            <tr>
                                <td><input type="checkbox" />Show</td>
                            </tr>
                            <tr>
                                <td><input type="checkbox"/>Show</td>
                            </tr>
                    
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>Log event :</td><td><input type="radio"/>Show all</td>
                    </tr>
                    <tr>
                        <td></td><td><input type="radio"/>Show only friend action</td>
                    </tr>
                    <tr>
                        <td></td><td><input type="radio"/>Show only self action</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>CanAccess :</td><td><input type="radio"/>All users</td>
                    </tr>
                    <tr>
                        <td></td><td><input type="radio"/>My friend only</td>
                    </tr>
                    <tr>
                        <td></td><td><input type="radio"/>Me only</td>
                    </tr>
                </table>
            </td>
        </tr>
                <tr>
            <td>
                <table>
                    <tr>
                        <td>Comment :</td><td><input type="radio"/>All users read only</td>
                    </tr>
                    <tr>
                        <td></td><td><input type="radio"/>All users can read & write</td>
                    </tr>
                    <tr>
                        <td></td><td><input type="radio"/>My friend read only</td>
                    </tr>
                    <tr>
                        <td></td><td><input type="radio"/>My friend can read & write</td>
                    </tr>
                    <tr>
                        <td></td><td><input type="radio"/>Only me can write</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<table>
    <tr>
        <td valign="top"><div class="picuser"><img src="/Content/images/picuser.png" alt="user" /></div></td>
        <td valign="top">
            <div style="float: left; padding-left: 50px; margin-top:0px;">
                <div>
                    Name: Dick Kapooook
                </div>
                <div>
                    Email: dickkap25@gmail.com
                </div>
                <div>
                    Birtday : 5-12-2527
                </div>
                <div>
                    Gender : Semi-Male
                </div>
                <div>
                    Location : Halem
                </div>
                <div>
                    School : Bare body University
                </div>
                <div>
                <br />
                   <label id="editProfile" style="border:1px solid Gray; background-color:#E7E8E9; padding:1px 1px 1px 1px;">Edit Profile</label>
                </div>
            </div>
         </td>
         <td valign="top"><div style="float: left; padding-left: 35px; margin-top:0px;"><img src="/Content/images/avartar_index.png" alt="Avatar" /></div></td>
    </tr>
</table>
    <%-- Top Friends--%>
    <div class="friend">
        <div class="stylefriend">
            Friends</div>
        <div class="styleall">
            <a href="#" id="seeallFriends">see all</a></div>
        <div class="friendall">
            <a href="#">
                <img src="/Content/images/f1.png" alt="" /><br />
                Nelson Lao </a><a href="#">
                    <img src="/Content/images/f2.png" alt="" /><br />
                    AumKrab</a> <a href="#">
                        <img src="/Content/images/f3.png" alt="" /><br />
                        Mayda Jui</a> <a href="#">
                            <img src="/Content/images/f4.png" alt="" /><br />
                            Koradon S.</a> <a href="#">
                                <img src="/Content/images/f1.png" alt="" /><br />
                                Nelson Lao</a> <a href="#">
                                    <img src="/Content/images/f2.png" alt="" /><br />
                                    AumKrab</a> <a href="#">
                                        <img src="/Content/images/f1.png" alt="" /><br />
                                        Nelson Lao</a> <a href="#">
                                            <img src="/Content/images/f3.png" alt="" /><br />
                                            Mayda Jui</a> <a href="#">
                                                <img src="/Content/images/f1.png" alt="" /><br />
                                                Nelson Lao</a> <a href="#">
                                                    <img src="/Content/images/f2.png" alt="" /><br />
                                                    AumKrab</a>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            // Dialog			
            $("#tabs").dialog({
                bgiframe: true,
                autoOpen: false,
                modal: true,
                width: 550,
                height: 550,
                buttons: {
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                }
            });
            // Dialog Link
            $("#seeallFriends").click(function () {
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
    <div id="tabs" title="แสดงเพื่อนทั้งหมด" style="padding-top: 20px;">
        <div>
            <ul>
                <li style="float: right;"><a href="#tabs-1">เพื่อนทั้งหมด</a></li>
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
        </div>
        <div id="tabs-3">
        </div>
        <div style="text-align: center;">
            <a href="#" style="text-decoration: none;">SeeMore...</a></div>
    </div>
</div>
    <%-- Log events--%>
    <div class="logevent">
        <div class="stylefriend">
            Log Events</div>
        <table style="margin-top:14px;">
            <tr class="logpostevent">
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e1.png" alt="" /><br />
                        Nelson lao</div>
                    <div class="eventdetail">
                        <p>
                            join to e-siam game with Gary shui and invite you to play try to play application
                            please click e-siam</p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e1.png" alt="" /><br />
                        Nelson lao</div>
                    <div class="eventdetail">
                        <p>
                            comment on your picture in office party folder see comment click,please</p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            เล่นเกมอพาร์ตเม้น สยองงงงงง!!! แป่วแว่วววว... ได้คะแนนโครตเยอะเพราะโกง มีหน้ากล้ามาท้าทายคุณอีก
                            อยากรู้ก็ลองเล่นดูสิว้า เล่นเกมอพาร์ตเม้นสยองง please click Scream Apartment
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            add AumKrab และ Patty jung เป็นเพื่อน
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            เล่นเกมอพาร์ตเม้น สยองงงงงง!!! แป่วแว่วววว... ได้คะแนนโครตเยอะเพราะโกง มีหน้ากล้ามาท้าทายคุณอีก
                            อยากรู้ก็ลองเล่นดูสิว้า เล่นเกมอพาร์ตเม้นสยองง please click Scream Apartment
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            add AumKrab และ Patty jung เป็นเพื่อน
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            เล่นเกมอพาร์ตเม้น สยองงงงงง!!! แป่วแว่วววว... ได้คะแนนโครตเยอะเพราะโกง มีหน้ากล้ามาท้าทายคุณอีก
                            อยากรู้ก็ลองเล่นดูสิว้า เล่นเกมอพาร์ตเม้นสยองง please click Scream Apartment
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            add AumKrab และ Patty jung เป็นเพื่อน
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            เล่นเกมอพาร์ตเม้น สยองงงงงง!!! แป่วแว่วววว... ได้คะแนนโครตเยอะเพราะโกง มีหน้ากล้ามาท้าทายคุณอีก
                            อยากรู้ก็ลองเล่นดูสิว้า เล่นเกมอพาร์ตเม้นสยองง please click Scream Apartment
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            add AumKrab และ Patty jung เป็นเพื่อน
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            เล่นเกมอพาร์ตเม้น สยองงงงงง!!! แป่วแว่วววว... ได้คะแนนโครตเยอะเพราะโกง มีหน้ากล้ามาท้าทายคุณอีก
                            อยากรู้ก็ลองเล่นดูสิว้า เล่นเกมอพาร์ตเม้นสยองง please click Scream Apartment
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            add AumKrab และ Patty jung เป็นเพื่อน
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            เล่นเกมอพาร์ตเม้น สยองงงงงง!!! แป่วแว่วววว... ได้คะแนนโครตเยอะเพราะโกง มีหน้ากล้ามาท้าทายคุณอีก
                            อยากรู้ก็ลองเล่นดูสิว้า เล่นเกมอพาร์ตเม้นสยองง please click Scream Apartment
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            add AumKrab และ Patty jung เป็นเพื่อน
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            เล่นเกมอพาร์ตเม้น สยองงงงงง!!! แป่วแว่วววว... ได้คะแนนโครตเยอะเพราะโกง มีหน้ากล้ามาท้าทายคุณอีก
                            อยากรู้ก็ลองเล่นดูสิว้า เล่นเกมอพาร์ตเม้นสยองง please click Scream Apartment
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            add AumKrab และ Patty jung เป็นเพื่อน
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            เล่นเกมอพาร์ตเม้น สยองงงงงง!!! แป่วแว่วววว... ได้คะแนนโครตเยอะเพราะโกง มีหน้ากล้ามาท้าทายคุณอีก
                            อยากรู้ก็ลองเล่นดูสิว้า เล่นเกมอพาร์ตเม้นสยองง please click Scream Apartment
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <p>
                            add AumKrab และ Patty jung เป็นเพื่อน
                        </p>
                    </div>
                </td>
            </tr>
        </table>
    </div>
     <% Html.RenderPartial("FriendList"); %>
     <% Html.RenderPartial("Inbox"); %>
     <% Html.RenderPartial("OptionProfile"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubMenu"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
    <% Html.RenderPartial("index_comment"); %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="startMenu" runat="server">
<% Html.RenderPartial("StartMenu"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="newsbar" runat="server">
<% Html.RenderPartial("newsBar"); %>
</asp:Content>
