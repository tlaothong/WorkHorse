using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sPerf_Web.Areas.KnowledgeCenter.Controllers
{
    public partial class KnowledgeCenterController : Controller
    {
        //
        // GET: /KnowledgeCenter/KnowledgeCenter/

        public virtual ActionResult Index()
        {
            return View();
        }

    }
}
