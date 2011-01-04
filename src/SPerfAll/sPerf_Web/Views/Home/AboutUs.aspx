<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AboutUs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
    บริษัทดิเอส จำกัด 919/2 หมู่ 27 ตำบลศิลา อำเภอเมือง จังหวัดขอนแก่น 40000<br />
    มีพนักงานทั้งหมด 14 คนดังนี้

</div>
<br />
<br />
<br />
<div class="aboutUs">
        <div class="stylefriend">
            TheS Starf</div>
        <table style="margin-top:20px;">
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/TheS_logo_final.png" alt="" /><br />
                        Nelson lao</div>
                    <div class="aboutDetail">
                        <p>
                            comment on your picture in office party folder see comment click,please</p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/TheS_logo_final.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="aboutDetail">
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
                        <img src="/Content/images/TheS_logo_final.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="aboutDetail">
                        <p>
                            add AumKrab และ Patty jung เป็นเพื่อน
                        </p>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/TheS_logo_final.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="aboutDetail">
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
                        <img src="/Content/images/TheS_logo_final.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="aboutDetail">
                        <p>
                            เล่นเกมอพาร์ตเม้น สยองงงงงง!!! แป่วแว่วววว... ได้คะแนนโครตเยอะเพราะโกง มีหน้ากล้ามาท้าทายคุณอีก
                            อยากรู้ก็ลองเล่นดูสิว้า เล่นเกมอพาร์ตเม้นสยองง please click Scream Apartment
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

