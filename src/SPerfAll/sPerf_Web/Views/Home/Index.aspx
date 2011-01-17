<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ศูนย์การเรียนรู้
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table>
    <tr>
        <td><% Html.RenderPartial("Cartoon"); %></td>
    </tr>
</table>
<br />
<br />
<div class="today">
    <div style="margin-top:2px;"><img src="/Content/images/calendar.png" />Todays <script type="text/javascript">
                   var d = new Date();
                       document.write(d.getDate(), "/", d.getMonth(), "/", d.getYear());
</script></div> 
    <table style="margin-top:12px;">
       <tr>
            <div><td><img src="/Content/profile/pic_friend/1.png" /></td><td valign="top">Tao's Birthday</td></div>
            
        </tr>
    </table>
    <div>วันเกิดเต๋า : เพื่อนของคุณ</div>
    <div>เขียนคำอวยพรส่งของขวัญให้เต๋า </div>
    <table style="margin-top:12px;">
       <tr>
            <div><td><img src="/Content/profile/pic_friend/2.png" /></td><td valign="top">Tao's Birthday</td></div>
            
        </tr>
    </table>
    <div>วันเกิดเต๋า : เพื่อนของคุณ</div>
    <div>เขียนคำอวยพรส่งของขวัญให้เต๋า </div>
    <table style="margin-top:12px;">
       <tr>
            <div><td><img src="/Content/profile/pic_friend/3.png" /></td><td valign="top">Tao's Birthday</td></div>
            
        </tr>
    </table>
    <div>วันเกิดเต๋า : เพื่อนของคุณ</div>
    <div>เขียนคำอวยพรส่งของขวัญให้เต๋า </div>
    <table style="margin-top:12px;">
       <tr>
            <div><td><img src="/Content/profile/pic_friend/4.png" /></td><td valign="top">Tao's Birthday</td></div>
            
        </tr>
    </table>
    <div>วันเกิดเต๋า : เพื่อนของคุณ</div>
    <div>เขียนคำอวยพรส่งของขวัญให้เต๋า </div>
</div>
<div class="logevent">
        <div class="stylefriend">
            Log Events</div>
        <table style="margin-top:5px;">
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
<% Html.RenderPartial("AdvanceSearch"); %>
<% Html.RenderPartial("Banners"); %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="startMenu" runat="server">
<% Html.RenderPartial("StartMenu"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="newsbar" runat="server">
<% Html.RenderPartial("newsBar"); %>
</asp:Content>


