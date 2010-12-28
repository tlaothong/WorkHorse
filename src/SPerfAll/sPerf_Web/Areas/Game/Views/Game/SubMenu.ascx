<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    Sys.require(Sys.components.dropDown, function () {
        $("#dropGameSearch").dropDown({
            dropDownControl: Sys.get("#dropGameMenu")
        });
    });
</script>

<div style="float: left; padding-left: 5px; display: block;">
    <table>
           <tr>
               <td>
                    <div style="padding-left: 515px; float: left;">
                        <div>
                            <span id="dropCategory_dropWrapper" style="cursor: default;"><span id="dropGameSearch"
                                style="display: block; width: 150px; height: 18px; background-color: transparent;">All</span>
                            </span>
                            <div id="dropGameMenu" class="ContextMenuPanel" style="visibility: hidden; display: none;
                                width: 148px;">
                                <a href="">All</a> <%=Html.ActionLink("Bookmark",MVC.Game.Game.Bookmark()) %> <a href="">Action</a> <a href="">Adventure</a> <a href="">Shooting</a>
                            </div>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="commandPanels">
                        | <%=Html.ActionLink("Tournament",MVC.Game.Game.Tournament()) %>
                    </div>
                </td>
                <td>
                    <div id="Upload_Click">
                        | <a href="#">Upload</a>
                    </div>
                </td>
                <td>
                    <div id="OptionClick">
                        | <%=Html.ActionLink("Option",MVC.Game.Game.GameOption()) %>
                    </div>
                </td>
            </tr>
    </table>
</div>

