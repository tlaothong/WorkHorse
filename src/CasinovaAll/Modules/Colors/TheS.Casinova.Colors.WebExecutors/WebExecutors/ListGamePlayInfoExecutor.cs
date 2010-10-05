using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.WebExecutors
{
    /// <summary>
    /// list ข้อมูลโต๊ะเกมทั้งหมดที่ผู้เล่นลงเดิมพันไว้
    /// </summary>
    public class ListGamePlayInfoExecutor
         : SynchronousCommandExecutorBase<ListGamePlayInfoCommand>
    {
        private IColorsGameDataQuery _dac;

        public ListGamePlayInfoExecutor(IColorsGameDataQuery dac)
        {
            _dac = dac;
        }

        protected override void ExecuteCommand(ListGamePlayInfoCommand command)
        {
            command.GamePlayInfos = _dac.List(command);
        }
    }
}
