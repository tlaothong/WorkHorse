<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%--script for load content from db--%>
<script type="text/javascript">
    $(document).ready(function () {
        $("#AvarComment").load("Acomment.html");
    });
</script>
<div id="AvarComment"></div> 
