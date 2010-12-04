<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	editors
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../../../Content/jquery.cleditor.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../../Scripts/jquery.cleditor.min.js"></script>
     <script type="text/javascript">
         $(function () {
             $("#editorClick").click(function(){
                 $("#input").cleditor({ width: 500, height: 180, useCSS: true })[0].focus();
             });
         });
    </script>
<div id="editorClick">
     <h3 class="noTopMargin">
     <textarea id="input" name="input">Go ahead, take it for a test drive. Highlight some text and click some buttons.</textarea>
     </h3>
 
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
</asp:Content>
