using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.BackServices.BackExecutors;
using TheS.Casinova.PlayerProfile.Commands;

namespace TheS.Casinova.MagicNine.BackServices.BackExecutors
{
    public class SingleBetExecutor
        : SynchronousCommandExecutorBase<SingleBetCommand>
    {
        private ISingleBet _iSingleBet;
        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private IUpdateGameRoundPot _iUpdateGameRoundPot;

        private IGetGameRoundPot _iGetGameRoundPot;
        private IGetPlayerInfo _iGetPlayerInfo;
        private IGetGameRoundInfo _iGetGameRoundInfo;

        private IDependencyContainer _container;

        private ReturnRewardExecutor _returnRewardEx;

        private const double _betFee = 1;

        public SingleBetExecutor(ReturnRewardExecutor ex, IDependencyContainer container, IMagicNineGameDataAccess dac, IMagicNineGameDataBackQuery dqr)
        {
            _iSingleBet = dac;
            _iUpdatePlayerInfoBalance = dac;
            _iUpdateGameRoundPot = dac;

            _iGetPlayerInfo = dqr;
            _iGetGameRoundPot = dqr;
            _iGetGameRoundInfo = dqr;

            _container = container;
            _returnRewardEx = ex;
        }

        protected override void ExecuteCommand(SingleBetCommand command)
        {
            //กำหนดจำนวนที่ลงเงินพนัน
            command.BetInfo.Amount = _betFee;
            int modWinner = -1;

            //ดึงข้อมูลชิฟของผู้เล่น
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.BetInfo.UserName,
            };
            getPlayerInfoCmd.UserProfile = _iGetPlayerInfo.Get(getPlayerInfoCmd);
            
            ValidationErrorCollection errorsValidation = new ValidationErrorCollection();
            ValidationHelper.Validate(_container, getPlayerInfoCmd.UserProfile, command, errorsValidation);

            if (errorsValidation.Any()) {
                throw new ValidationErrorException(errorsValidation);
            }

            //หักชิฟของผู้เล่น
            if (getPlayerInfoCmd.UserProfile.NonRefundable < command.BetInfo.Amount) {
                getPlayerInfoCmd.UserProfile.Refundable -= command.BetInfo.Amount - getPlayerInfoCmd.UserProfile.NonRefundable;
                getPlayerInfoCmd.UserProfile.NonRefundable = 0;

                command.BetInfo.BonusChips = getPlayerInfoCmd.UserProfile.NonRefundable;
                command.BetInfo.Chips = command.BetInfo.Amount - getPlayerInfoCmd.UserProfile.NonRefundable;
            }
            else if (getPlayerInfoCmd.UserProfile.NonRefundable >= command.BetInfo.Amount) {
                getPlayerInfoCmd.UserProfile.NonRefundable -= command.BetInfo.Amount;
             
                command.BetInfo.BonusChips = command.BetInfo.Amount;
                command.BetInfo.Chips = 0;
            }

            //หักชิฟผู้เล่นตามเงินที่ต้องการลงพนัน
            UpdatePlayerInfoBalanceCommand updatePlayerInfoBalanceCmd = new UpdatePlayerInfoBalanceCommand ();
            updatePlayerInfoBalanceCmd.UserProfile = new UserProfile {
                UserName = command.BetInfo.UserName,
                NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable,
                Refundable = getPlayerInfoCmd.UserProfile.Refundable,
            };

            _iUpdatePlayerInfoBalance.ApplyAction(updatePlayerInfoBalanceCmd.UserProfile, updatePlayerInfoBalanceCmd);

            //บันทึกประวัติการลงพนัน
            command.BetInfo.BetDateTime = DateTime.Now;
           
            _iSingleBet.Create(command.BetInfo, command);
            
            //ดึงข้อมูลยอดเงินทั้งหมดของโต๊ะเกม
            GetGameRoundPotCommand getGameRoundPotCmd = new GetGameRoundPotCommand { RoundID = command.BetInfo.RoundID };
            getGameRoundPotCmd.Pot = _iGetGameRoundPot.Get(getGameRoundPotCmd);

            //ดึงข้อมูลโต๊ะเกม
            GetGameRoundInfoCommand getGameRoundInfoCmd = new GetGameRoundInfoCommand { RoundID = command.BetInfo.RoundID };
            getGameRoundInfoCmd.GameRoundInfo = _iGetGameRoundInfo.Get(getGameRoundInfoCmd);

            //ตรวจสอบว่าเป็นผู้ชนะหรือไม่
            switch (getGameRoundInfoCmd.GameRoundInfo.WinnerPoint.ToString()) {
                case "9":
                    modWinner = 10;
                    break;
                case "99":
                    modWinner = 100;
                    break;
                case "999":
                    modWinner = 1000;
                    break;
                case "9999":
                    modWinner = 10000;
                    break;
            }

            if (getGameRoundPotCmd.Pot % modWinner + _betFee == getGameRoundInfoCmd.GameRoundInfo.WinnerPoint) {

                updatePlayerInfoBalanceCmd.UserProfile.NonRefundable = command.BetInfo.BonusChips;
                updatePlayerInfoBalanceCmd.UserProfile.Refundable = getGameRoundInfoCmd.GameRoundInfo.WinnerPoint - command.BetInfo.BonusChips;

                //Sent amountReward to RewardModule
                ReturnRewardCommand returnRewardCmd = new ReturnRewardCommand { UserProfile = updatePlayerInfoBalanceCmd.UserProfile };
                _returnRewardEx.Execute(returnRewardCmd, (x) => { });
            }
        }
    }
}
