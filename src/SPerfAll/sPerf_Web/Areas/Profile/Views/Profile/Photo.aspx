<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Photo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
  <link  href="../../../../Content/jquery.ad-gallery.css" rel="stylesheet" type="text/css" />
  <link href="../../../../Content/jquery-ui-1.8.8.custom.css" rel="stylesheet" type="text/css" />
  <link href="../../../../Content/jquery.treeview.css" rel="stylesheet" type="text/css" />
  <link href="../../../../Content/context-menu.css" rel="stylesheet" type="text/css" />
  <link href="../../../../Content/drag-drop-folder-tree.css" rel="stylesheet" type="text/css" />
  <link href="../../../../Content/pagination.css" rel="stylesheet" type="text/css" />
  <script src="../../../../Scripts/jquery.min.js" type="text/javascript"></script>
  <script src="../../../../Scripts/jquery-ui.min.js" type="text/javascript"></script>
  <script  src="../../../../Scripts/jquery.ad-gallery.js" type="text/javascript"></script>
  <script src="../../../../Scripts/jquery-ui-1.8.8.custom.min.js" type="text/javascript"></script>
  <script src="../../../../Scripts/jquery.treeview.js" type="text/javascript"></script>
  <script src="../../../../Scripts/jquery.treeview.js" type="text/javascript"></script>
  <script src="../../../../Scripts/ajax.js" type="text/javascript"></script>
  <script src="../../../../Scripts/context-menu.js" type="text/javascript"></script>
  <script src="../../../../Scripts/drag-drop-folder-tree.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.pagination.js" type="text/javascript"></script>
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
   #gallery 
  {
    margin-top:-10px;
    margin-left:30px;
    margin-right:30px;
    margin-bottom:55px;
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
            show: "Transfer",
            hide: "Transfer",
            title: 'Report Problem',
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Send": function () {
                    $(this).dialog("close");
                },
                "Delete": function () {
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
            width: 620,
            zIndex: 1000,
            show: "Transfer",
            hide: "Transfer",
            title: 'Photo Organize',
            buttons: {
                "Exit": function () {
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
<%--script for addphoto--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#showaddphoto").dialog({
            autoOpen: false,
            modal: true,
            width: 620,
            show: "Transfer",
            hide: "Transfer",
            title: 'Add Photo',
            buttons: {
                "Upload": function () {
                    $(this).dialog("close");
                },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $(".addphoto").click(function () {
            $('#showaddphoto').dialog('open');
            return false;
        });
    });
</script>
<%--script for edit photo--%>
<script type="text/javascript">
    $(function () {
        // Dialog
        $("#showeditphoto").dialog({
            autoOpen: false,
            modal: true,
            show: "Transfer",
            hide: "Transfer",
            width: 620,
            title: 'Edit Photo',
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                },
                "Skip": function () {
                    $(this).dialog("close");
                },
                "Save": function () {
                    $(this).dialog("close");
                }
            }
        });
        // Dialog Link
        $(".editphoto").click(function () {
            $('#showeditphoto').dialog('open');
            return false;
        });
    });
</script>
<%--start paging script--%>
<script type="text/javascript">
    function pageselectCallback(page_index, jq) {
        var new_content = jQuery('#hiddenresult div.result:eq(' + page_index + ')').clone();
        $('#Searchresult').empty().append(new_content);
        return false;
    }
    function initPagination() {
        // count entries inside the hidden content
        var num_entries = jQuery('#hiddenresult div.result').length;
        // Create content inside pagination element
        $("#Pagination").pagination(num_entries, {
            callback: pageselectCallback,
            items_per_page: 1 // Show only one item per page
        });
    }
    // When document is ready, initialize pagination
    $(document).ready(function () {
        initPagination();
    });
        </script>
<%--end paging script--%>
<div id="container">
<div style="margin-left:10px;">ToomMy's Album  <select id="switch-effect" style="margin-top:5px;">
                  <option>วันปีใหม่ 2553</option>
                  <option>วันเกิดน้องลิง</option>
                  <option>เที่ยวเมืองไทย</option>
                  <option>เขาใหญ่</option>
                  <option>แล้วแต่จะเพิ่มนะคะ</option>
                    </select><label class="organizes" style="margin-left:40px; color:#808285; background-color:#E7E8E9;padding:2px 4px 2px 4px;border: 1px solid gray;">Organize</label>
    </div>
