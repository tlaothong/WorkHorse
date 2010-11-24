<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
   <div style="float: right; margin-right:-72px;">
    <table>
            <tr>
                <td>

                    | <%=Html.ActionLink("HightLight",MVC.Home.HightLight()) %>
                    
                </td>
            <td>
                <div class="commandPanels">
                    | <%=Html.ActionLink("FAQ & Tutorial",MVC.Home.FAQTutorial()) %>
                </div>
            </td>
            <td>
                <div id="Popup">
                    | <%=Html.ActionLink("About Us",MVC.Home.AboutUs()) %>
                </div>
            </td>
            <td>
                <div id="OptionClick">
                    | <%=Html.ActionLink("Option",MVC.Home.Option()) %>
                </div>
            </td>
        </tr>
    </table>
</div>