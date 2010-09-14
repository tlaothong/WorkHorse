using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;

namespace TheS.Casinova.ColorsGame.BackServices.BackExecutors
{
    public class PayForColorsWinnerInfoExecutor
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {

        //Executor สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก เพื่อส่งข้อมูลกลับไปให้ Web Executor ทำงานต่อไป
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            //หักเงินผู้เล่น
            //ดึงข้อมูล Winner
            //อัพเดทข้อมูล game information
            throw new NotImplementedException();
        }
    }
}
