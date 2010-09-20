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

        const int _payFee = 5;

        public PayForColorsWinnerInfoExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _dac = dac;
            _dqr = dqr;
        }

        //Executor สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก เพื่อส่งข้อมูลกลับไปให้ Web Executor ทำงานต่อไป
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {            
            //หักเงินผู้เล่น
            if (command.PlayerInformation.Balance >= _payFee) {
                command.PlayerInformation.Balance -= _payFee;
                _dac.ApplyAction(command.PlayerInformation, command);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }

            //ดึงข้อมูล Winner
            command.GamePlayInformation.Winner = _dqr.Get(command);
            
            ////อัพเดทข้อมูล game information
            command.GamePlayInformation.LastUpdate = DateTime.Now;
            _dac.ApplyAction(command.GamePlayInformation, command);
        }
    }
}
