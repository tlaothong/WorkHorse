using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.Colors.BackServices.BackExecutors
{
    public class BetColorExecutor
        : SynchronousCommandExecutorBase<BetCommand>
    {
        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private ICreatePlayerActionInfo _iCreatePlayerActionInfo;

        private IGetPlayerInfo _iGetPlayerInfo;
        private IDependencyContainer _container;

        public BetColorExecutor(IDependencyContainer container, IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _iUpdatePlayerInfoBalance = dac;
            _iCreatePlayerActionInfo = dac;

            _iGetPlayerInfo = dqr;

            _container = container;
        }

        protected override void ExecuteCommand(BetCommand command)
        {
            #region Update balance

            //ดึงข้อมูลผู้เล่นเพื่อหักเงิน
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.PlayerActionInformation.UserName,
            };

            getPlayerInfoCmd.UserProfile = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            //ตรวจสอบเงินของผู้เล่นว่าพอลงพนันหรือไม่

            var errorsUserProfile = ValidationHelper.Validate(_container, getPlayerInfoCmd.UserProfile, command);
            var errorsPlayerActionInfo = ValidationHelper.Validate(_container, command.PlayerActionInformation, command);

            if (errorsUserProfile.Any()) {
                throw new ValidationErrorException(errorsUserProfile);
            }

            if (errorsPlayerActionInfo.Any()) {
                throw new ValidationErrorException(errorsPlayerActionInfo);
            }

            //บันทึกข้อมูลผู้เล่นที่ถูกหักเงิน
            UpdatePlayerInfoBalanceCommand updateBalanceCmd = new UpdatePlayerInfoBalanceCommand();

            if (getPlayerInfoCmd.UserProfile.NonRefundable < command.PlayerActionInformation.Amount) {
                getPlayerInfoCmd.UserProfile.Refundable -= command.PlayerActionInformation.Amount - getPlayerInfoCmd.UserProfile.NonRefundable;
                getPlayerInfoCmd.UserProfile.NonRefundable = 0;

                updateBalanceCmd.UserName = command.PlayerActionInformation.UserName;

                //หักเงินผู้เล่นตามเงินที่ต้องการลงพนัน
                updateBalanceCmd.NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable;
                updateBalanceCmd.Refundable = getPlayerInfoCmd.UserProfile.Refundable;

                _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updateBalanceCmd);
            }
            else if (getPlayerInfoCmd.UserProfile.NonRefundable >= command.PlayerActionInformation.Amount) {
                getPlayerInfoCmd.UserProfile.NonRefundable -= command.PlayerActionInformation.Amount;

                updateBalanceCmd.UserName = command.PlayerActionInformation.UserName;

                //หักเงินผู้เล่นตามเงินที่ต้องการลงพนัน
                updateBalanceCmd.NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable;
                updateBalanceCmd.Refundable = getPlayerInfoCmd.UserProfile.Refundable;

                _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updateBalanceCmd);
            }

            #endregion Update balance

            #region Create player action information

            //บันทึกข้อมูลการดำเนินงานของผู้เล่น
            CreatePlayerActionInfoCommand createPlayerActionInfoCmd = new CreatePlayerActionInfoCommand {
                UserName  = command.PlayerActionInformation.UserName,
                RoundID  = command.PlayerActionInformation.RoundID,
                Amount  = command.PlayerActionInformation.Amount,
                ActionType  = command.PlayerActionInformation.ActionType,
            };

            _iCreatePlayerActionInfo.Create(command.PlayerActionInformation, createPlayerActionInfoCmd);

            #endregion Create player action information

        }
    }
}
