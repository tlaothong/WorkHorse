<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%--<script type="text/javascript">
    Sys.require(Sys.components.dropDown, function () {
        $("#dropSearchGame").dropDown({
            dropDownControl: Sys.get("#dropMenuGame")
        });
    });
</script>
<div>
     <div>
     <a href="#"><label>Advance Search</label></a>
        <span id="dropCategory_dropWrapper" style="cursor: default;"><span id="dropSearchGame"
            style="display: block; width: 150px; height: 18px; background-color: transparent; font-size:small">ค้นหา</span>
        </span>
        <div id="dropMenuGame" class="ContextMenuPanel" style="visibility: hidden; display: none;
            width: 148px;">
          <%= Ajax.ActionLink("Name", "SearchByName","SearchSlot", new { area = "Web" }, new AjaxOptions { HttpMethod = "GET", UpdateTargetId = "search" })%>
          <%= Ajax.ActionLink("ID", "SearchByID", "SearchSlot", new { area = "Web" }, new AjaxOptions { HttpMethod = "GET", UpdateTargetId = "search" })%>

        </div>
        <form action="/KnowledgeCenter/SearchSlot/SearchByName" method="post">
             <table>
                <tr>
                    <td>
                           <input id="SearchText" name="SearchText" type="text" value=""  style="width:110px;"/>
                           <input id="SearchValue" name="SearchValue" type="hidden" value=""/>
                           &nbsp;&nbsp;&nbsp;<img  id ="stylesubmit" src="/Content/images/searchbutton.png"/>                
                   </td>
                </tr>
                <tr>
                    <td>
                        <div id="checkbox">
                            <input id="WithinResult" name="WithinResult" type="checkbox" value="true"/><input name="WithinResult" type="hidden" value="false" /><label>Within result</label>
                        </div>
                    </td>
                </tr>
             </table>
            </form>
    </div>
             
</div>--%>
