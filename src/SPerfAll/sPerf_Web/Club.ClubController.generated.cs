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
namespace sPerf_Web.Areas.Club.Controllers {
    public partial class ClubController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ClubController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ClubController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ClubController Actions { get { return MVC.Club.Club; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Club";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Club";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string SubMenu = "SubMenu";
            public readonly string NewClub = "NewClub";
            public readonly string OptionClub = "OptionClub";
            public readonly string Banners = "Banners";
            public readonly string AdvanceSearch = "AdvanceSearch";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string AdvanceSearch = "~/Areas/Club/Views/Club/AdvanceSearch.ascx";
            public readonly string Banners = "~/Areas/Club/Views/Club/Banners.ascx";
            public readonly string Index = "~/Areas/Club/Views/Club/Index.aspx";
            public readonly string NewClub = "~/Areas/Club/Views/Club/NewClub.aspx";
            public readonly string OptionClub = "~/Areas/Club/Views/Club/OptionClub.aspx";
            public readonly string SubMenu = "~/Areas/Club/Views/Club/SubMenu.ascx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_ClubController: sPerf_Web.Areas.Club.Controllers.ClubController {
        public T4MVC_ClubController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SubMenu() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SubMenu);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult NewClub() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.NewClub);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult OptionClub() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.OptionClub);
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
