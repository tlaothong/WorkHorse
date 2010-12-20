<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    Sys.require(Sys.components.dropDown, function () {
        $("#dropSearch").dropDown({
            dropDownControl: Sys.get("#dropMenu")
        });
    });
</script>

<div style="float: left; padding-left: 5px; display: block;">
    <table>
           <tr>
               <td>
                    <div style="padding-left: 490px; float: left;">
                        <div>
                            <span id="dropCategory_dropWrapper" style="cursor: default;"><span id="dropSearch"
                                style="display: block; width: 150px; height: 18px; background-color: transparent;">All</span>
                            </span>
                            <div id="dropMenu" class="ContextMenuPanel" style="visibility: hidden; display: none;
                                width: 148px;">
                                <a href="">วีดีโอ</a> <a href="">อัดวีดีโอ</a> <a href="">สไลด์</a>
                            </div>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="commandPanels">
                        | <%=Html.ActionLink("My Video",MVC.KnowledgeCenter.KnowledgeCenter.MyVideo()) %>
                    </div>
                </td>
                <td>
                    <div id="Popup">
                        | <a href="#">Post New Video</a>
                    </div>
                </td>
                <td>
                    <div id="Option_Click">
                        | <a href="#">Option</a>
                    </div>
                </td>
            </tr>
    </table>
</div>
