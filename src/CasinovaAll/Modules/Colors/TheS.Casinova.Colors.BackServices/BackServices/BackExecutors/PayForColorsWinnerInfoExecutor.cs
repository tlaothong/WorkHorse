using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.Colors.BackServices.BackExecutors
{
    public class PayForColorsWinnerInfoExecutor 
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        private const double _newPayFee = 5;
        private const double _regularyPayFee = 1;

        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private ICreatePlayerActionInfo _iCreatPlayerActionInfo;
        private IUpdateOnGoingTrackingID _iUpdateOnGoingTrackingID;
        private IUpdateRoundWinner _iUpdateRoundWinner;

        private IGetPlayerInfo _iGetPlayerInfo;
        private IListPlayerActionInfoQuery _iListPlayerActionInfo;        
        private IGetRoundInfo _iGetRoundInfo;

        private IDependencyContainer _container;

        private string _winner;

        public PayForColorsWinnerInfoExecutor(IDependencyContainer container, IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _iUpdatePlayerInfoBalance = dac;
            _iUpdateOnGoingTrackingID = dac;
            _iCreatPlayerActionInfo = dac;
            _iUpdateRoundWinner = dac;

            _iGetPlayerInfo = dqr;
            _iGetRoundInfo = dqr;
            _iListPlayerActionInfo = dqr;

            _container = container;

            _winner = null;
        }

        //Executor สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก เพื่อส่งข้อมูลกลับไปให้ Web Executor ทำงานต่อไป
        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            #region Update balance
            //ดึงข้อมูลยอดเงินของผู้เล่น
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.UserName,
            };

            getPlayerInfoCmd.UserProfile = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            //ดึงข้อมูลขอดูสีที่ชนะของผู้เล่นในโต๊ะเกมนั้นๆ
            var betCount = _iListPlayerActionInfo.List(command);

            //กำหนดเงินที่จะหัก
            if (betCount.Count() > 0) {
                command.Amount = _regularyPayFee;
            }
            else { command.Amount = _newPayFee; }

            //ตรวจสอบเงินของผู้เล่นว่าพอลงพนันหรือไม่
            ValidationErrorCollection errorsValidation = new ValidationErrorCollection();
            ValidationHelper.Validate(_container, getPlayerInfoCmd.UserProfile, command, errorsValidation);

            if (errorsValidation.Any()) {
                throw new ValidationErrorException(errorsValidation);
            }

            //หักเงินผู้เล่น
            UpdatePlayerInfoBalanceCommand updateBalanceCmd = new UpdatePlayerInfoBalanceCommand();

            if (getPlayerInfoCmd.UserProfile.NonRefundable < command.Amount) {
                getPlayerInfoCmd.UserProfile.Refundable -= command.Amount - getPlayerInfoCmd.UserProfile.NonRefundable;
                getPlayerInfoCmd.UserProfile.NonRefundable = 0;
            }
            else if (getPlayerInfoCmd.UserProfile.NonRefundable >= command.Amount) {
                getPlayerInfoCmd.UserProfile.NonRefundable -= command.Amount;
            }

            updateBalanceCmd.UserName = command.UserName;

            //หักเงินผู้เล่นตามเงินที่ต้องการลงพนัน
            updateBalanceCmd.NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable;
            updateBalanceCmd.Refundable = getPlayerInfoCmd.UserProfile.Refundable;

            _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updateBalanceCmd);

            //บันทึกข้อมูล PlayerActionInformation
            PlayerActionInformation playerActionInfo = new PlayerActionInformation();

            CreatePlayerActionInfoCommand createPlayerActionInfoCmd = new CreatePlayerActionInfoCommand {
                UserName = playerActionInfo.UserName = command.UserName,
                RoundID = playerActionInfo.RoundID = command.RoundID,
                Amount = playerActionInfo.Amount = command.Amount,
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
