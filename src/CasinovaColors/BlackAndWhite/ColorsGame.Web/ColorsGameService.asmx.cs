using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;
using TheS.Casinova.ColorsGame.WebExecutors;
using TheS.Casinova.ColorsGame.BackServices;

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
        private PayForColorsWinnerInfoExecutor _svc;
        private IColorsGameBackService _dac;

        public ColorsGameService(IColorsGameBackService dac)
        {
            _dac = dac;
        }
        
        [WebMethod]

        //generate trackingID แล้วส่งข้อมูลกลับไปให้ Client และส่งค่าไปให้ Service เพื่อส่งต่อไปยัง BackServer
        public string PayForWinnerInformation(int tableId, int roundId)
        {           
            string userName = User.Identity.Name;   //ชื่อของผู้ใช้ที่ทำการร้องขอ
            Guid trackingID = Guid.NewGuid();       //สร้าง trackingID

            PayForColorsWinnerInfoCommand cmd = new PayForColorsWinnerInfoCommand {
                PlayerInformation = new PlayerInformation {
                    UserName = userName,
                },
                TableID = tableId,
                RoundID = roundId,
                TrackingID = trackingID,
            };

            _svc = new PayForColorsWinnerInfoExecutor(_dac);
            Action<PayForColorsWinnerInfoCommand> command = (a) => { };

            _svc.Execute(cmd, command);

            return trackingID.ToString();
        }

        [WebMethod]
        public GamePlayInformation[] GetMyGamePlayInfo()
        {
            return new GamePlayInformation[0];
        }
    }
}
