using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MvcWebSite.Models.Services;

namespace MvcWebSite.wsv
{
    /// <summary>
    /// Summary description for BasicWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BasicWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public BasicSimpleResponse BasicSimple(BasicSimpleRequest req)
        {
            return new BasicSimpleResponse {
                Message = "RSP: " + req.Message,
            };
        }
    }
}
