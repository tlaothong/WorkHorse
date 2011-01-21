<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.require(Sys.components.toggleButton, function () {
                $().toggleButton.defaults = {
                    CheckedImageUrl: "/Content/images/Unchecked_gray.gif",
                    UncheckedImageUrl: "/Content/images/checked.gif",
                    ImageWidth: 20,
                    ImageHeight: 20
                };
                $(".toggle1").toggleButton();
            });
            $(".bookmark").click(function () {
                $(this).slideUp();
            });
            $("#bookmark").hover(function () {
                $(this).addClass("hilite");
            }, function () {
                $(this).removeClass("hilite");
            });
        });  

    </script>
    <%--directory path--%>
    <div>
        <table>
            <tbody>
                <tr>
                    <td>
                        <a href="/Home">Game</a>
                    </td>
                    <td>
                        >
                    </td>
                    <td>
                        Game
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="padding-top: 10px">
        <% Html.RenderPartial("FilterGame"); %></div>
    <table>
        <tr>
            <td style="width: 150px;">
                <a href="/Game/Game/PlayGame">
                    <img src="../../../../Content/images/mayatakky.png" /></a>
            </td>
            <td>
                <div>
                    <h2>
                        MaYaTaKKY</h2>
                </div>
                <div>
                    เกมส์แนวมายา ที่ใครก็ไม่เคยเห็นที่ไหนในโลกมีที่นี่ที่เดียว
                </div>
                <div style="padding-top: 20px">
                    <div style="float: left; padding-right: 5px">
                        <input type="checkbox" class="toggle1" />
                    </div>
                    <div style="float: left; padding-right: 5px">
                        <label>
                            UnLike</label>
                    </div>
                    <div style="float: left; padding-right: 5px">
                        <button class="bookmark" type="button">
                            Bookmark</button>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubMenu"); %>
    <% Html.RenderPartial("Upload"); %>
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
