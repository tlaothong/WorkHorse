using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.DAL;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลผลการเล่นเกมของ round
    /// </summary>
    public class GetGameResultExecutor
        : SynchronousCommandExecutorBase<GetGameResultCommand>
    {
         private IGetGameResult _iGameResult;

         public GetGameResultExecutor(IColorsGameDataQuery dac)
        {
            _iGameResult = dac;
        }

         protected override void ExecuteCommand(GetGameResultCommand command)
         {
             command.GameResult = _iGameResult.Get(command);                 
         }
    }
}
