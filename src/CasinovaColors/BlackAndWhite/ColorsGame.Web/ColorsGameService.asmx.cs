using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;

namespace ColorsGame.Web
{
    /// <summary>
    /// Summary description for ColorsGameService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ColorsGameService : System.Web.Services.WebService
    {

        [WebMethod]
        public string PayForWinnerInformation(int tableId, int roundId)
        {
            string userName = User.Identity.Name;
            // return "ticket";
            return Guid.NewGuid().ToString("N");
        }

        [WebMethod]
        public GamePlayInformation[] GetMyGamePlayInfo()
        {
            return new GamePlayInformation[0];
        }
    }
}
