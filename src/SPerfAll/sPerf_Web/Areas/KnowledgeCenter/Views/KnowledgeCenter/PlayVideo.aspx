<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PlayVideo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(".readmore").click(function () {
            $(this).slideUp();
        });
    </script>
        <%--directory path--%>
    <table>
        <tbody>
            <tr>
                <td>
                    <a href="/Home">Home</a>
                </td>
                <td>
                    >
                </td>
                <td>
                    <a href="/KnowledgeCenter">Video</a>
                </td>
                <td>
                    >
                </td>
                <td>
                    PlayVideo
                </td>
            </tr>
        </tbody>
    </table>
    <div style="padding-top: 10px;">
        <div style="float: left; margin-left: 20px;">
            <label>
                ID: 1234567</label>
            <label>
                BasicMath</label>
            <label>
                (Math/Calculus)</label>
        </div>
        <div style="float: left">
            <div style="float: left; margin-left: 80px;">
                <select>
                    <option>My Bookmark</option>
                    <option>Math</option>
                </select>
            </div>
            <div class="bookmark" style="float: left; margin-top: -2px; margin-left: 20px;">
                <input type="button" value="Bookmark" />
            </div>
            <div style="float: right; margin-top: -2px; margin-left: 20px;">
                <input id="ReportProblem_Click" type="button" value="Report" />
            </div>
        </div>
    </div>
    <div style="background-color: Gray; width: 580px; height: 450px; position: relative;
        margin-top: 25px; margin-left: 20px;">
        <%--Silverlight--%>
                <div class="media">
            <object codebase="http://www.apple.com/qtactivex/qtplugin.cab" classid="clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6"
                type="application/x-oleobject" width="580" height="450">
                <param name="url" value="/uploads/TheS.wmv" />
                <embed src="TheS.wmv" type="application/x-mplayer2" pluginspage="http://www.microsoft.com/Windows/MediaPlayer/"></embed>
            </object>
        </div>
        <%--end--%>
    </div>
    <div style="margin-left: 20px; margin-top: 10px;">
        <div style="float: left;">
            <label>
                Views 25,000</label>
        </div>
        <div style="float: left; margin-left: 100px;">
            <a href="#">Download</a>
        </div>
        <div style="float: left; margin-left: 20px; margin-top: -2px">
            <input id="InviteFriend_Click" type="button" value="Invite friends" />
        </div>
    </div>
    <div style="float: right; padding-right: 25px">
        <a href="#">TheS</a></div>
    <div style="float: right; clear: both; padding-right: 25px;">
        <div class="slide readmore">
            <a href="#">Read more..</a></div>
        <div class="view" style="display: none; background-color: Gray; width: 580px;
            color: White;">
            Text, text, text...</div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            // Hide the "view" div.
            $('div.view').hide();
            // Watch for clicks on the "slide" link.
            $('div.slide').click(function () {
                // When clicked, toggle the "view" div.
                $('div.view').slideToggle(100);
                return false;
            });
        });
    </script>
    <% Html.RenderPartial("ReportProblemVideo"); %>
    <% Html.RenderPartial("Invite_Friend"); %>
    <% Html.RenderPartial("PostNewVideos"); %>
    <% Html.RenderPartial("Option"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubmenuVideo"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
    <% Html.RenderPartial("NewCommentVideo"); %>
    <% Html.RenderPartial("CommentVideo"); %>
    <% Html.RenderPartial("ReportCommentVideo"); %>
</asp:Content>
