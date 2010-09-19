<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	JsTreeView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jsTree/jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/jsTree/jquery.jstree.js" type="text/javascript"></script>

    <h2>JsTreeView</h2>

    <button type="button" id="add" >Add</button>
    <button type="button" id="des" >Deselect</button>
    <button type="button" id="get" >Get selected</button>

    <div id="treeV">
        <ul>
            <li><a href="#">One</a></li>
            <li>
                <a href="#">Two</a>
                <ul>
                    <li><a href="#">A</a></li>
                    <li><a href="#">B</a></li>
                    <li><a href="#">C</a></li>
                </ul>
            </li>
            <li><a href="#">Three</a></li>
        </ul>
    </div>

    <script type="text/javascript">
        $(function () {
            $("#treeV").jstree({
                "ui": {
                    "select_limit": 1
                },
                "themes": {
                    "theme": "apple"
                },
                "plugins": ["themes", "html_data", "ui", "crrm"]
            });
            $("#add").click(function () {
                $("#treeV").jstree("create", null, null, "Hello", function (x) { alert(x); }, true);
            });
            $("#des").click(function () {
                $("#treeV").jstree("deselect_all");
            });
            $("#get").click(function () {
                alert($("#treeV").jstree("get_selected").text());
            });
        });
    </script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
