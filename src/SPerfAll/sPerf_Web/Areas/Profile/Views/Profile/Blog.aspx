<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Blog
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<link href="../../../../Content/Calendar.css" rel="stylesheet" type="text/css" />
<link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
<link href="../../../../Content/jquery.cleditor.css" rel="stylesheet" type="text/css" />
<script src="../../../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
<script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../../../../Scripts/jquery.cleditor.min.js"></script>

<script type="text/javascript">  
        Sys.debug = true;   
       Sys.require(Sys.components.calendar, function() {   
            $("#bdate").calendar({});   
        });   
</script>  

<script type="text/javascript">
         $(document).ready(function () {
             $(".input").cleditor({ width: 500, height: 180, useCSS: true })[0].focus();
         });
</script>
<script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-18352523-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
</script>

<%--script for report--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#showReport").dialog({
            autoOpen: false,
            modal: true,
            width: 450,
            title: 'Report Problem',
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Send": function () {
                    $(this).dialog("close");
                }
            }
        });

        // Dialog Link
        $('.reportBlogpage').click(function () {
            $('#showReport').dialog('open');
            return false;
        });
    });

</script>

<%--script for new Blog--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#newblog_dialog").dialog({
            autoOpen: false,
            modal: true,
            width: 550,
            title: 'New Blog',
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Ok": function () {
                    $(this).dialog("close");
                }
            }
        });

        // Dialog Link
        $('#newblog').click(function () {
            $('#newblog_dialog').dialog('open');
            return false;
        });
    });

</script>

<%--script for edit Blog--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#editblog_dialog").dialog({
            autoOpen: false,
            modal: true,
            width: 550,
            title: 'Edit Blog',
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Send": function () {
                    $(this).dialog("close");
                }
            }
        });

        // Dialog Link
        $('#editblog').click(function () {
            $('#editblog_dialog').dialog('open');
            return false;
        });
    });

</script>
    <%--directory path--%>
    <div style="background-color:#DEDFE1;">
    <table >
        <tbody>
            <tr>
                <td><a href="/Home">Home</a></td>
                <td>></td>
                <td>Blog</td>
            </tr>
        </tbody>
    </table>
   </div>
<div style="background-color:#DEDFE1">
    <table style="margin-left:29px;"><tr><td>Dick Kapooooook's Blog <br /><label class="reportBlogpage" style="text-decoration:underline; color:#69BA55;">Report</label></td><td ><div class="demo"style="margin-left:247px;">
        Date : <input type="text" id="bdate" />  </td></tr>
    </table>
</div>

<%--div for report dialog--%>
<div id="showReport">
<table>
        <tr>
            <td valign="top">
                <img src="/Content/images/ProfileAvatar.png" />
            </td>
            <td valign="top">username: Wanida<br />DateTime(1/8/2552 12:50:45)<br />
                <select>
                      <option>Inappriate content</option>
                      <option>Bug</option>
                      <option>Error</option>
                </select><br /><br />
                Topic : <input type="text" title="Some Text"/>
                <textarea rows="10"; cols="27">Details.....</textarea>
            </td>
        </tr>
    </table>
</div>

<%--div for report new blog--%>
<div id="newblog_dialog">
<p>
          <textarea class="input" name="input">Go ahead, take it for a test drive. Highlight some text and click some buttons.</textarea>
        </p>

</div>
<%--div for report edit blog--%>
<div id="editblog_dialog">
<p>
          <textarea class="input" name="input">Go ahead, take it for a test drive. Highlight some text and click some buttons.</textarea>
        </p>
</div>

<%--div สำหรับพื้นที่แสดงเนื้อหาที่เขียนลงใน blog--%>
<div style="background-color:#4C4A49; width:630px; height:520px; ">
    <div style="background-color:#737374; width:565px;margin-left:29px; ">
     <label style="color:#ffffff;" style="margin-top:20px;">Topic : </label><input type="text" style="width:510px; background-color:#333333; margin-top:20px;" />
     <br />
     <p><textarea cols="92" rows="22" style="overflow:hidden;">xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx</textarea></p>
    <label id="newblog" style="margin-top:200px;background-color:#ffffff;  margin-left:480px; margin-top:100px ;color:Green; padding:1px 5px 1px 5px;border:1px solid gray inherit;">New</label><label id="editblog" style="background-color:#000000; padding:2px 6px 2px 6px;border:1px solid gray inherit; color:Red">Edit</label>
    </div>
</div>

<% Html.RenderPartial("FriendList"); %>
     <% Html.RenderPartial("Inbox"); %>
     <% Html.RenderPartial("OptionProfile"); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
<% Html.RenderPartial("SubMenu"); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
<% Html.RenderPartial("BlogComment"); %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="startMenu" runat="server">
<% Html.RenderPartial("StartMenu"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="newsbar" runat="server">
<% Html.RenderPartial("newsBar"); %>
</asp:Content>

