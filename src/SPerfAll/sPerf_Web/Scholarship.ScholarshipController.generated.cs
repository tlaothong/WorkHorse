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
namespace sPerf_Web.Areas.Scholarship.Controllers {
    public partial class ScholarshipController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ScholarshipController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ScholarshipController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ScholarshipController Actions { get { return MVC.Scholarship.Scholarship; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Scholarship";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Scholarship";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string SubMenu = "SubMenu";
            public readonly string Recieved = "Recieved";
            public readonly string Tournament = "Tournament";
            public readonly string Donate = "Donate";
            public readonly string Option = "Option";
            public readonly string Banners = "Banners";
            public readonly string AdvanceSearch = "AdvanceSearch";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string AdvanceSearch = "~/Areas/Scholarship/Views/Scholarship/AdvanceSearch.ascx";
            public readonly string Banners = "~/Areas/Scholarship/Views/Scholarship/Banners.ascx";
            public readonly string Donate = "~/Areas/Scholarship/Views/Scholarship/Donate.aspx";
            public readonly string Index = "~/Areas/Scholarship/Views/Scholarship/Index.aspx";
            public readonly string Option = "~/Areas/Scholarship/Views/Scholarship/Option.aspx";
            public readonly string Recieved = "~/Areas/Scholarship/Views/Scholarship/Recieved.aspx";
            public readonly string SubMenu = "~/Areas/Scholarship/Views/Scholarship/SubMenu.ascx";
            public readonly string Tournament = "~/Areas/Scholarship/Views/Scholarship/Tournament.aspx";
            public readonly string Web = "~/Areas/Scholarship/Views/Scholarship/Web.config";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_ScholarshipController: sPerf_Web.Areas.Scholarship.Controllers.ScholarshipController {
        public T4MVC_ScholarshipController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SubMenu() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SubMenu);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Recieved() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Recieved);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Tournament() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Tournament);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Donate() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Donate);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Option() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Option);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Banners() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Banners);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult AdvanceSearch() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.AdvanceSearch);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
