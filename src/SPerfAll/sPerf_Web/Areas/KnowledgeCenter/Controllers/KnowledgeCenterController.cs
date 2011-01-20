using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
        public virtual ActionResult SubmenuVideo()
        {
            return View();
        }
        public virtual ActionResult MyVideo()
        {
            return View();
        }
        public virtual ActionResult Option()
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
        public virtual ActionResult PostNewVideos()
        {
            return View();
        }
        public virtual ActionResult PlayVideo()
        {
            return View();
        }
        public virtual ActionResult newsBar()
        {
            return View();
        }
        public virtual ActionResult FilterVideo()
        {
            return View();
        }
        public virtual ActionResult ListVideo()
        {
            return View();
        }
        [HttpPost]
        public virtual ActionResult UploadVideo(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                file.SaveAs(fileName);
            }

            return RedirectToAction("Index");
        }


    }
}
