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

        /// <summary>
        /// list ข้อมูลโต๊ะเกมที่ active
        /// </summary>
         protected override void ExecuteCommand(ListActiveGameRoundsCommand command)
         {
             command.FromTime = DateTime.Now;
             command.ActiveRounds = _dac.List(command);
         }
    }
}
