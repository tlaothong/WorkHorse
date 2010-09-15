using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;
using TheS.Casinova.ColorsGame.DAL;

namespace TheS.Casinova.ColorsGame.BackServices.BackExecutors
{
    public class PayForColorsWinnerInfoExecutor
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        private IColorsGameDataAccess _dac;
        private IColorsGameDataBackQuery _dqr;

        //Executor สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก เพื่อส่งข้อมูลกลับไปให้ Web Executor ทำงานต่อไป
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {            
            //หักเงินผู้เล่น
            _dac.ApplyAction(command.PlayerInformation, command);

            //ดึงข้อมูล Winner
            _dqr.Get(command);
            
            //อัพเดทข้อมูล game information
            _dac.ApplyAction(command.GamePlayInformation, command);
        }
    }
}