<div style="margin-left:10px; color:#69BA55;"><input type="checkbox" />Use as display<label class="reportsphotopage" style="text-decoration:underline; color:#69BA55; margin-left:10px">Report</label></div>
<%--div for report dialog--%>
<div id="showReportphotopage" style="display:none;">
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
    <div id="showorganize" style="display:none;">
        <div id="Pagination"style="margin-left:400px;"></div> 
        <br style="clear:both;" />
        <div>    
        <div style="float:left; clear:right; border: 1px solid gray ">
            <div style="color:White; width:200px; margin-left:0px; background-color:#2D2C2C;">Album'name</div>
            <div style="width:200px; height:396px; background-color:#ffffff;">
                 <%--treeview part--%>
                 <%Html.RenderPartial("DGTreeview"); %>
                 <%--end treeview--%>                      
            </div> 
        </div>
        <div style="float:left; margin-left: 5px; border: 1px solid gray ">
            <div style="color:White; width:380px; margin-left:0px; background-color:#2D2C2C;">Album'Picture</div>
            <div id="Searchresult">
                This content will be replaced when pagination inits.
            </div>
            <div id="hiddenresult" style="display:none; ">
                <div class="result" style="background-color:#ffffff; border:0px solid #ffffff; width:380px; height:380px;">
                    <table>
                        <tr style="border:0px solid;">
                          <td  style="background-color:#2D2C2C;" valign="top" align="right"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox6" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox5" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox4" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox13" type="checkbox"></td>

                        </tr>
                        <tr>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                        </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox3" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox2" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox14" type="checkbox"></td>
                          </tr>
                        <tr>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox11" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox9" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox7" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox15" type="checkbox"></td>
                        </tr>
                        <tr>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                        </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox12" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox10" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox8" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox16" type="checkbox"></td>
                          </tr>
                      </table>
                </div>
                <div class="result" style="background-color:#ffffff; border:0px solid #ffffff; width:380px; height:380px;">
                    <table>
                        <tr style="border:0px solid;">
                          <td  style="background-color:#2D2C2C;" valign="top" align="right"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t3.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t4.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t5.jpg" /></td>
                          </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox6" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox5" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox4" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox13" type="checkbox"></td>

                        </tr>
                        <tr>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                        </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox3" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox2" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox14" type="checkbox"></td>
                          </tr>
                        <tr>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t3.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t4.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t5.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t6.jpg" /></td>
                          </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox11" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox9" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox7" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox15" type="checkbox"></td>
                        </tr>
                        <tr>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                        </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox12" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox10" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox8" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox16" type="checkbox"></td>
                          </tr>
                      </table> 
                </div>
                <div class="result" style="background-color:#ffffff; border:0px solid #ffffff; width:380px; height:380px;">
                    <table>
                        <tr style="border:0px solid;">
                          <td  style="background-color:#2D2C2C;" valign="top" align="right"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t7.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t8.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t9.jpg" /></td>
                          </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox6" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox5" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox4" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox13" type="checkbox"></td>

                        </tr>
                        <tr>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t10.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                        </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox3" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox2" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox14" type="checkbox"></td>
                          </tr>
                        <tr>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox11" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox9" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox7" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox15" type="checkbox"></td>
                        </tr>
                        <tr>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t2.jpg" /></td>
                          <td style="background-color:#2D2C2C;"><img src="/Content/profile/thumbs/t1.jpg" /></td>
                        </tr>
                        <tr>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox12" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox10" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox8" type="checkbox"></td>
                          <td valign="top" align="right" style="background-color:#2D2C2C;"><input name="checkbox16" type="checkbox"></td>
                          </tr>
                      </table>
                 </div>
            </div>
            <div style="background-color:White; margin-left:0px;"><label class="addphoto" style="color:Green;">Add Photo</label> | <label class="editphoto" style="color:Green;">Edit Photo</label> | <label style="color:Red;">Delete</label></div>
         </div>
         </div>
    </div>
    <%--div for addphoto dialog--%>
    <div id="showaddphoto" style="display:none;">
      <table>
            <tr>
                <td valign="top">
                    <div style="background-color:#ffffff; width:181px; height:400px;">
                    <table>
                        <tr><td style="color:White; width:500px; margin-left:0px; background-color:#2D2C2C;">Album'name</td></tr>
                        <tr valign="top"><td>
                        <div style="background-color:White; width:174px; height:352px"><textarea cols="31" rows="19"></textarea></div>
                        </td></tr>
                        <tr><td style="color:White; width:500px; background-color:#2D2C2C;"><label style="color:Green;">New Album</label>|<label style="color:Green;">Edit Album</label>|<label style="color:Red;">Delete</label></td></tr>
                    </table>
                    </div>
                </td>
                <td valign="top">
                    <div style="background-color:#ffffff; border:1px solid #ffffff; width:390px; height:400px;">
                    <div style="margin-top:5px;"><label style="border:1px solid Gray; padding:2px 2px 2px 2px;">Add Photo</label></div><br />
                    <div>Album'name : <select style="width:250px; height:20px;"><option>สุดหล่อ</option><option>สุดสวย</option></select></div><br />
                    <div><form action="" method="post" enctype="multipart/form-data"><label for="file">File'name :<input type="file" name="file" id="file" style="width:250px; height:25px;" /></label> <input type="submit" value="upload"  /></form> <br /></div>
                    <div><br /><img src="/Content/images/a.JPG" /></div><br />  
