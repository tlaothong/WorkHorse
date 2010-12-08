<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PlayVideo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
    <div style="padding-top: 10px;">
        <div style="float: left; margin-left: 20px;">
            <label>ID: 1234567</label>
            <label>BasicMath</label>
            <label>(Math/Calculus)</label>
        </div>
        <div style="float:left">
            <div style="float: left; margin-left: 80px;">
                <select>
                    <option>My Bookmark</option>
                    <option>Math</option>
                </select>
            </div>
            <div style="float: left; margin-top: -2px; margin-left: 20px;">
                <input type="button" value="Bookmark" />
            </div>
            <div style="float: right; margin-top: -2px; margin-left: 20px;">
                <input id="ReportProblem_Click" type="button" value="Report" />
            </div>
        </div>
    </div>
    <div style="background-color: Gray; width: 580px; height: 300px; position: relative; margin-top: 25px; margin-left: 20px;"></div>
    <div style=" margin-left: 20px; margin-top: 10px; ">
        <div style="float: left;">
            <label>Views  25,000</label>
        </div>
        <div style="float: left; margin-left: 100px;">
            <a href="#">Download</a>
        </div>
        <div style="float: left; margin-left: 20px; margin-top: -2px">
            <input id="InviteFriend_Click" type="button" value="Invite friends" />
        </div>
    </div>
    <div style=" float: right; padding-right: 20px"><a href="#">TheS</a></div>
    <div style=" float: right; clear:right; padding-right: 20px;"><a href="#">Read more..</a></div>
    <% Html.RenderPartial("ReportProblemVideo"); %>
    <% Html.RenderPartial("Invite_Friend"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubmenuVideo"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
    <% Html.RenderPartial("NewCommentVideo"); %>
    <% Html.RenderPartial("CommentVideo"); %>
</asp:Content>
