<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<fieldset id="el02" style="width:420px">
    <legend style="font-size:smaller;">Cartoon</legend>
    <img src="/Content/images/c1.gif" />
    <br />
    <a onclick="Sys.Mvc.AsyncHyperlink.handleClick(this,new.Sys.UI.DomEvent(event),{insertionMode:Sys.Mvc.InsertionMode.replace,updateTargetID:'content-container'});"href="/Home/Index">See All</a>
 </fieldset>
