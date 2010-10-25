using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    /// list ข้อมูลโต๊ะเกมทั้งหมดที่ผู้เล่นลงเดิมพันไว้
    /// </summary>
    public class ListGamePlayInfoExecutor
         : SynchronousCommandExecutorBase<ListGamePlayInfoCommand>
    {
        private IListGamePlayInformation _iListGamePlayInfo;

        public ListGamePlayInfoExecutor(IColorsGameDataQuery dac)
        {
            _iListGamePlayInfo = dac;
        }

        protected override void ExecuteCommand(ListGamePlayInfoCommand command)
        {
            //ตรวจสอบค่า username ว่ามีหรือไม่
           command.GamePlayInfos = _iListGamePlayInfo.List(command);
           
        }
    }
}
