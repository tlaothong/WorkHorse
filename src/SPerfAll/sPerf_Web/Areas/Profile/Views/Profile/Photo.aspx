<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Photo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
  <link  href="../../../../Content/jquery.ad-gallery.css" rel="stylesheet" type="text/css" />
  <link  href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
  <link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
  <script  type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
  <script  type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
  <script  src="../../../../Scripts/jquery.ad-gallery.js" type="text/javascript"></script>
  <script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>


<script type="text/javascript">
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
  * {
    color: #333;
    line-height: 140%;
  }
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
  </style>
  <%--script for report--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#showReportphotopage").dialog({
            autoOpen: false,
            modal: true,
            width: 450,
            title: 'Report Problem',
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Send": function () {
                    $(this).dialog("close");
                }
            }
        });

        // Dialog Link
        $('.reportsphotopage').click(function () {
            $('#showReportphotopage').dialog('open');
            return false;
        });
    });

</script>

<%--script for organize--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#showorganize").dialog({
            autoOpen: false,
            modal: true,
            width: 450,
            title: 'Photo Organize',
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Send": function () {
                    $(this).dialog("close");
                }
            }
        });

        // Dialog Link
        $('.organizes').click(function () {
            $('#showorganize').dialog('open');
            return false;
        });
    });

</script>
<div id="container">
<div style="margin-left:30px;">ToomMy's Album  <select id="switch-effect" style="margin-top:5px;">
                  <option>วันปีใหม่ 2553</option>
                  <option>วันเกิดน้องลิง</option>
                  <option>เที่ยวเมืองไทย</option>
                  <option>เขาใหญ่</option>
                  <option>แล้วแต่จะเพิ่มนะคะ</option>
                    </select><label class="organizes" style="margin-left:40px; color:#808285; background-color:#E7E8E9;padding:2px 4px 2px 4px;border: 1px solid gray;">Organize</label>
    </div>
    <div style="margin-left:30px; color:#69BA55;"><input type="checkbox" />Use as display<label class="reportsphotopage" style="text-decoration:underline; color:#69BA55; margin-left:10px">Report</label></div>
    <%--div for report dialog--%>
    <div id="showReportphotopage">
    <table>
            <tr>
                <td valign="top">
                    <img src="/Content/images/ProfileAvatar.png" />
                </td>
                <td valign="top">username: Wanida<br />DateTime(1/8/2552 12:50:45)<br />
                    <select>
                          <option>Inappriate content</option>
                          <option>Bug</option>
                          <option>Error</option>
                    </select><br /><br />
                    Topic : <input type="text" title="Some Text"/>
                    <textarea rows="10"; cols="27">Details.....</textarea>
                </td>
            </tr>
        </table>
    </div>

    <%--div for organize dialog--%>
    <div id="showorganize">
    <%--<table>
            <tr>
                <td valign="top">
                    <img src="/Content/images/ProfileAvatar.png" />
                </td>
                <td valign="top">username: Wanida<br />DateTime(1/8/2552 12:50:45)<br />
                    <select>
                          <option>Inappriate content</option>
                          <option>Bug</option>
                          <option>Error</option>
                    </select><br /><br />
                    Topic : <input type="text" title="Some Text"/>
                    <textarea rows="10"; cols="27">Details.....</textarea>
                </td>
            </tr>
        </table>--%>
        รอการทำข้อมูลข้างในจากพี่พายด้วย
    </div>
    <br />
 <div id="gallery" class="ad-gallery">
    <div class="ad-image-wrapper"></div>
    <div>
        <table><tr><td style="margin-top:3px;"><div><img  style="margin-left:500px;" src="/Content/profile/LD.png"</div></td></tr></table>     
    </div>
    <div style="border-bottom-color:#69BA55; border-bottom-style:solid; border-collapse:collapse; border-bottom-width:thin; width:550px; margin-top:27px">
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
    </div>
<% Html.RenderPartial("FriendList"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubMenu"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
<% Html.RenderPartial("photocomment"); %>
</asp:Content>
