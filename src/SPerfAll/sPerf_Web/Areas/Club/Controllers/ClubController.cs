using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sPerf_Web.Areas.Club.Controllers
{
    public partial class ClubController : Controller
    {
        //
        // GET: /Club/Club/

        public virtual ActionResult Index()
        {
            return View();
        }

    }
}