<%--                    <div style="margin-left:300px;"><label style="color:Green;">Upload</label>| <label style="color:Red;">Cancel</label></div>                  
--%>                </div>
                </td>
            </tr>
        </table>
    </div>
    <%--div for editphoto dialog--%>
    <div id="showeditphoto" style="display:none;">
      <table>
            <tr>
                <td valign="top">
                    <div style="background-color:#ffffff; width:181px; height:400px;">
                    <table>
                        <tr><td style="color:White; width:500px; margin-left:0px; background-color:#2D2C2C;">Album'name</td></tr>
                        <tr valign="top"><td>
                        <div style="background-color:White; width:174px; height:352px"><textarea cols="31" rows="19"></textarea></div>
                        </td></tr>
                        <tr><td style="color:White; width:500px; background-color:#2D2C2C;"><label style="color:Green;">New Album</label>|<label style="color:Green;">Edit Album</label>|<label style="color:Red;">Delete</label></td></tr>
                    </table>
                    </div>
                </td>
                <td valign="top">
                    <div style="background-color:#ffffff; border:1px solid #ffffff; width:390px; height:400px;">
                    <div style="margin-top:5px;"><label style="border:1px solid Gray; padding:2px 2px 2px 2px;">Edit Photo</label></div><br />
                    <div><table><tr><td valign="top"><img src="/Content/images/picuser.png" /></td><td valign="top"><select style="width:230px; height:20px;"><option>สุดหล่อ</option><option>สุดสวย</option></select><br />Description :<br /><input type="text" style="width:225px; height:295px;" /></td></tr>
                    </table></div>
<%--                    <div style="margin-left:250px;"><label style="color:Green;">Save</label>| <label style="color:Green;">Skip</label>|<label style="color:Red;">Cancel</label></div>                  
--%>                </div>
                </td>
            </tr>
        </table>
    </div>
    
    <br />
 <div id="gallery" class="ad-gallery">
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
    </div>
    </div>
<% Html.RenderPartial("FriendList"); %>
     <% Html.RenderPartial("Inbox"); %>
     <% Html.RenderPartial("OptionProfile"); %>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubMenu"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
<% Html.RenderPartial("photocomment"); %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="startMenu" runat="server">
<% Html.RenderPartial("StartMenu"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="newsbar" runat="server">
<% Html.RenderPartial("newsBar"); %>
</asp:Content>

