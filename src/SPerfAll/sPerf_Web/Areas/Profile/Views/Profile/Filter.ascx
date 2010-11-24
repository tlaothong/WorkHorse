<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<script type="text/javascript">
    $(function () {
        var availableTags = [
			"On",
			"Khak",
			"Pray",
			"Tao",
			"Jo",
			"Bird",
			"Top",
			"Meaw",
			"Toomy",
			"Ae",
			"Nid",
			"Boy",
			"Ku",
			"Au",
			"Sak"
		];
        $("#tags").autocomplete({
            source: availableTags
        });
    });
</script>
<div>
    <div>
        <input type="radio" /><label>A-z</label>
        <input type="radio" /><label>a-Z</label>
    </div>
    <div><input type="radio" /><label>Online Only</label></div>
</div>
<div style="float: right; margin-top: -25px;">
    <div style="float: left;">
        <select style="height: 20px;">
            <option>Search by Current City</option>
            <option>Search by Hometown</option>
            <option>Search by School</option>
        </select>
    </div>
    <div class="ui-widget">
        <input id="tags" value="Search friends ..." style="width: 150px; color: Gray; margin-left: 10px;" />
    </div>
</div>