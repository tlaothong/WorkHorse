<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div style="float: right; margin-right: 160px;">
    <table>
        <tr>
            <td>
                <div class="linkSub">
                    <%=Html.ActionLink("Profile",MVC.Profile.Profile.Profile()) %>
                </div>
            </td>
            <td>
                <div class="commandPanels">
                    |
                    <%=Html.ActionLink("Photo",MVC.Profile.Profile.Photo()) %>
                </div>
            </td>
            <td>
                <div id="blog">
                    |
                    <%=Html.ActionLink("Blog",MVC.Profile.Profile.Blog()) %>
                </div>
            </td>
            <td>
                <div id="ardhievement">
                    |
                    <%=Html.ActionLink("Archievement", MVC.Profile.Profile.Archievement_Last())%>
                </div>
            </td>
            <td>
                <div class="linkSub">
                    | <a href="#" id="FriendList">Friend List</a>
                </div>
            </td>
            <td>
                <div class="linkSub">
                    | <a href="#" id="Message">Inbox</a>
                </div>
            </td>
            <td>
                <div class="linkSub">
                    | <a href="#" id="optionProfiles">Option</a>
                </div>
            </td>
        </tr>
    </table>
</div>
