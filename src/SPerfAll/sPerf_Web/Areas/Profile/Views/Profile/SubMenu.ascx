<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
   <div style="float: right; margin-right:-72px;">
    <table>
            <tr>
                <td>

                     <%=Html.ActionLink("Profile",MVC.Profile.Profile.Profile()) %>
                    
                </td>
            <td>
                <div class="commandPanels">
                    | <%=Html.ActionLink("Photo",MVC.Profile.Profile.Photo()) %>
                </div>
            </td>
            <td>
                <div id="blog">
                    | <%=Html.ActionLink("Blog",MVC.Profile.Profile.Blog()) %>
                </div>
            </td>
            <td>
                <div id="ardhievement">
                    | <%=Html.ActionLink("Archievement", MVC.Profile.Profile.Archievement())%>
                </div>
            </td>
            <td>
                <div id="friend">
                    | <%=Html.ActionLink("Friend",MVC.Profile.Profile.Friends()) %>
                </div>
            </td>
            <td>
                <div id="inbox">
                    | <%=Html.ActionLink("Inbox",MVC.Profile.Profile.Inbox()) %>
                </div>
            </td>
        </tr>
    </table>
</div>
