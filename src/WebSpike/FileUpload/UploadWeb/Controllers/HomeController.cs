using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadWeb.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult UploadComplete(int numFilesReceived, string postBackID)
        {
            ViewData["n"] = numFilesReceived;
            ViewData["p"] = postBackID;

            return View();
        }
    }
}
