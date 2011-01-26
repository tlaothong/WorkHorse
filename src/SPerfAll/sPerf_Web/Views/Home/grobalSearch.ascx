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
        $("#tagss").autocomplete({
            source: availableTags
        });
    });
                </script>
                <div class="demo">
                    <input type="text" class="input_text" id="tagss" />
                </div>