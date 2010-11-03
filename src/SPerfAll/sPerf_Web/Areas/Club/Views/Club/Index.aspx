<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
        <button onclick="popupModal('profile.html',500,200);">Log Post</button>
        <script type="text/javascript">
            function popupModal(url, width, height) {
                var myDate = new Date();
                var setUniqe = myDate.getTime(); // ใช้สำหรับ ป้องกันการ cache กรณีกำลังทดสอบ   
                var diaxFeature = "dialogWidth:" + width + "px;"
        + "dialogHeight:" + height + "px;"
                /*  +"dialogLeft:"+width+"px;"  
                +"dialogTop:"+width+"px;"       */
            + "center:yes;"
            + "edge:raised;" // sunken | raised    
            + "resizable:no;"
            + "status:no;"
            + "scroll:no;";
                window.showModalDialog(url + "?" + setUniqe, "", diaxFeature);
                // กรณีไม่ใช้ setUniqe   
                //  window.showModalDialog(url,"", diaxFeature);    
            }   
        </script> 
    </div>
<%--script for load content from db--%>
<script type="text/javascript">
    $(document).ready(function () {
        $("#myClub").load("club.html");
    });
</script>
<div id="myClub"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
<% Html.RenderPartial("SubMenu"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
<% Html.RenderPartial("AdvanceSearch"); %>
<% Html.RenderPartial("Banners"); %>
</asp:Content>