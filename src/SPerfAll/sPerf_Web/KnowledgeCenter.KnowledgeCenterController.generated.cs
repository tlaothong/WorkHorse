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
namespace sPerf_Web.Areas.KnowledgeCenter.Controllers {
    public partial class KnowledgeCenterController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public KnowledgeCenterController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected KnowledgeCenterController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public KnowledgeCenterController Actions { get { return MVC.KnowledgeCenter.KnowledgeCenter; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "KnowledgeCenter";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "KnowledgeCenter";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string SubmenuVideo = "SubmenuVideo";
            public readonly string MyVideo = "MyVideo";
            public readonly string PostNewVideo = "PostNewVideo";
            public readonly string Option = "Option";
            public readonly string AdvanceSearch = "AdvanceSearch";
            public readonly string Banners = "Banners";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string AdvanceSearch = "~/Areas/KnowledgeCenter/Views/KnowledgeCenter/AdvanceSearch.ascx";
            public readonly string Banners = "~/Areas/KnowledgeCenter/Views/KnowledgeCenter/Banners.ascx";
            public readonly string Index = "~/Areas/KnowledgeCenter/Views/KnowledgeCenter/Index.aspx";
            public readonly string MyVideo = "~/Areas/KnowledgeCenter/Views/KnowledgeCenter/MyVideo.aspx";
            public readonly string Option = "~/Areas/KnowledgeCenter/Views/KnowledgeCenter/Option.aspx";
            public readonly string PostNewVideo = "~/Areas/KnowledgeCenter/Views/KnowledgeCenter/PostNewVideo.aspx";
            public readonly string SubmenuVideo = "~/Areas/KnowledgeCenter/Views/KnowledgeCenter/SubmenuVideo.ascx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_KnowledgeCenterController: sPerf_Web.Areas.KnowledgeCenter.Controllers.KnowledgeCenterController {
        public T4MVC_KnowledgeCenterController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SubmenuVideo() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SubmenuVideo);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult MyVideo() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.MyVideo);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult PostNewVideo() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.PostNewVideo);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Option() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Option);
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

    }
}

#endregion T4MVC
#pragma warning restore 1591
