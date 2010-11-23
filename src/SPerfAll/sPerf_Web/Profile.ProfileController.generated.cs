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
namespace sPerf_Web.Areas.Profile.Controllers {
    public partial class ProfileController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProfileController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ProfileController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProfileController Actions { get { return MVC.Profile.Profile; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Profile";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Profile";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string SubMenu = "SubMenu";
            public readonly string Profile = "Profile";
            public readonly string Photo = "Photo";
            public readonly string Blog = "Blog";
            public readonly string Archievement = "Archievement";
            public readonly string Friends = "Friends";
            public readonly string Inbox = "Inbox";
            public readonly string Banners = "Banners";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Archievement = "~/Areas/Profile/Views/Profile/Archievement.aspx";
            public readonly string Banners = "~/Areas/Profile/Views/Profile/Banners.ascx";
            public readonly string Blog = "~/Areas/Profile/Views/Profile/Blog.aspx";
            public readonly string Friends = "~/Areas/Profile/Views/Profile/Friends.aspx";
            public readonly string Inbox = "~/Areas/Profile/Views/Profile/Inbox.aspx";
            public readonly string Index = "~/Areas/Profile/Views/Profile/Index.aspx";
            public readonly string Photo = "~/Areas/Profile/Views/Profile/Photo.aspx";
            public readonly string Profile = "~/Areas/Profile/Views/Profile/Profile.aspx";
            public readonly string SubMenu = "~/Areas/Profile/Views/Profile/SubMenu.ascx";
            public readonly string Web = "~/Areas/Profile/Views/Profile/Web.config";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_ProfileController: sPerf_Web.Areas.Profile.Controllers.ProfileController {
        public T4MVC_ProfileController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SubMenu() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SubMenu);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Profile() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Profile);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Photo() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Photo);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Blog() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Blog);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Archievement() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Archievement);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Friends() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Friends);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Inbox() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Inbox);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult photocomment() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Banners);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
