using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sPerf_Web.Areas.Map.Controllers
{
    public partial class MapController : Controller
    {
        //
        // GET: /Map/Map/

        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
