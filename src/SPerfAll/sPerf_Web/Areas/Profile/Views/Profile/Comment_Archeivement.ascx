<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script language="javascript" type="text/javascript">
    function showHide(shID) {
        if (document.getElementById(shID)) {
            if (document.getElementById(shID + '-show').style.display != 'none') {
                document.getElementById(shID + '-show').style.display = 'none';
                document.getElementById(shID).style.display = 'block';
            }
            else {
                document.getElementById(shID + '-show').style.display = 'inline';
                document.getElementById(shID).style.display = 'none';
            }
        }
    }
</script>
<style type="text/css">
    /* This CSS is just for presentational purposes. */
    #listContent
    {
        margin-top: 20px;
    }
    #wrap
    {
        font: 1.3em/1.3 Arial, Helvetica, sans-serif;
        width: 30em;
        margin: 0 auto;
        padding: 1em;
        background-color: #fff;
    }
    h1
    {
        font-size: 200%;
    }
    
    /* This CSS is used for the Show/Hide functionality. */
    .more
    {
        display: none;
    }
    a.showLink, a.hideLink
    {
        text-decoration: none;
        color: #36f;
        padding-left: 8px;
        background: transparent url(down.gif) no-repeat left;
    }
    a.hideLink
    {
        background: transparent url(up.gif) no-repeat left;
    }
    a.showLink:hover, a.hideLink:hover
    {
        border-bottom: 1px dotted #36f;
    }
</style>
<div style="margin: 10px 5px 10px 5px;">
    <label id="Comment_Archeivement" style="border: 2px solid gray; color: #5FB546; padding: 1px 2px 1px 2px;
        float: left;">
        Comment
    </label>
    <label style="color: Gray; float: left; margin-left: 5px;">
        (152)</label><div>
            <a href="#" style="color: Gray; margin-left: 40px;">SeeAll</a></div>
</div>
<div id="listContent">
    <div style="width: 159; height: 400px;">
        <div style="border-bottom: 1px solid #D2D5D2; margin-bottom: 5px; padding-bottom: 5px;
            margin-left: 5px;">
        </div>
        <div style="margin-bottom: 5px; padding-bottom: 5px; width: 159px; margin-left: 5px;
            border-bottom: 1px solid #D2D5D2; float: left;">
            <table>
                <tr>
                    <td>
                        <img src="/Content/Profile/pic_friend/1.png" alt="" />
                    </td>
                    <td valign="top">
                        <div>
                            nanny</div>
                    </td>
                </tr>
            </table>
            <div style="width: 120px; float: left;">
                (1 day ago) danm fantasic nice
            </div>
            <div style="width: 30px; float: right;">
                <a href="#" style="color: gray; text-decoration: none;">report</a>
            </div>
        </div>
        <div style="margin-bottom: 5px; padding-bottom: 5px; width: 159px; margin-left: 5px;
            border-bottom: 1px solid #D2D5D2; float: left; clear: left;">
            <table>
                <tr>
                    <td>
                        <img src="/Content/Profile/pic_friend/2.png" alt="" />
                    </td>
                    <td valign="top">
                        <label>
                            Bua Kornkanok</label>
                    </td>
                </tr>
            </table>
            <div style="width: 120px; float: left;">
                (1 day ago) Not funny, and they from Aqua Teen HuForce
            </div>
            <div style="width: 30px; float: right;">
                <a href="#" style="float: right; color: gray; text-decoration: none;">report</a>
            </div>
        </div>
        <a href="#" id="example-show" class="showLink" onclick="showHide('example');return false;">
            SeeMore...</a>
        <div id="example" class="more showLink">
            <div style="margin-bottom: 5px; padding-bottom: 5px; width: 159px; margin-left: 5px;
                border-bottom: 1px solid #D2D5D2; float: left; clear: left;">
                <table>
                    <tr>
                        <td>
                            <img src="/Content/Profile/pic_friend/3.png" alt="" />
                        </td>
                        <td valign="top">
                            <label>
                                โอ่งเหลือง เห็ดม่อ</label>
                        </td>
                    </tr>
                </table>
                <div style="width: 120px; float: left;">
                    (17 hours ago) which joke woz dat?
                </div>
                <div style="width: 30px; float: right;">
                    <a href="#" style="float: right; color: gray; text-decoration: none;">report</a>
                </div>
            </div>
            <div style="margin-bottom: 5px; padding-bottom: 5px; width: 159px; margin-left: 5px;
                border-bottom: 1px solid #D2D5D2; float: left; clear: left;">
                <table>
                    <tr>
                        <td>
                            <img src="/Content/Profile/pic_friend/4.png" alt="" />
                        </td>
                        <td valign="top">
                            <label>
                                This Lovestory</label>
                        </td>
                    </tr>
                </table>
                <div style="width: 120px; float: left;">
                    (1 day ago) this sucked
                </div>
                <div style="width: 30px; float: right;">
                    <a href="#" style="float: right; color: gray; text-decoration: none;">report</a>
                </div>
            </div>
            <div style="margin-bottom: 5px; padding-bottom: 5px; width: 159px; margin-left: 5px;
                border-bottom: 1px solid #D2D5D2; float: left; clear: left;">
                <table>
                    <tr>
                        <td>
                            <img src="/Content/Profile/pic_friend/5.png" alt="" /><br />
                        </td>
                        <td valign="top">
                            <label>
                                Peemai Shr</label>
                        </td>
                    </tr>
                </table>
                <div style="width: 120px; float: left;">
                    (1 day ago) this sucked
                </div>
                <div style="width: 30px; float: right;">
                    <a href="#" style="float: right; color: gray; text-decoration: none;">report</a>
                </div>
                <a href="#" id="example-hide" class="hideLink" onclick="showHide('example');return false;">
                    Hide this content.</a>
            </div>
        </div>
    </div>
</div>
