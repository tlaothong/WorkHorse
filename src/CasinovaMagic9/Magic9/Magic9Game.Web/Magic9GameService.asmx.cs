using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Magic9Game.Web
{
    /// <summary>
    /// Summary description for Magic9GameService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Magic9GameService : System.Web.Services.WebService
    {
        private static int _currentBet = 95;

        [WebMethod]
        public int GetNumber()
        {
            return _currentBet++;
        }
    }
}
