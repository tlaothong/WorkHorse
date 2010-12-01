<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    Sys.require(Sys.components.dropDown, function () {
        $("#dropSearch").dropDown({
            dropDownControl: Sys.get("#dropMenu")
        });
    });
</script>
<div>
    <div style="padding-left: 508px; float: left;">
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
    <div class="commandPanels" style="float: left;">
        |
        <%=Html.ActionLink("My Video",MVC.KnowledgeCenter.KnowledgeCenter.MyVideo()) %>
    </div>
    <div style="float: left;">
        | <a href="#" id="Popup">Post New Video</a>
    </div>
    <div style="float: left;">
        | <a href="#" id="Option_Click">Option</a>
    </div>
</div>
