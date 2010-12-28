<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ศูนย์การเรียนรู้
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
    <script id="cartTmpl" type="text/x-jquery-tmpl">
	<td class="cart-${!!count}" colspan="4">
		<span class="text">${count} items in Cart...</span>
		{{if count}}
			<span id="submit">Checkout</span>
			<span id="cancel">Remove All</span>
			{{if count>1}}
				<span id="sort"><span id="sortBtn">Sort</span>:
					<select>
						<option value="0" {{if sortBy==="0"}}selected{{/if}}>Name A-Z</option>
						<option value="1" {{if sortBy==="1"}}selected{{/if}}>Name Z-A</option>
						<option value="2" {{if sortBy==="2"}}selected{{/if}}>Date</option>
					</select>
				</span>
			{{/if}}
			</select>
		{{/if}}
	</td>
    </script>
    <script id="bookingTitleTmpl" type="text/x-jquery-tmpl">
	<tr class="bookingTitle${$item.mode}">
		<td>${movie.Name}</td><td>${movieTheater}</td>
		<td>${formatDate(date)}</td>
		<td>
			${quantity}
			<span class="ui-icon close"></span>
		</td>
	</tr>
    </script>
    <script type="text/javascript">
        var genre = "Cartoons", pageIndex = 1, pageSize = 5, pageCount = 0,
		cart = { bookings: {}, count: 0, sortBy: 0 }, bookingTmplItems = {}, selectedBooking;

        getMovies(pageIndex);

        $("#genres li").click(selectGenre);

        $(".cart")
		.delegate("select", "change", sort)
		.delegate("#sortBtn", "click", sort)
		.delegate("#submit", "click", function () {
		    alert(cart.count + " bookings submitted for payment...");
		    removeBookings();
		})
		.delegate("#cancel", "click", function () {
		    removeBookings();
		})
		.empty();

        $("#cartTmpl")
		.tmpl(cart)
		.appendTo(".cart", cart);

        var cartTmplItem = $(".cart td").tmplItem();

        function selectGenre() {
            $("#genres li").removeClass("selected");
            $(this).addClass("selected");

            pageIndex = 1;
            genre = encodeURI($(this).text());
            getMovies(pageIndex);
        }

        function sort() {
            var compare = compareName, reverse = false, data = [];
            cart.sortBy = $("#sort select").val();
            switch ($("#sort select").val()) {
                case "1":
                    reverse = true;
                    break;
                case "2":
                    compare = compareDate;
                    break;
            }

            for (var item in cart.bookings) {
                data.push(cart.bookings[item]);
            }
            data = data.sort(compare);

            for (var i = 0, l = data.length; i < l; i++) {
                $(bookingTmplItems[data[i].movie.Id].nodes).appendTo("#bookingsList");
            }

            function compareName(a, b) {
                return a == b ? 0 : (((a.movie.Name > b.movie.Name) !== reverse) ? 1 : -1);
            }
            function compareDate(a, b) {
                return a.date - b.date;
            }
        }

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

            // Add click handler
			.find(".buyButton").click(function () {
			    buyTickets($(this).tmplItem().data);
			});

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
        function buyTickets(movie) {
            // Add item to cart
            var booking = cart.bookings[movie.Id];
            if (booking) {
                booking.quantity++;
            } else {
                cart.count++;
                cartTmplItem.update();
                booking = { movie: movie, date: new Date(), quantity: 1, movieTheater: "" };
            }
            selectBooking(booking);
        }

        function selectBooking(booking) {
            if (selectedBooking) {
                if (selectedBooking === booking) {
                    updateBooking(bookingTmplItems[selectedBooking.movie.Id]);
                    return;
                }
                // Collapse previously selected booking, and switch to non-edit view
                var oldSelected = selectedBooking;
                $("div", bookingTmplItems[oldSelected.movie.Id].nodes).animate({ height: 0 }, 500, function () {
                    switchView(oldSelected);
                });
            }
            selectedBooking = booking;
            if (!booking) {
                return;
            }
            if (cart.bookings[booking.movie.Id]) {
                switchView(booking, true);
            } else {
                cart.bookings[booking.movie.Id] = booking;

                var bookingNode = $("#bookingEditTmpl")

                // Render the booking for the chosen movie using the bookingEditTemplate
				.tmpl(booking, { animate: true })

                // Append the rendered booking to the bookings list
				.appendTo("#bookingsList")

                // Get the 2nd <tr> of the appended booking
				.last()[0];

                // Get the template item for the 2nd <tr>, which is the template item for the "bookingEditTmpl" template
                var newItem = $.tmplItem(bookingNode);
                bookingTmplItems[booking.movie.Id] = newItem;

                // Attach handlers etc. on the rendered template.
                bookingEditRendered(newItem);
            }
        }

        function bookingEditRendered(item) {
            var data = item.data, nodes = item.nodes;

            $(nodes[0]).click(function () {
                selectBooking();
            });

            $(".close", nodes).click(removeBooking);

            $(".date", nodes).change(function () {
                data.date = $(this).datepicker("getDate");
                updateBooking(item);
            })
		.datepicker({ dateFormat: "DD, d MM, yy" });

            $(".quantity", nodes).change(function () {
                data.quantity = $(this).val();
                updateBooking(item);
            });

            $(".theater", nodes).change(function () {
                data.movieTheater = $(this).val();
                updateBooking(item);
            });

            if (item.animate) {
                $("div", nodes).css("height", 0).animate({ height: 116 }, 500);
            }
        }

        function bookingRendered(item) {
            $(item.nodes).click(function () {
                selectBooking(item.data);
            });
            $(".close", item.nodes).click(removeBooking);
        }

        function switchView(booking, edit) {
            if (!booking) {
                return;
            }
            var item = bookingTmplItems[booking.movie.Id],
			tmpl = $(edit ? "#bookingEditTmpl" : "#bookingTitleTmpl").template();
            if (item.tmpl !== tmpl) {
                item.tmpl = tmpl;
                item.update();
                (edit ? bookingEditRendered : bookingRendered)(item);
            }
        }

        function updateBooking(item) {
            item.animate = false;
            item.update();
            (item.data === selectedBooking ? bookingEditRendered : bookingRendered)(item);
            item.animate = true;
        }

        function removeBooking() {
            var booking = $.tmplItem(this).data;
            if (booking === selectedBooking) {
                selectedBooking = null;
            }
            delete cart.bookings[booking.movie.Id];
            cart.count--;
            cartTmplItem.update();
            $(bookingTmplItems[booking.movie.Id].nodes).remove();
            delete bookingTmplItems[booking.movie.Id];
            return false;
        }

        function removeBookings() {
            for (var item in bookingTmplItems) {
                $(bookingTmplItems[item].nodes).remove();
                delete bookingTmplItems[item];
            }
            bookingTmplItems = {};
            cart.count = 0;
            cart.bookings = {};
            selectedBooking = null;
            cartTmplItem.update();
        }

        function formatDate(date) {
            return date.toLocaleDateString();
        }

        function removeContext(item) {
            $(item.nodes).remove();
        }
        
    </script>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('#movieList').hoverscroll({ vertical: true, height: 550, width: 595 });
        });        
    </script> --%>  
    
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
