<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    Sys.require(Sys.components.dropDown, function () {
        $("#dropScholarshipSearch").dropDown({
            dropDownControl: Sys.get("#dropScholarshipMenu")
        });
    });
</script>

<div style="float: left; padding-left: 5px; display: block;">
    <table>
           <tr>
               <td>
                    <div style="padding-left: 510px; float: left;">
                        <div>
                            <span id="dropCategory_dropWrapper" style="cursor: default;"><span id="dropScholarshipSearch"
                                style="display: block; width: 150px; height: 18px; background-color: transparent;">All</span>
                            </span>
                            <div id="dropScholarshipMenu" class="ContextMenuPanel" style="visibility: hidden; display: none;
                                width: 148px;">
                                <a href="">ขอนแก่น</a> <a href="">ศรีษะเกษ</a> <a href="">อุดรธานี</a>
                            </div>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="recieved">
                        | <%=Html.ActionLink("Recieved",MVC.Scholarship.Scholarship.Recieved()) %>
                    </div>
                </td>
                <td>
                    <div id="tournamentSc">
                        | <%=Html.ActionLink("Tournament",MVC.Scholarship.Scholarship.Tournament()) %>
                    </div>
                </td>
                <td>
                    <div id="donate">
                        | <%=Html.ActionLink("Donate",MVC.Scholarship.Scholarship.Donate()) %>
                    </div>
                </td>
                <td>
                    <div id="option">
                        | <%=Html.ActionLink("Option",MVC.Scholarship.Scholarship.Option()) %>
                    </div>
                </td>
            </tr>
    </table>
</div>
