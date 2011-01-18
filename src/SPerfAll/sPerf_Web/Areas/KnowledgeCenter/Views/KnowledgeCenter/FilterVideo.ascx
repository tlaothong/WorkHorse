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

<div style="margin-left: 30px">
    <div class="ui-widget">
        <input id="tags" value="Search Video ..." style="width: 150px; color: Gray; margin-left: 10px;" />
    </div>
</div>