﻿using System;
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

        private IPayForColorsWinnerInfo _iPayForColorsWinnerInfo;
        private ICreatePlayerActionInfo _iCreatPlayerActionInfo;
        private IUpdateOnGoingTrackingID _iUpdateOnGoingTrackingID;

        private IGetPlayerInfoQuery _iGetPlayerInfo;
        private IListPlayerActionInfoQuery _iListPlayerActionInfo;        
        private IGetGameRoundInfoQuery _iGetGameRoundInfo;

        private string _winner;
        private PlayerActionInformation _playerActionInfo;

        public PayForColorsWinnerInfoExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _iPayForColorsWinnerInfo = dac;
            _iUpdateOnGoingTrackingID = dac;
            _iCreatPlayerActionInfo = dac;

            _iGetPlayerInfo = dqr;
            _iGetGameRoundInfo = dqr;
            _iListPlayerActionInfo = dqr;

            _winner = null;
        }

        //Executor สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก เพื่อส่งข้อมูลกลับไปให้ Web Executor ทำงานต่อไป
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            #region Update balance
            //ดึงข้อมูลยอดเงินของผู้เล่น
            var balance = _iGetPlayerInfo.Get(command);

            //ดึงข้อมูลการลงพนันของผู้เล่นในโต๊ะเกมนั้นๆ
            var betCount = _iListPlayerActionInfo.List(command);

            //กำหนดเงินที่จะหัก
            if (betCount.Count() > 1) {
                _payFee = 1; 
            } else { 
                _payFee = 5; 
            }

            //หักเงินผู้เล่น
            if (balance >= _payFee) {
                command.PlayerInfo.Balance = balance -= _payFee;
                _iPayForColorsWinnerInfo.ApplyAction(command.PlayerInfo, command);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }

             //บันทึกข้อมูล GamePlayInfo
            _playerActionInfo = new PlayerActionInformation {
                RoundID = command.GameRoundInfo.RoundID,
                UserName = command.PlayerInfo.UserName, 
                ActionType = "GetWinner",               
                Amount = _payFee,
            };
            _iCreatPlayerActionInfo.Create(_playerActionInfo, command);

            //บันทึก OnGoingTrackingID สำหรับตรวจสอบการ GetRoundWinner
            _iUpdateOnGoingTrackingID.ApplyAction(command.GamePlayInfo, command);
            
            #endregion Update balance

            //ดึงข้อมูล Winner
             var roundInfo = _iGetGameRoundInfo.Get(command);

             if (roundInfo.WhitePot >= roundInfo.BlackPot ) {
                 _winner = "White";
             }
             else {
                 _winner = "Black";
             }

        }
    }
}
