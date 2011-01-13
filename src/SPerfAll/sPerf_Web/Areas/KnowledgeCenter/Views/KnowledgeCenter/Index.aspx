<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ศูนย์การเรียนรู้
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--directory path--%>
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
    <div id="pageBody">
        <div id="movieList"></div>
    </div>
    <script id="movieTmpl" type="text/x-jquery-tmpl">
	<div>
		<div><a href="/KnowledgeCenter/KnowledgeCenter/PlayVideo"><img src="${BoxArt.LargeUrl}" /> </a></div>
		<strong>${Name}</strong>
		<p>{{html Synopsis}}</p>
        <div>
            <input type="checkbox" class="toggle1"/>
        </div>
        <div>
            <label>UnLike</label>
        </div>
        <div>         
            <button class="bookmark" type="button">Bookmark</button>
        </div>
	</div>        
    </script>
    <script type="text/javascript">
        var genre = "Cartoons", pageIndex = 1, pageSize = 3, pageCount = 0

        getMovies(pageIndex);

        function getMovies(index) {
            var query = "http://odata.netflix.com/Catalog/Genres('" + genre + "')/Titles" +
			"?$format=json" +
			"&$inlinecount=allpages" + 			// get total number of records
			"&$skip=" + (index - 1) * pageSize + 	// skip to first record of page
			"&$top=" + pageSize; 				// page size

            pageIndex = index;

            $("#movieList")
			.fadeOut("medium", function () {
			    $.ajax({
			        dataType: "jsonp",
			        url: query,
			        jsonp: "$callback",
			        success: showMovies
			    });
			});
        }

        function showMovies(data) {
            pageCount = Math.ceil(data.d.__count / pageSize),
			movies = data.d.results;

            $("#pager").pager({ pagenumber: pageIndex, pagecount: pageCount, buttonClickCallback: getMovies });

            $("#movieList").empty();

            $("#movieTmpl")
            // Render movies using the movieTemplate
			.tmpl(movies)

            // Display rendered movies in the movieList container
			.appendTo("#movieList")

            // Animate
			.find("div").fadeIn(4000).end()

			$("#movieList").fadeIn("medium")
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
        }   

    </script>
    <div id="pager"></div>
    
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
