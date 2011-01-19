<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<table>
    <tbody>
        <tr>
            <td>
                <div style="margin-left:25px;"><%=Html.ActionLink("MAYA TAKKY",MVC.Game.Game.Index()) %></div>
                <br />
                <div style="margin-left:25px;">
                    <img id="mayatakky" src="/Content/images/mayatakky.png" style="border-width: 0px;" />
                </div>
                <table>
                    <tr>
                        <td>
                เตรียมสนุกกับ MAYA TAKKY<br />
                <br /><label>
                    --------------------------------------
                </label></td>
                    </tr>
                </table>
                
            </td>
        </tr>
        <tr>
            <td>
                <div style="margin-left:25px;"><%=Html.ActionLink("MY AVATAR",MVC.Home.Index()) %></div>
                <br />
                <div style="margin-left:25px;">
                    <img id="avatar" src="/Content/images/avatar.png" style="border-width: 0px;" />
                </div>
                <table>
                    <tr>
                        <td>
                            สนุกกับตัวแทนของคุณ<br />
                            เพิ่มความฉลาดให้เขา<br />
                            <label>
                                --------------------------------------
                            </label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                <tr>
            <td>
                <div style="margin-left:25px;"><%=Html.ActionLink("Video",MVC.KnowledgeCenter.KnowledgeCenter.Index()) %></div>
                <br />
                <div style="margin-left:25px;">
                    <img id="video" src="/Content/images/video.png" style="border-width: 0px;" />
                </div>
                <table>
                    <tr>
                        <td>
                            มากมายด้วยคลิปวิดีโอมาดูกันเลย<br />
                            <label>
                                --------------------------------------
                            </label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </tbody>
</table>