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

        private IDependencyContainer _container;

        private const double _betFee = 1;

        public SingleBetExecutor(IDependencyContainer container, IMagicNineGameDataAccess dac, IMagicNineGameDataBackQuery dqr)
        {
            _iSingleBet = dac;
            _iUpdatePlayerInfoBalance = dac;
            _iUpdateGameRoundPot = dac;

            _iGetPlayerInfo = dqr;
            _iGetGameRoundPot = dqr;

            _container = container;
        }

        protected override void ExecuteCommand(SingleBetCommand command)
        {
            //กำหนดจำนวนที่ลงเงินพนัน
            command.Amount = _betFee;

            //ดึงข้อมูลชิฟของผู้เล่น
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.UserName,
            };
            getPlayerInfoCmd.UserProfile = _iGetPlayerInfo.Get(getPlayerInfoCmd);
            
            ValidationErrorCollection errorsValidation = new ValidationErrorCollection();
            ValidationHelper.Validate(_container, getPlayerInfoCmd.UserProfile, command);

            if (errorsValidation.Any()) {
                throw new ValidationErrorException(errorsValidation);
            }

            //หักชิฟของผู้เล่น
            UpdatePlayerInfoBalanceCommand updatePlayerInfoBalanceCmd = new UpdatePlayerInfoBalanceCommand ();

            if (getPlayerInfoCmd.UserProfile.NonRefundable < command.Amount) {
                getPlayerInfoCmd.UserProfile.Refundable -= command.Amount - getPlayerInfoCmd.UserProfile.NonRefundable;
                getPlayerInfoCmd.UserProfile.NonRefundable = 0;
            }
            else if (getPlayerInfoCmd.UserProfile.NonRefundable >= command.Amount) {
                getPlayerInfoCmd.UserProfile.NonRefundable -= command.Amount;
            }

            updatePlayerInfoBalanceCmd.UserName = command.UserName;

            //หักชิฟผู้เล่นตามเงินที่ต้องการลงพนัน
            updatePlayerInfoBalanceCmd.NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable;
            updatePlayerInfoBalanceCmd.Refundable = getPlayerInfoCmd.UserProfile.Refundable;

            _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updatePlayerInfoBalanceCmd);

            GetGameRoundPotCommand getGameRoundPotCmd = new GetGameRoundPotCommand {
                RoundID = command.RoundID,
            };

            //ดึงข้อมูลจำนวนเงินในโต๊ะเกม สำหรับบันทึกประวัติการลงพนันของผู้เล่น
            getGameRoundPotCmd.Pot = _iGetGameRoundPot.Get(getGameRoundPotCmd);

            //บันทึกประวัติการลงพนัน
            BetInformation betInfo = new BetInformation {
                RoundID = command.RoundID,
                UserName = command.UserName,
                TrackingID = command.TrackingID,
                BetDateTime = DateTime.Now,
            };
           
            _iSingleBet.Create(betInfo, command);
        }
    }
}
