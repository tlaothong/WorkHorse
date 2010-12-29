<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Archievement
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
<script src="../../../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
<script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>

    <div style="background-color: #DFE1E3; padding: 2px 3px 5px 3px; position: fixed;
        width: 625px; z-index: 9;">
        <div style="margin-bottom: 10px;">
            <label style="float: left; margin-left: 20px;">
                Dick Kapooook's Archeivement</label><label style="margin-left: 10px; color: #5FB546;
                    float: left;">(2,500 AP)</label>
            <div id="compare" style="background-color: White; border: 1px solid gray; padding: 1px 1px 2px 1px;
                width: 50px; float: left; margin-left: 50px;">
                <a href="#" style="color: #5FB546; text-decoration: none;">Compare</a></div>
            <div style="float: right;">
                <select>
                    <option>All</option>
                    <option>Do</option>
                    <option>Not Do</option>
                </select></div>
        </div>
    </div>
    <div style="background-color: #505151; padding-top: 10px; padding-bottom: 20px; margin-top: 25px;
        position: relative;">
        <div style="background-color: White; border: 1px solid gray; margin-left: 50px; width: 50px;
            text-align: center; color: #5FB546;">
            <label>
                Profile</label></div>
        <div style="background-color: White; border: 1px solid gray; padding-top: 10px; width: 350px;
            margin-left: 10px;">
            <div style="border: 2px solid #5FB546; margin-left: 10px; margin-bottom: 10px; margin-right: 10px;">
                <p>
                    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx</p>
                <div style="color: Gray; padding-left: 250px;">
                    Read more...</div>
            </div>
            <div style="border: 2px solid #5FB546; margin-left: 10px; margin-bottom: 10px; margin-right: 10px;">
                <p>
                    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx</p>
                <div style="color: Gray; padding-left: 250px;">
                    Read more...</div>
            </div>
            <div style="border: 2px solid #5FB546; margin-left: 10px; margin-bottom: 10px; margin-right: 10px;">
                <p>
                    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx</p>
                <div style="color: Gray; padding-left: 250px;">
                    Read more...</div>
            </div>
            <div style="border: 2px solid #5FB546; margin-left: 10px; margin-bottom: 10px; margin-right: 10px;">
                <p>
                    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx</p>
                <div style="color: Gray; padding-left: 250px;">
                    Read more...</div>
            </div>
            <div style="border: 1px solid #5FB546; margin-left: 10px; margin-bottom: 10px; margin-right: 10px;">
                <p>
                    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx</p>
                <div style="color: Gray; padding-left: 250px;">
                    Read more...</div>
            </div>
            <div style="border: 1px solid #5FB546; margin-left: 10px; margin-bottom: 10px; margin-right: 10px;">
                <p>
                    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    xxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxx</p>
                <div style="color: Gray; padding-left: 250px;">
                    Read more...</div>
            </div>
            <div style="background-color: #727373; text-align: center;">
                <label>
                    SeeMore...</label></div>
        </div>
        <div style="width: 150px; margin-top: -480px; margin-right: 20px; margin-left: 430px;
            position: fixed;">
            <div>
                <div style="border: 2px solid #333333; width: 80px; text-align: center; margin-bottom: -2px;">
                    <a href="#" style="color: #5FB546; text-decoration: none;">Lastest</a>
                </div>
                <div style="background-color: #727373; border: 2px solid #333333; width: 150px; text-align: center;
                    color: White; padding-top: 5px; padding-bottom: 5px;">
                    <label>
                        All(32)</label><label style="margin-left: 20px;">Success(5)</label>
                </div>
            </div>
            <div style="margin-top: 10px;">
                <div style="border: 2px solid #727373; width: 80px; text-align: center; color: #5FB546;
                    margin-bottom: -2px;">
                    <a href="#" style="color: #5FB546; text-decoration: none;">Profile</a>
                </div>
                <div style="background-color: #333333; border: 2px solid #727373; width: 150px; text-align: center;
                    color: White; padding-top: 5px; padding-bottom: 5px;">
                    <label>
                        All(32)</label><label style="margin-left: 20px;">Success(5)</label>
                </div>
            </div>
            <div style="margin-top: 10px;">
                <div style="border: 2px solid #333333; width: 80px; text-align: center; color: #5FB546;
                    margin-bottom: -2px;">
                    <a href="#" style="color: #5FB546; text-decoration: none;">Application</a>
                </div>
                <div style="background-color: #727373; border: 2px solid #333333; width: 150px; text-align: center;
                    color: White; padding-top: 5px; padding-bottom: 5px;">
                    <label>
                        All(32)</label><label style="margin-left: 20px;">Success(5)</label>
                </div>
            </div>
            <div style="margin-top: 10px;">
                <div style="border: 2px solid #333333; width: 150px; text-align: center; color: #5FB546;
                    margin-bottom: -2px;">
                    <a href="#" style="color: #5FB546; text-decoration: none;">Knowledge Center</a>
                </div>
                <div style="background-color: #727373; border: 2px solid #333333; width: 150px; text-align: center;
                    color: White; padding-top: 5px; padding-bottom: 5px;">
                    <label>
                        All(32)</label><label style="margin-left: 20px;">Success(5)</label>
                </div>
            </div>
            <div style="margin-top: 10px;">
                <div style="border: 2px solid #333333; width: 80px; text-align: center; color: #5FB546;
                    margin-bottom: -2px;">
                    <a href="#" style="color: #5FB546; text-decoration: none;">Game</a>
                </div>
                <div style="background-color: #727373; border: 2px solid #333333; width: 150px; text-align: center;
                    color: White; padding-top: 5px; padding-bottom: 5px;">
                    <label>
                        All(32)</label><label style="margin-left: 20px;">Success(5)</label>
                </div>
            </div>
        </div>
    </div>
    <% Html.RenderPartial("Compare_Archeivement"); %>
    <% Html.RenderPartial("FriendList"); %>
    <% Html.RenderPartial("Inbox"); %>
    <% Html.RenderPartial("OptionProfile"); %>
    <% Html.RenderPartial("Popup_Comment_Archeivement"); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
<% Html.RenderPartial("SubMenu"); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
<div style="margin-top: -5px;">
        <% Html.RenderPartial("Comment_Archeivement"); %></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="startMenu" runat="server">
<% Html.RenderPartial("StartMenu"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="newsbar" runat="server">
<% Html.RenderPartial("newsBar"); %>
</asp:Content>

