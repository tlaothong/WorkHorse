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
            double playerBalance;

            #region Update balance
            //ดึงข้อมูลยอดเงินของผู้เล่น
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.UserName,
            };

            getPlayerInfoCmd.UserProfile = _iGetPlayerInfo.Get(getPlayerInfoCmd);
            playerBalance = getPlayerInfoCmd.UserProfile.NonRefundable + getPlayerInfoCmd.UserProfile.Refundable;

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
            UpdatePlayerInfoBalanceCommand updateBalanceCmd = new UpdatePlayerInfoBalanceCommand();

            if (getPlayerInfoCmd.UserProfile.NonRefundable < _payFee) {
                getPlayerInfoCmd.UserProfile.Refundable -= _payFee - getPlayerInfoCmd.UserProfile.NonRefundable;
                getPlayerInfoCmd.UserProfile.NonRefundable = 0;

                updateBalanceCmd.UserName = command.UserName;

                //หักเงินผู้เล่นตามเงินที่ต้องการลงพนัน
                updateBalanceCmd.NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable;
                updateBalanceCmd.Refundable = getPlayerInfoCmd.UserProfile.Refundable;

                _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updateBalanceCmd);
            }
            else if (getPlayerInfoCmd.UserProfile.NonRefundable >= _payFee) {
                getPlayerInfoCmd.UserProfile.NonRefundable -= _payFee;

                updateBalanceCmd.UserName = command.UserName;

                //หักเงินผู้เล่นตามเงินที่ต้องการลงพนัน
                updateBalanceCmd.NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable;
                updateBalanceCmd.Refundable = getPlayerInfoCmd.UserProfile.Refundable;

                _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updateBalanceCmd);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }

            //if (playerBalance >= _payFee) {
            //    playerBalance -= _payFee;

            //    PlayerInformation playerInfo = new PlayerInformation();

            //    UpdatePlayerInfoBalanceCommand updatePlayerInfoBalanceCmd = new UpdatePlayerInfoBalanceCommand {
            //        UserName = playerInfo.UserName = getPlayerInfoCmd.PlayerInfo.UserName,
            //        Balance = playerInfo.Balance = getPlayerInfoCmd.PlayerInfo.Balance,
            //    };

            //    _iUpdatePlayerInfoBalance.ApplyAction(playerInfo, updatePlayerInfoBalanceCmd);
            //}
            //else {
            //    Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            //}

            //บันทึกข้อมูล PlayerActionInformation
            PlayerActionInformation playerActionInfo = new PlayerActionInformation();

            CreatePlayerActionInfoCommand createPlayerActionInfoCmd = new CreatePlayerActionInfoCommand {
                UserName = playerActionInfo.UserName = command.UserName,
                RoundID = playerActionInfo.RoundID = command.RoundID,
                Amount = playerActionInfo.Amount = _payFee,
                ActionType = playerActionInfo.ActionType = "GetWinner",
            };

            _iCreatPlayerActionInfo.Create(playerActionInfo, createPlayerActionInfoCmd);

            //บันทึก OnGoingTrackingID สำหรับตรวจสอบการ GetRoundWinner
            GamePlayInformation gamePlayInfo = new GamePlayInformation();

            UpdateOnGoingTrackingIDCommand updateOnGoingTrackingIDCmd = new UpdateOnGoingTrackingIDCommand {
                    RoundID = gamePlayInfo.RoundID = command.RoundID,
                    UserName = gamePlayInfo.UserName = command.UserName,
                    OnGoingTrackingID = gamePlayInfo.OnGoingTrackingID = command.OnGoingTrackingID,
            };

            _iUpdateOnGoingTrackingID.ApplyAction(gamePlayInfo, updateOnGoingTrackingIDCmd);

            #endregion Update balance

            #region Get round winner

            //ดึงข้อมูล Winner
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { 
                RoundID = command.RoundID
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
                    RoundID = gamePlayInfoForComplete.RoundID = command.RoundID,
                    UserName = gamePlayInfoForComplete.UserName = command.UserName,
                    Winner = gamePlayInfoForComplete.Winner = _winner,
                    TrackingID = gamePlayInfoForComplete.TrackingID = command.OnGoingTrackingID,
                    LastUpdate = gamePlayInfoForComplete.LastUpdate = DateTime.Now,
            };
            
            //บันทึกข้อมูล Winner และ TrackingID ที่ผู้เล่นร้องขอ
            _iUpdateRoundWinner.ApplyAction(gamePlayInfoForComplete, updateRoundWinnerCmd);

            #endregion Update game play information
        }
    }
}
