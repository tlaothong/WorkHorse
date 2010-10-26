<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    Sys.require(Sys.components.dropDown, function () {
        $("#dropClubSearch").dropDown({
            dropDownControl: Sys.get("#dropClubMenu")
        });
    });
</script>

<div style="float: left; padding-left: 5px; display: block;">
    <table>
           <tr>
               <td>
                    <div style="padding-left: 510px; float: left;">
                        <div>
                            <span id="dropCategory_dropWrapper" style="cursor: default;"><span id="dropClubSearch"
                                style="display: block; width: 150px; height: 18px; background-color: transparent;">All</span>
                            </span>
                            <div id="dropClubMenu" class="ContextMenuPanel" style="visibility: hidden; display: none;
                                width: 148px;">
                                <a href="">All</a> <a href="">General</a> <a href="">Music</a> <a href="">Cartoon</a> <a href="">Pet</a>
                            </div>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="commandPanels">
                        | <%=Html.ActionLink("New Club",MVC.Club.Club.NewClub()) %>
                    </div>
                </td>
                <td>
                    <div id="OptionClick">
                        | <%=Html.ActionLink("Option",MVC.Club.Club.OptionClub()) %>
                    </div>
                </td>
            </tr>
    </table>
</div>
