// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace sPerf_Web.Controllers {
    public partial class HomeController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected HomeController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController Actions { get { return MVC.Home; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Home";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string Today = "Today";
            public readonly string Cartoon = "Cartoon";
            public readonly string AdvanceSearch = "AdvanceSearch";
            public readonly string Banners = "Banners";
            public readonly string SubMenu = "SubMenu";
            public readonly string HightLight = "HightLight";
            public readonly string FAQTutorial = "FAQTutorial";
            public readonly string AboutUs = "AboutUs";
            public readonly string Option = "Option";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string AboutUs = "~/Views/Home/AboutUs.aspx";
            public readonly string AdvanceSearch = "~/Views/Home/AdvanceSearch.ascx";
            public readonly string Banners = "~/Views/Home/Banners.ascx";
            public readonly string Cartoon = "~/Views/Home/Cartoon.ascx";
            public readonly string FAQTutorial = "~/Views/Home/FAQTutorial.aspx";
            public readonly string HightLight = "~/Views/Home/HightLight.aspx";
            public readonly string Index = "~/Views/Home/Index.aspx";
            public readonly string Option = "~/Views/Home/Option.aspx";
            public readonly string SubMenu = "~/Views/Home/SubMenu.ascx";
            public readonly string Today = "~/Views/Home/Today.ascx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_HomeController: sPerf_Web.Controllers.HomeController {
        public T4MVC_HomeController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Today() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Today);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Cartoon() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Cartoon);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult AdvanceSearch() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.AdvanceSearch);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Banners() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Banners);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SubMenu() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SubMenu);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult HightLight() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.HightLight);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult FAQTutorial() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.FAQTutorial);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult AboutUs() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.AboutUs);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Option() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Option);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
