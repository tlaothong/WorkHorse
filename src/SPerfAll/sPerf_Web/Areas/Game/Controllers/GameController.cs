﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sPerf_Web.Areas.Game.Controllers
{
    public partial class GameController : Controller
    {
        //
        // GET: /Game/Game/

        public virtual ActionResult Index()
        {
            return View();
        }
        public virtual ActionResult SubMenu()
        {
            return View();
        }
        public virtual ActionResult Tournament()
        {
            return View();
        }
        public virtual ActionResult Upload()
        {
            return View();
        }
        public virtual ActionResult GameOption()
        {
            return View();
        }
        public virtual ActionResult AdvanceSearch()
        {
            return View();
        }
        public virtual ActionResult Banners()
        {
            return View();
        }
    }
}
