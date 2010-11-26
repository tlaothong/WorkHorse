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
            command.BetInfo.Amount = _betFee;

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
            UpdatePlayerInfoBalanceCommand updatePlayerInfoBalanceCmd = new UpdatePlayerInfoBalanceCommand ();

            if (getPlayerInfoCmd.UserProfile.NonRefundable < command.BetInfo.Amount) {
                getPlayerInfoCmd.UserProfile.Refundable -= command.BetInfo.Amount - getPlayerInfoCmd.UserProfile.NonRefundable;
                getPlayerInfoCmd.UserProfile.NonRefundable = 0;
            }
            else if (getPlayerInfoCmd.UserProfile.NonRefundable >= command.BetInfo.Amount) {
                getPlayerInfoCmd.UserProfile.NonRefundable -= command.BetInfo.Amount;
            }

            //หักชิฟผู้เล่นตามเงินที่ต้องการลงพนัน
            updatePlayerInfoBalanceCmd.UserProfile = new UserProfile {
                UserName = command.BetInfo.UserName,
                NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable,
                Refundable = getPlayerInfoCmd.UserProfile.Refundable,
            };

            _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updatePlayerInfoBalanceCmd);

            GetGameRoundPotCommand getGameRoundPotCmd = new GetGameRoundPotCommand {
                RoundID = command.BetInfo.RoundID,
            };

            //บันทึกประวัติการลงพนัน
            command.BetInfo.BetDateTime = DateTime.Now;
           
            _iSingleBet.Create(command.BetInfo, command);
        }
    }
}
