using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;
using TheS.Casinova.ColorsGame.BackServices;

namespace TheS.Casinova.ColorsGame.WebExecutors
{
    public class PayForColorsWinnerInfoExecutor
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
         private IColorsGameBackService _dac;

         public PayForColorsWinnerInfoExecutor(IColorsGameBackService dac)
        {
            _dac = dac;
        }

       // Generate TrackingID
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            //command.TrackingID = Guid.NewGuid();
            _dac.PayForWinnerInfo(command);
        }
    }
}
