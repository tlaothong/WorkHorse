<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- submenu for friends--%>
    <div style="background-color: #dedfe1; width: 340px; padding-left: 285px;">
        <table style="margin-bottom: 10px;">
            <tr>
                <th style="background-color: White; border: 1px solid #afb0b3; padding-left: 5px;
                    padding-right: 5px;">
                    <a href="#">Profile</a>
                </th>
                <th style="background-color: White; border: 1px solid #afb0b3; padding-left: 5px;
                    padding-right: 5px;">
                    <a href="#">Photo</a>
                </th>
                <th style="background-color: White; border: 1px solid #afb0b3; padding-left: 5px;
                    padding-right: 5px;">
                    <a href="#">Blog</a>
                </th>
                <th style="background-color: White; border: 1px solid #afb0b3; padding-left: 5px;
                    padding-right: 5px;">
                    <a href="#">Achievements</a>
                </th>
                <th style="background-color: White; border: 1px solid #afb0b3; padding-left: 5px;
                    padding-right: 5px;">
                    <a href="#">Friend list</a>
                </th>
            </tr>
        </table>
    </div>
    <div class="picuser">
        <img src="/Content/images/picuser.png" alt="user" /></div>
    <%-- My Profile--%>
    <div style="float: left; padding-left: 50px;">
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
    </div>
    <div style="float: left; padding-left: 50px;">
        <img src="/Content/images/ProfileAvatar.png" alt="Avatar" /></div>
    <%-- Top Friends--%>
    <div class="friend">
        <div class="stylefriend">
            Friends</div>
        <div class="styleall">
            <a href="#">See All</a></div>
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
    <%-- Log events--%>
    <div class="logevent">
        <div class="stylefriend">
            Log Events</div>
        <div class="logeventall">
            <a href="#">See All</a></div>
        <table>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubMenu"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
    <% Html.RenderPartial("index_comment"); %>
</asp:Content>
