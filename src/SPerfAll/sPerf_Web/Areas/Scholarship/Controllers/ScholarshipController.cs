using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sPerf_Web.Areas.Scholarship.Controllers
{
    public partial class ScholarshipController : Controller
    {
        //
        // GET: /Scholarship/Scholarship/

        public virtual ActionResult Index()
        {
            return View();
        }
        public virtual ActionResult SubMenu()
        {
            return View();
        }
        public virtual ActionResult Recieved()
        {
            return View();
        }
        public virtual ActionResult Tournament()
        {
            return View();
        }
        public virtual ActionResult Donate()
        {
            return View();
        }
        public virtual ActionResult Option()
        {
            return View();
        }
    }
}
