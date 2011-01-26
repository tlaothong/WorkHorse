<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ศูนย์การเรียนรู้
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function () {

        $(".pane .delete").click(function () {
            $(this).parents(".pane").animate({ opacity: 'hide' }, "slow");
        });

    });
</script>
<style type="text/css"> 
h3 {
	margin: 0;
	padding: 0 0 .3em;
}
p {
	margin: 0;
	padding: 0 0 .5em;
}
.pane {
	background: #edf5e1;
	padding: 10px 20px 10px;
	position: relative;
	border-top: solid 2px #c4df9b;
}
.pane .delete {
	position: absolute;
	top: 10px;
	right: 10px;
	cursor: pointer;
}
</style>
<table>
    <tr>
        <td><% Html.RenderPartial("Cartoon"); %></td>
    </tr>
</table>
<br />
<br />
<div class="today">
    <div style="margin-top:2px;"><img src="/Content/images/calendar.png" />Todays <script type="text/javascript">
                                                                                      var d = new Date();
                       document.write(d.getDate(), "/", d.getMonth(), "/", d.getYear());
</script></div> 
    <table style="margin-top:12px;">
       <tr>
            <td><img src="/Content/profile/pic_friend/1.png" /></td><td valign="top">Tao's Birthday</td>
            
        </tr>
    </table>
    <div>วันเกิดเต๋า : เพื่อนของคุณ</div>
    <div>เขียนคำอวยพรส่งของขวัญให้เต๋า </div>
    <table style="margin-top:12px;">
       <tr>
            <td><img src="/Content/profile/pic_friend/2.png" /></td><td valign="top">Tao's Birthday</td>
            
        </tr>
    </table>
    <div>วันเกิดเต๋า : เพื่อนของคุณ</div>
    <div>เขียนคำอวยพรส่งของขวัญให้เต๋า </div>
    <table style="margin-top:12px;">
       <tr>
            <td><img src="/Content/profile/pic_friend/3.png" /></td><td valign="top">Tao's Birthday</td>
            
        </tr>
    </table>
    <div>วันเกิดเต๋า : เพื่อนของคุณ</div>
    <div>เขียนคำอวยพรส่งของขวัญให้เต๋า </div>
    <table style="margin-top:12px;">
       <tr>
            <td><img src="/Content/profile/pic_friend/4.png" /></td><td valign="top">Tao's Birthday</td>
            
        </tr>
    </table>
    <div>วันเกิดเต๋า : เพื่อนของคุณ</div>
    <div>เขียนคำอวยพรส่งของขวัญให้เต๋า </div>
</div>
    <%-- Log events--%>
    <div class="logevent">
        <div class="stylefriend">
            Log Events
        </div>
        <div class="logpostevent"style="margin-top: 14px;" >
            <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
                        <div class="pane">
                <div style="float:left;"><img src="/Content/images/e1.png" alt=""/></div>
	            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	            <img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
            </div>
        </div>
        <%--<table style="margin-top: 14px;">
            <tr class="logpostevent">
                    <td><div class="pane">
	<img src="/Content/images/e1.png" alt="" /><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </td></div>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e1.png" alt="" /><br />
                        Nelson lao</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="eventdetail">
                        <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="eventborder">
                    <div class="eventpic">
                        <img src="/Content/images/e2.png" alt="" /><br />
                        Mayda Jui</div>
                    <div class="pane">
	<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros. Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
	<img src="/Content/images/btn-delete.gif" alt="delete" class="delete" />
                    </div>
                </td>
            </tr>
        </table>--%>
</div>
    <% Html.RenderPartial("HomeOption"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
<% Html.RenderPartial("SubMenu"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
<% Html.RenderPartial("Banners"); %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="startMenu" runat="server">
<% Html.RenderPartial("StartMenu"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="newsbar" runat="server">
<% Html.RenderPartial("newsBar"); %>
</asp:Content>


