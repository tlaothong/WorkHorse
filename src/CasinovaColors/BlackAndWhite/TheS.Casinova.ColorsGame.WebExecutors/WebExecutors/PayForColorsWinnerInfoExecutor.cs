using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;
using TheS.Casinova.ColorsGame.BackServices;
using ColorsGame.Web;

namespace TheS.Casinova.ColorsGame.WebExecutors
{
    public class PayForColorsWinnerInfoExecutor
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        private IColorsGameBackService _dac;
        private ColorsGameService _svc;

        public PayForColorsWinnerInfoExecutor(IColorsGameBackService dac)
        {
            _dac = dac;
        }

        // ส่ง trackingID ไปยัง BackServer
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            _svc = new ColorsGameService();

            command.GamePlayInformation.OnGoingTrackingID = Guid.Parse(_svc.PayForWinnerInformation(
                command.GamePlayInformation.TableID, 
                command.GamePlayInformation.RoundID));  //เรียก web service เพื่อ get ค่า trackingID

            _dac.PayForWinnerInfo(command); 
        }
    }
}
