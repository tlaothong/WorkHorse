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

        [HttpPost]
        public ActionResult Upload(FormCollection collection)
        {
            int numFilesReceived = 0;
            for (int i = 0; i < Brettle.Web.NeatUpload.UploadModule.Files.Count; i++) {
                Brettle.Web.NeatUpload.UploadedFile file = Brettle.Web.NeatUpload.UploadModule.Files[i];
                if (file.IsUploaded) {
                    // Process the files as desired, calling file.MoveTo() if you want to keep it.
                    // This example just counts the files received.
                    numFilesReceived++;
                }
            }

            string redirectPath = String.Format("~/Home/UploadComplete?numFilesReceived={0}&postBackID={1}",
                numFilesReceived, Brettle.Web.NeatUpload.UploadModule.PostBackID);
            return Redirect(redirectPath);
        }

        public ActionResult UploadComplete(int numFilesReceived, string postBackID)
        {
            ViewData["n"] = numFilesReceived;
            ViewData["p"] = postBackID;

            return View();
        }
    }
}
