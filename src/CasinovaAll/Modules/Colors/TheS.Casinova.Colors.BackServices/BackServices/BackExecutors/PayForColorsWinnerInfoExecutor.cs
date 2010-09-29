using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.BackServices.BackExecutors
{
    public class PayForColorsWinnerInfoExecutor 
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        private double _payFee;

        private IColorsGameDataAccess _dac;
        private IColorsGameDataBackQuery _dqr;
        private IGetPlayerInfoQuery _iGetPlayerInfo;
        private IGetRoundWinnerQuery _iGetRoundWinner;
        private IListBetLogQuery _iListBetLog;
        string _winner;

        public PayForColorsWinnerInfoExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _dac = dac;
            _dqr = dqr;
            _iGetPlayerInfo = dqr;
            _iGetRoundWinner = dqr;
            _iListBetLog = dqr;
            _winner = null;
        }

        //Executor สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก เพื่อส่งข้อมูลกลับไปให้ Web Executor ทำงานต่อไป
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            #region Update balance
            //ดึงข้อมูลยอดเงินของผู้เล่น
            var balance = _iGetPlayerInfo.Get(command);

            //ดึงข้อมูลการลงพนันของผู้เล่นในโต๊ะเกมนั้นๆ
            var betCount = _iListBetLog.List(command);

            //กำหนดเงินที่จะหัก
            if (betCount.Count() > 1) {
                _payFee = 1; 
            } else { 
                _payFee = 5; 
            }

            //หักเงินผู้เล่น
            if (balance >= _payFee) {
                command.PlayerInfo.Balance = balance -= _payFee;
                _dac.ApplyAction(command.PlayerInfo, command);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }

            //บันทึก OnGoingTrackingID สำหรับตรวจสอบการ GetRoundWinner
            _dac.ApplyAction(command.GamePlayInfo, command);

            #endregion Update balance

            //ดึงข้อมูล Winner
             var roundInfo = _iGetRoundWinner.Get(command);

             if (roundInfo.WhitePot >= roundInfo.BlackPot ) {
                 _winner = "White";
             }
             else {
                 _winner = "Black";
             }
        }
    }
}
