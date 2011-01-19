<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ศูนย์การเรียนรู้
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../../../Scripts/quickpager.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("ul.paging").quickPager({ pagerLocation: "both" });
            $("ul.paging").fadeOut("medium");
            $("ul.paging").fadeIn("medium");
            $("ul.paging")
            // Animate
			.find("ul.paging").fadeIn(4000).end()
            Sys.require(Sys.components.toggleButton, function () {
                $().toggleButton.defaults = {
                    CheckedImageUrl: "/Content/images/Unchecked_gray.gif",
                    UncheckedImageUrl: "/Content/images/checked.gif",
                    ImageWidth: 20,
                    ImageHeight: 20
                };
                $(".toggle1").toggleButton();
            });
            $(".bookmark").click(function () {
                $(this).slideUp();
            });
            $("#bookmark").hover(function () {
                $(this).addClass("hilite");
            }, function () {
                $(this).removeClass("hilite");
            });
        });
        

    </script>
    <style type="text/css">
        ul
        {
            clear: both;
        }
        ul.paging li, ul.paging2 li
        {
            background: #FFFFFF;
            color: #111;
            line-height: 1;
            width: 590px;
            margin-bottom: 1px;
            padding: 5px;
            list-style: none;
            margin-left: -30px;
        }
        ul.paging li
        {
            border-bottom: 1px solid #D1D3D4;
        }
        
        ul.red
        {
            outline: 10px solid red;
        }
        
        ul.simplePagerNav li
        {
            display: block;
            float: left;
            padding: 3px;
            margin-bottom: 10px;
            font-family: georgia;
            font-size: large;
        }
        
        ul.simplePagerNav li a
        {
            color: #333;
            text-decoration: none;
        }
        
        li.currentPage
        {
            background: red;
            background: #83bd63;
        }
        
        ul.simplePagerNav li.currentPage a
        {
            color: #fff;
        }
        
        table.pageme
        {
            border-collapse: collapse;
            border: 1px solid #ccc;
        }
        
        table.pageme td
        {
            border-collapse: collapse;
            border: 1px solid #ccc;
        }
        
        ul.paging li.sticky
        {
            background-color: red !important;
            display: block !important;
        }
    </style>
    <%--directory path--%>
    <div>
        <table>
            <tbody>
                <tr>
                    <td>
                        <a href="/Home">Home</a>
                    </td>
                    <td>
                        >
                    </td>
                    <td>
                        Video
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="padding-top: 10px;">
        <% Html.RenderPartial("FilterVideo"); %></div>
    <div id="paging">
        <ul class="paging">
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo">
                                <img src="../../../../Content/images/VideoPlay.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    Video Cartoon</h2>
                            </div>
                            <div>
                                ID : 452</div>
                            <div>
                                Name : BasicMath</div>
                            <div>
                                Path : Math/Calulus</div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
        </ul>
    </div>
    <% Html.RenderPartial("PostNewVideos"); %>
    <% Html.RenderPartial("Option"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubmenuVideo"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
    <% Html.RenderPartial("AdvanceSearch"); %>
    <% Html.RenderPartial("Banners"); %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="startMenu" runat="server">
    <% Html.RenderPartial("StartMenu"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="newsbar" runat="server">
    <% Html.RenderPartial("newsBar"); %>
</asp:Content>
