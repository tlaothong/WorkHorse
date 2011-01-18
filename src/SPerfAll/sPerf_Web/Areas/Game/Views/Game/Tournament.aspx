<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Tournament
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../../../Scripts/quickpager.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("ul.paging").quickPager();
            $("ul.paging").fadeOut("medium");
            $("ul.paging").fadeIn("medium");
            $("ul.paging")
            // Animate
			.find("ul.paging").fadeIn(4000).end()
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
        });
        

    </script>
    <style type="text/css">
        ul.paging li, ul.paging2 li
        {
            background: #83bd63;
            color: #fff;
            line-height: 1;
            width: 530px;
            margin-bottom: 1px;
            padding: 5px;
        }
        
        ul.red
        {
            outline: 10px solid red;
        }
        
        ul.simplePagerNav li
        {
            display: block;
            float: left;
            padding: 3px;
            margin-bottom: 10px;
            font-family: georgia;
        }
        
        ul.simplePagerNav li a
        {
            color: #333;
            text-decoration: none;
        }
        
        li.currentPage
        {
            background: red;
            background: #83bd63;
        }
        
        ul.simplePagerNav li.currentPage a
        {
            color: #fff;
        }
        
        table.pageme
        {
            border-collapse: collapse;
            border: 1px solid #ccc;
        }
        
        table.pageme td
        {
            border-collapse: collapse;
            border: 1px solid #ccc;
        }
        
        ul.paging li.sticky
        {
            background-color: red !important;
            display: block !important;
        }
    </style>
    <%--directory path--%>
    <table>
        <tbody>
            <tr>
                <td>
                    <a href="/Home">Home</a>
                </td>
                <td>
                    >
                </td>
                <td>
                    <a href="/Game">Game</a>
                </td>
                <td>
                    >
                </td>
                <td>
                    Tournament
                </td>
            </tr>
        </tbody>
    </table>
    <div id="paging">
        <ul class="paging">
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            <a href="/Game/Game/PlayGame">
                                <img src="../../../../Content/images/mayatakky.png" /></a>
                        </td>
                        <td>
                            <div>
                                <h2>
                                    MaYA TaKKy</h2>
                            </div>
                            <div>
                                เกมส์แนวใหม่ที่ใครๆ ก็อยากเล่น สนุกสนานปนความรู้ เล่นแล้วรับรองติดใจไม่แพ้เกมส์อื่น
                                ใครต้องการเป็นเจ้าของคลิกเลย
                            </div>
                            <div style="padding-top: 20px">
                                <div style="float: left; padding-right: 5px">
                                    <input type="checkbox" class="toggle1" />
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <label>
                                        UnLike</label>
                                </div>
                                <div style="float: left; padding-right: 5px">
                                    <button class="bookmark" type="button">
                                        Bookmark</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
    <% Html.RenderPartial("SubMenu"); %>
    <% Html.RenderPartial("Upload"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
    <% Html.RenderPartial("AdvanceSearch"); %>
    <% Html.RenderPartial("Banners"); %>
</asp:Content>
