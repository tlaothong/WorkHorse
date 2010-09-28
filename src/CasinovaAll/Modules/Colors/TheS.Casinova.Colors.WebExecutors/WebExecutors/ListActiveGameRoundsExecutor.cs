using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.CommandPattern;

namespace TheS.Casinova.Colors.WebExecutors
{
    public class ListActiveGameRoundsExecutor
        : SynchronousCommandExecutorBase<ListActiveGameRoundsCommand>
    {
         private IColorsGameDataQuery _dac;

         public ListActiveGameRoundsExecutor(IColorsGameDataQuery dac)
        {
            _dac = dac;
        }

        //List โต๊ะเกมที่ active
         protected override void ExecuteCommand(ListActiveGameRoundsCommand command)
         {
             command.ActiveRounds = _dac.List(new ListActiveGameRoundsCommand {
                 FromTime = DateTime.Now
             });
         }
    }
}
