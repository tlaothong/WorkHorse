<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<link href="../../Content/docs.css" rel="stylesheet" type="text/css" />
<link href="../../Content/jquery.marquee.css" rel="stylesheet" type="text/css" />
<script src="../../Scripts/jquery.marquee.js" type="text/javascript"></script>

<style type="text/css">
		h4, h5 {
			margin-bottom: 0;
		}
	
		.marquee .author {
			display: none;
		}
		
		.marquee-author {
			float: left; 
			text-align: right; 
			padding: 4px 5px 1px 0;
		}
	</style>

    <script type="text/javascript">
	<!--        //
        var use_debug = false;

        function debug() {
            if (use_debug && window.console && window.console.log) console.log(arguments);
        }
        $(document).ready(function () {
            $(".marquee").marquee({
                loop: -1
                // this callback runs when the marquee is initialized
			, init: function ($marquee, options) {
			    debug("init", arguments);

			    // shows how we can change the options at runtime
			    if ($marquee.is(".marquee2")) options.yScroll = "bottom";
			}
                // this callback runs before a marquee is shown
			, beforeshow: function ($marquee, $li) {
			    debug("beforeshow", arguments);

			    // check to see if we have an author in the message (used in #marquee6)
			    var $author = $li.find(".author");
			    // move author from the item marquee-author layer and then fade it in
			    if ($author.length) {
			        $(".marquee-author").html("<span style='display:none;'>" + $author.html() + "</span>").find("> span").fadeIn(850);
			    }
			}
                // this callback runs when a has fully scrolled into view (from either top or bottom)
			, show: function () {
			    debug("show", arguments);
			}
                // this callback runs when a after message has being shown
			, aftershow: function ($marquee, $li) {
			    debug("aftershow", arguments);

			    // find the author
			    var $author = $li.find(".author");
			    // hide the author
			    if ($author.length) $(".marquee-author").find("> span").fadeOut(250);
			}
            });
        });

        var iNewMessageCount = 0;

        function addMessage(selector) {
            // increase counter
            iNewMessageCount++;

            // append a new message to the marquee scrolling list
            var $ul = $(selector).append("<li>New message #" + iNewMessageCount + "</li>");
            // update the marquee
            $ul.marquee("update");
        }

        function pause(selector) {
            $(selector).marquee('pause');
        }

        function resume(selector) {
            $(selector).marquee('resume');
        }
	//-->
	</script>

<ul id="marquee5" class="marquee">
	<li><span>สวัสดีคะ วันนี้เราจะนำเสนอโปรเจคใหม่ SPerf เว็บไซต์การศึกษาที่เพียบพร้อมไปทุกด้าาน ไม่ว่าจะเกร็ดความรู้ ความสนุกจากเกม และท่องเที่ยวไปทั่วไปกับแผนที่ของเรา</span></li>
</ul>
