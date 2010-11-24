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

        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private ICreatePlayerActionInfo _iCreatPlayerActionInfo;
        private IUpdateOnGoingTrackingID _iUpdateOnGoingTrackingID;
        private IUpdateRoundWinner _iUpdateRoundWinner;

        private IGetPlayerInfo _iGetPlayerInfo;
        private IListPlayerActionInfoQuery _iListPlayerActionInfo;        
        private IGetRoundInfo _iGetRoundInfo;

        private string _winner;

        public PayForColorsWinnerInfoExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _iUpdatePlayerInfoBalance = dac;
            _iUpdateOnGoingTrackingID = dac;
            _iCreatPlayerActionInfo = dac;
            _iUpdateRoundWinner = dac;

            _iGetPlayerInfo = dqr;
            _iGetRoundInfo = dqr;
            _iListPlayerActionInfo = dqr;

            _winner = null;
        }

        //Executor สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก เพื่อส่งข้อมูลกลับไปให้ Web Executor ทำงานต่อไป
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            #region Update balance
            //ดึงข้อมูลยอดเงินของผู้เล่น
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.PlayerActionInfo.UserName,
            };

            getPlayerInfoCmd.PlayerInfo = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            //ดึงข้อมูลการลงพนันของผู้เล่นในโต๊ะเกมนั้นๆ
            var betCount = _iListPlayerActionInfo.List(command);

            //กำหนดเงินที่จะหัก
            if (betCount.Count() >= 1) {
                _payFee = 1;
            }
            else {
                _payFee = 5;
            }

            //หักเงินผู้เล่น
            if (getPlayerInfoCmd.PlayerInfo.Balance >= _payFee) {
                getPlayerInfoCmd.PlayerInfo.Balance -= _payFee;

                PlayerInformation playerInfo = new PlayerInformation();

                UpdatePlayerInfoBalanceCommand updatePlayerInfoBalanceCmd = new UpdatePlayerInfoBalanceCommand {
                    UserName = playerInfo.UserName = getPlayerInfoCmd.PlayerInfo.UserName,
                    Balance = playerInfo.Balance = getPlayerInfoCmd.PlayerInfo.Balance,
                };

                _iUpdatePlayerInfoBalance.ApplyAction(playerInfo, updatePlayerInfoBalanceCmd);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }

            //บันทึกข้อมูล PlayerActionInformation

            PlayerActionInformation playerActionInfo = new PlayerActionInformation();

            CreatePlayerActionInfoCommand createPlayerActionInfoCmd = new CreatePlayerActionInfoCommand {
                UserName = playerActionInfo.UserName = command.PlayerActionInfo.UserName,
                RoundID = playerActionInfo.RoundID = command.PlayerActionInfo.RoundID,
                Amount = playerActionInfo.Amount = _payFee,
                ActionType = playerActionInfo.ActionType = "GetWinner",
            };

            _iCreatPlayerActionInfo.Create(playerActionInfo, createPlayerActionInfoCmd);

            //บันทึก OnGoingTrackingID สำหรับตรวจสอบการ GetRoundWinner
            GamePlayInformation gamePlayInfo = new GamePlayInformation();

            UpdateOnGoingTrackingIDCommand updateOnGoingTrackingIDCmd = new UpdateOnGoingTrackingIDCommand {
                PlayerActionInfo = new PlayerActionInformation {
                    RoundID = gamePlayInfo.RoundID = command.PlayerActionInfo.RoundID,
                    UserName = gamePlayInfo.UserName = command.PlayerActionInfo.UserName,
                    TrackingID = gamePlayInfo.OnGoingTrackingID = command.OnGoingTrackingID,
                }
            };

            _iUpdateOnGoingTrackingID.ApplyAction(gamePlayInfo, updateOnGoingTrackingIDCmd);

            #endregion Update balance

            #region Get round winner

            //ดึงข้อมูล Winner
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { 
                RoundID = command.PlayerActionInfo.RoundID
            };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            if (getRoundInfoCmd.RoundInfo.WhitePot <= getRoundInfoCmd.RoundInfo.BlackPot) {
                _winner = "White";
            }
            else {
                _winner = "Black";
            }

            #endregion Get round winner

            #region Update game play information

            GamePlayInformation gamePlayInfoForComplete = new GamePlayInformation();

            UpdateRoundWinnerCommand updateRoundWinnerCmd = new UpdateRoundWinnerCommand {
                PlayerActionInfo = new PlayerActionInformation {
                    RoundID = gamePlayInfoForComplete.RoundID = command.PlayerActionInfo.RoundID,
                    UserName = gamePlayInfoForComplete.UserName = command.PlayerActionInfo.UserName,
                },
                    Winner = gamePlayInfoForComplete.Winner = _winner,
                    TrackingID = gamePlayInfoForComplete.TrackingID = command.OnGoingTrackingID,
                    LastUpdate = gamePlayInfoForComplete.WinnerLastUpdate = DateTime.Now,
            };
            
            //บันทึกข้อมูล Winner และ TrackingID ที่ผู้เล่นร้องขอ
            _iUpdateRoundWinner.ApplyAction(gamePlayInfoForComplete, updateRoundWinnerCmd);

            #endregion Update game play information
        }
    }
}
