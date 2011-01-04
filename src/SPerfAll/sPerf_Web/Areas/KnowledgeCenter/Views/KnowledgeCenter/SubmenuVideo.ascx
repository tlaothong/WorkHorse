<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    Sys.require(Sys.components.dropDown, function () {
        $("#dropSearch").dropDown({
            dropDownControl: Sys.get("#dropMenu")
        });
    });
</script>
<div style="float: left; display: block; text-decoration: none;">
    <div style="padding-left: 500px; float: left">
        <div>
            <span id="dropCategory_dropWrapper" style="cursor: default;"><span id="dropSearch"
                style="display: block; width: 150px; height: 18px; background-color: transparent;">
                All</span> </span>
            <div id="dropMenu" class="ContextMenuPanel" style="visibility: hidden; display: none;
                width: 148px;">
                <a href="">วีดีโอ</a> <a href="">อัดวีดีโอ</a> <a href="">สไลด์</a>
            </div>
        </div>
    </div>
    <div class="commandPanels" style="float: left; padding-right: 3px">
        |
        <%=Html.ActionLink("My Video",MVC.KnowledgeCenter.KnowledgeCenter.MyVideo()) %>
    </div>
    <div id="Popup" style="float: left; padding-right: 3px">
        | <a href="#">Post New Video</a>
    </div>
    <div id="Option_Click" style="float: left; padding-right: 3px">
        | <a href="#">Option</a>
    </div>
</div>
