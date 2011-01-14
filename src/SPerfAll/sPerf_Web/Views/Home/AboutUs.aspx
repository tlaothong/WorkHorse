<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AboutUs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <%--<link  href="../../../../Content/jquery.ad-gallery.css" rel="stylesheet" type="text/css" />--%>
  <script src="../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
  <script src="../../Scripts/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
  <%--<script  src="../../../../Scripts/jquery.ad-gallery.js" type="text/javascript"></script>--%>

<%--<script type="text/javascript">
    $(function () {
        $('img.image1').data('ad-desc', 'Whoa! This description is set through elm.data("ad-desc") instead of using the longdesc attribute.<br>And it contains <strong>H</strong>ow <strong>T</strong>o <strong>M</strong>eet <strong>L</strong>adies... <em>What?</em> That aint what HTML stands for? Man...');
        $('img.image1').data('ad-title', 'Title through $.data');
        $('img.image4').data('ad-desc', 'This image is wider than the wrapper, so it has been scaled down');
        $('img.image5').data('ad-desc', 'This image is higher than the wrapper, so it has been scaled down');
        var galleries = $('.ad-gallery').adGallery();
        $('#switch-effect').change(
      function () {
          galleries[0].settings.effect = $(this).val();
          return false;
      }
    );
        $('#toggle-slideshow').click(
      function () {
          galleries[0].slideshow.toggle();
          return false;
      }
    );
        $('#toggle-description').click(
      function () {
          if (!galleries[0].settings.description_wrapper) {
              galleries[0].settings.description_wrapper = $('#descriptions');
          } else {
              galleries[0].settings.description_wrapper = false;
          }
          return false;
      }
    );
    });
  </script>
<style type="text/css">
    
  select, input, textarea {
    font-size: 1em;
  }
  h2 {
    margin-top: 1.2em;
    margin-bottom: 0;
    padding: 0;
    border-bottom: 1px dotted #dedede;
  }
  h3 {
    margin-top: 1.2em;
    margin-bottom: 0;
    padding: 0;
  }
  .example {
    border: 1px solid #CCC;
    background: #f2f2f2;
    padding: 10px;
  }
  ul {
    list-style-image:url(/Content/profile/list-style.gif);
  }
  pre {
    border: 1px solid #CCC;
    background: #f2f2f2;
    padding: 10px;
  }
  code {
    margin: 0;
    padding: 0;
  }

  #gallery 
  {
    margin-top:-10px;
    margin-left:30px;
    margin-right:30px;
    margin-bottom:0px;
  }
  #descriptions {
    position: relative;
    height: 50px;
    background:#F9F4CA;
    margin-top: 10px;
    width: 640px;
    padding: 10px;
    overflow: hidden;
  }
    #descriptions .ad-image-description {
      position: absolute;
    }
      #descriptions .ad-image-description .ad-description-title {
        display: block;
      }
  </style>--%>

  <script type="text/javascript">
      $(document).ready(function () {

          //Show Banner
          $(".main_image .desc").show(); //Show Banner
          $(".main_image .block").animate({ opacity: 0.85 }, 1); //Set Opacity

          //Click and Hover events for thumbnail list
          $(".image_thumb ul li:first").addClass('active');
          $(".image_thumb ul li").click(function () {
              //Set Variables
              var imgAlt = $(this).find('img').attr("alt"); //Get Alt Tag of Image
              var imgTitle = $(this).find('a').attr("href"); //Get Main Image URL
              var imgDesc = $(this).find('.block').html(); 	//Get HTML of block
              var imgDescHeight = $(".main_image").find('.block').height(); //Calculate height of block	

              if ($(this).is(".active")) {  //If it's already active, then...
                  return false; // Don't click through
              } else {
                  //Animate the Teaser				
                  $(".main_image .block").animate({ opacity: 0, marginBottom: -imgDescHeight }, 250, function () {
                      $(".main_image .block").html(imgDesc).animate({ opacity: 0.85, marginBottom: "0" }, 250);
                      $(".main_image img").attr({ src: imgTitle, alt: imgAlt });
                  });
              }

              $(".image_thumb ul li").removeClass('active'); //Remove class of 'active' on all lists
              $(this).addClass('active');  //add class of 'active' on this list only
              return false;

          }).hover(function () {
              $(this).addClass('hover');
          }, function () {
              $(this).removeClass('hover');
          });

          //Toggle Teaser
          $("a.collapse").click(function () {
              $(".main_image .block").slideToggle();
              $("a.collapse").toggleClass("show");
          });

      }); //Close Function
