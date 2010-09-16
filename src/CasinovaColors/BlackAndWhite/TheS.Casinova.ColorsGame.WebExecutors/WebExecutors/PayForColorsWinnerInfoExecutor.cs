using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;
using TheS.Casinova.ColorsGame.DAL;

namespace TheS.Casinova.ColorsGame.WebExecutors
{
    public class PayForColorsWinnerInfoExecutor
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        //Generate TrackingID
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
