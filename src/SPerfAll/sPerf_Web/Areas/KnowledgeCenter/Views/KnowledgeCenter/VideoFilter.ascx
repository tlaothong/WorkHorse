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
        $("#tags_InviteFriend").autocomplete({
            source: availableTags
        });
    });
</script>
<div style="margin-top: 20px; padding-bottom: 20px">
    <div class="ui-widget">
        <input id="tags_InviteFriend" value="Search Video ..." style="width: 150px; color: Gray; margin-left: 10px;" />
    </div>
</div>