</script>
<style type="text/css">
* {margin: 0; padding: 0; outline: none;}
img {border: none;}
h1 {
	text-align: center;
	background: url(h1_bg.gif) no-repeat;
	text-indent: -99999px;
	margin: 100px 0 10px;
}
.containers {
	overflow: hidden;
	width: 600px;
	margin-left:5px;
}

/*--Main Image Preview--*/
.main_image {
	width: 300px; height: 456px;
	float: left;
	position: relative;
	overflow: hidden;
	color: #fff;
}
.main_image h2 {
	font-size: 2em;
	font-weight: normal;
	margin: 0 0 5px;	padding: 10px;
}
.main_image p {
	font-size: 1.2em;
	padding: 10px;	margin: 0;
	line-height: 1.6em;
}
.block small { 
	padding: 0 0 0 20px; 
	background: url(icon_calendar.gif) no-repeat 0 center; 
	font-size: 1em; 
}
.main_image .block small {margin-left: 10px;}
.main_image .desc{
	position: absolute;
	bottom: 0;	left: 0;
	width: 100%;
	display: none;
}
.main_image .block{
	width: 100%;
	background: #111;
	border-top: 1px solid #000;
}
.main_image a.collapse {
	background: url(btn_collapse.gif) no-repeat left top;
	text-indent: -99999px;
	position: absolute; 
	top: -27px; right: 20px; 
}
.main_image a.show {background-position: left bottom;} 
 
 
.image_thumb {
	float: left;
	width: 299px;
	background: #f0f0f0;
	border-right: 1px solid #fff;
	border-top: 1px solid #ccc;
}
.image_thumb img {
	border: 1px solid #ccc; 
	padding: 5px; 
	background: #fff; 
	float: left;
}
.image_thumb ul {
	margin: 0; padding: 0;
	list-style: none;
}
.image_thumb ul li{
	margin: 0; padding: 12px 10px;
	background: #f0f0f0 url(nav_a.gif) repeat-x;
	width: 279px;
	float: left;
	border-bottom: 1px solid #ccc;
	border-top: 1px solid #fff;
	border-right: 1px solid #ccc;
}
.image_thumb ul li.hover {
	background: #ddd;
	cursor: pointer;
}
.image_thumb ul li.active {
	background: #fff;
	cursor: default;
}
html .image_thumb ul li h2 {
	font-size: 1.5em; 
	margin: 5px 0; padding: 0;
}
.image_thumb ul li .block {
	float: left; 
	margin-left: 10px;
	padding: 0;
	width: 170px;
}	
.image_thumb ul li p{display: none;}
 
 
 
</style>
<%--start gallery--%>
<%--<div id="gallery" class="ad-gallery">
    <div class="ad-image-wrapper"></div>
    <div>
        <table><tr>
            <td style="margin-top:3px;">
                <div>
                    <img  style="margin-left:500px;" src="/Content/images/LD1.png" title="DisLike(210)" />
                </div>
            </td>
            <td>
                <div>
                    <img  src="/Content/images/LD2.png" title="You are normal(100)" />
                </div>
            </td>
            <td>
                <div>
                    <img  src="/Content/images/LD3.png" title="Like(253)" />
                </div>        
            </td>
        </tr>
    </table>     
    </div>
    <div style="border-bottom-color:#69BA55; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin; width:550px; margin-top:29px">
    </div>
    <br />
      <div class="ad-nav">
        <div class="ad-thumbs">
          <ul class="ad-thumb-list">
            <li>
              <a href="/Content/profile/1.jpg">
                <img src="/Content/profile/thumbs/t1.jpg" alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/10.jpg">
                <img src="/Content/profile/thumbs/t10.jpg" alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/11.jpg">
                <img src="/Content/profile/thumbs/t11.jpg" alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/12.jpg">
                <img src="/Content/profile/thumbs/t12.jpg" alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/13.jpg">
                <img src="/Content/profile/thumbs/t13.jpg"alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/14.jpg">
                <img src="/Content/profile/thumbs/t14.jpg"  alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/2.jpg">
                <img src="/Content/profile/thumbs/t2.jpg" alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/3.jpg">
                <img src="/Content/profile/thumbs/t3.jpg" alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/4.jpg">
                <img src="/Content/profile/thumbs/t4.jpg"alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/5.jpg">
                <img src="/Content/profile/thumbs/t5.jpg" alt="This is a nice, and incredibly descriptive, description of the image 10.jpg" >
              </a>
            </li>
            <li>
              <a href="/Content/profile/6.jpg">
                <img src="/Content/profile/thumbs/t6.jpg"alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/7.jpg">
                <img src="/Content/profile/thumbs/t7.jpg" alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/8.jpg">
                <img src="/Content/profile/thumbs/t8.jpg"alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
            <li>
              <a href="/Content/profile/9.jpg">
                <img src="/Content/profile/thumbs/t9.jpg" alt="This is a nice, and incredibly descriptive, description of the image 10.jpg">
              </a>
            </li>
          </ul>
        </div>
      </div>
    </div>--%>
