using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TheS.Casinova.ColorsGame.Models;

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
        //generate trackingID แล้วส่งข้อมูลกลับไปให้ Client และส่งค่าไปให้ Service เพื่อส่งต่อไปยัง BackServer
        [WebMethod]
        public string PayForWinnerInformation(int tableId, int roundId)
        {
                string userName = "nit";  // User.Identity.Name; //username ของผู้ใช้ที่กำลัง logon
                string TrackingID = Guid.NewGuid().ToString("N");

                // return "ticket";
                return TrackingID;       
        }

        [WebMethod]
        public GamePlayInformation[] GetMyGamePlayInfo()
        {
            return new GamePlayInformation[0];
        }
    }
}
