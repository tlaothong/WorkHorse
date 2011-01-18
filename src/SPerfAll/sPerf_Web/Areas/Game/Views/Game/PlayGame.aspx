<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PlayGame
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(".readmore").click(function () {
            $(this).slideUp();
        });
    </script>
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
    <div style="padding-top: 10px; z-index: 100;">
        <div style="float: left; margin-left: 20px;">
            <label>
                ID: 1234567</label>
            <label>
                BasicMath</label>
            <label>
                Action</label>
        </div>
        <div style="float: left">
            <div style="float: left; margin-left: 10px;">
                <select>
                    <option>Country Story</option>
                    <option>Happy Pig</option>
                </select>
            </div>
            <div style="float: left; margin-left: 10px; margin-top: -2px">
                <input id="InviteFriend_Click" type="button" value="Invite friends" />
            </div>
            <div class="bookmark" style="float: left; margin-top: -2px; margin-left: 10px;">
                <input type="button" value="Add Bookmark" />
            </div>
            <div style="float: right; margin-top: -2px; margin-left: 10px;">
                <input id="ReportProblem_Click" type="button" value="Report" />
            </div>
        </div>
    </div>
    <div style="width: 600px; height: 500px; left: -65px; position: relative;">
        <%--Silverlight--%>
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="740" height= "580" >
            <param name="source" value="/xap/TheS.SperfGames.MayaTukky.xap" />
            <param name="onerror" value="onSilverlightError" />
            <param name="minRuntimeVersion" value="2.0.31005.0" />
            <param name="autoUpgrade" value="true" />
            <a href="http://go.microsoft.com/fwlink/?LinkID=124807" style="text-decoration: none;">
                <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight"
                    style="border-style: none" />
            </a>
        </object>
        <%--end--%>
    </div>
    <div style="padding-bottom: 20px">
        <div style="margin-left: 20px; margin-top: 10px;">
            <div style="float: left;">
                <label>
                    Views 25,000</label>
            </div>
            <div style="float: left; margin-left: 480px">
                <a href="#">TheS</a></div>
        </div>
        <div style="float: left; margin-left: 530px;">
            <div class="slide readmore">
                <a href="#">Read more..</a></div>
        </div>
        <div class="view" style="display: none; background-color: Gray; width: 575px; color: White;
            clear: both; margin-left: 20px;">
            Text, text, text...</div>
    </div>
    <% Html.RenderPartial("ReportProblemGame"); %>
    <% Html.RenderPartial("Invite_Friend"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubMenu"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
    <% Html.RenderPartial("NewCommentGame"); %>
    <% Html.RenderPartial("CommentGame"); %>
    <% Html.RenderPartial("ReportCommentGame"); %>
</asp:Content>
