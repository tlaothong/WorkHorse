using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.DAL;

namespace TheS.Casinova.Colors.BackServices.BackExecutors
{
    public class PayForColorsWinnerInfoExecutor 
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        const int _payFee = 5;

        private IColorsGameDataAccess _dac;
        private IColorsGameDataBackQuery _dqr;

        public PayForColorsWinnerInfoExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _dac = dac;
            _dqr = dqr;
        }

        //Executor สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก เพื่อส่งข้อมูลกลับไปให้ Web Executor ทำงานต่อไป
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            //หักเงินผู้เล่น
            if (command.PlayerInfo.Balance >= _payFee) {
                command.PlayerInfo.Balance -= _payFee;
                _dac.ApplyAction(command.PlayerInfo, command);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }

            //บันทึก OnGoingTrackingID สำหรับตรวจสอบการ GetRoundWinner
            _dac.ApplyAction(command.GamePlayInfo, command);

            //ดึงข้อมูล Winner
            command.GamePlayInfo.Winner = _dqr.Get(command);
        }
    }
}