<div class="containers">
	<div class="main_image">
		<img src="/Content/TheSStarf/banner1.jpg" alt="- banner1" />
		<div class="desc">
			<div class="block">
			    <h2>Slowing Down</h2>
				<p>Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem. Neo nostrud letatio aliquam validus eum quadrum, volutpat et.<br /><a href="http://store.glennz.com/slowingdown.html" target="_blank">Artwork By Glenn Jones</a> </p>
			</div>
		</div>
        		<img src="/Content/TheSStarf/banner2.jpg" alt="- banner2" />
		<div class="desc">
			<div class="block">
			    <h2>Organized Food Fight</h2>
				<p>Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem. Neo nostrud letatio aliquam validus eum quadrum, volutpat et.<br /><a href="http://store.glennz.com/slowingdown.html" target="_blank">Artwork By Glenn Jones</a> </p>
			</div>
		</div>
	</div>
	<div class="image_thumb">
		<ul>
			<li>
				<a href="/Content/TheSStarf/banner1.jpg"><img src="/Content/TheSStarf/banner1_thumb.jpg" alt="Slowing Dow" /></a>
				<div class="block">
					<div>Slowing Down</div>
					<p>Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem. Neo nostrud letatio aliquam validus eum quadrum, volutpat et.<br /><a href="http://store.glennz.com/slowingdown.html" target="_blank">Artwork By Glenn Jones</a> </p>
				</div>
			</li>
			<li>
				<a href="/Content/TheSStarf/banner2.jpg"><img src="/Content/TheSStarf/banner2_thumb.jpg" alt="Organized Food Fight" /></a>
				<div class="block">
					<h2>Organized Food Fight</h2>
					<p>Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem. Neo nostrud letatio aliquam validus eum quadrum, volutpat et. Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem. Neo nostrud letatio aliquam validus eum quadrum, volutpat et.</p>
				</div>
			</li>
			<li>
				<a href="/Content/TheSStarf/banner3.jpg"><img src="/Content/TheSStarf/banner3_thumb.jpg" alt="Endangered Species" /></a>
				<div class="block">
					<h2>Endangered Species</h2>
					<p>Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem. Neo nostrud letatio aliquam validus eum quadrum, volutpat et.<br /><a href="http://store.glennz.com/ensp.html" target="_blank">Artwork By Glenn Jones</a></p>
				</div>
			</li>
			<li>
				<a href="/Content/TheSStarf/banner4.jpg"><img src="/Content/TheSStarf/banner4_thumb.jpg" alt="Evolution" /></a>
				<div class="block">
					<h2>Evolution</h2>
					<p>Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem. Neo nostrud letatio aliquam validus eum quadrum, volutpat et. Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem. Neo nostrud letatio aliquam validus eum quadrum, volutpat et.<br /><a href="http://store.glennz.com/evolution.html" target="_blank">Artwork By Glenn Jones</a></p>
				</div>
			</li>
			<li>
				<a href="/Content/TheSStarf/banner5.jpg"><img src="/Content/TheSStarf/banner5_thumb.jpg" alt="Puzzled Putter" /></a>
				<div class="block">
					<h2>Puzzled Putter</h2>
					<p>Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem. Neo nostrud letatio aliquam validus eum quadrum, volutpat et. <br /><a href="http://store.glennz.com/puzzledputter.html" target="_blank">Artwork By Glenn Jones</a></p>
				</div>
			</li>
			<li>
				<a href="/Content/TheSStarf/banner6.jpg"><img src="/Content/TheSStarf/banner6_thumb.jpg" alt="Secret Habit" /></a>
				<div class="block">
					<h2>Secret Habit</h2>
					<p>Autem conventio nimis quis ad, nisl secundum sed, facilisi, vicis augue regula, ratis, autem.<br /><a href="http://store.glennz.com/secrethabit1.html" target="_blank">Artwork By Glenn Jones</a></p>
				</div>
			</li>
		</ul>
	</div>
</div>
<%--end gallery--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
<% Html.RenderPartial("SubMenu"); %>
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

