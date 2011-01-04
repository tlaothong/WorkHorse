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
                UserName = command.BetPlayerActionInfo.UserName,
            };

            getPlayerInfoCmd.UserProfile = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            //ตรวจสอบเงินของผู้เล่นว่าพอลงพนันหรือไม่
            ValidationErrorCollection errorsValidation = new ValidationErrorCollection();

            ValidationHelper.Validate(_container, getPlayerInfoCmd.UserProfile, command, errorsValidation);
            ValidationHelper.Validate(_container, command.BetPlayerActionInfo, command, errorsValidation);

            if (errorsValidation.Any()) {
                throw new ValidationErrorException(errorsValidation);
            }

            //บันทึกข้อมูลผู้เล่นที่ถูกหักเงิน
            if (getPlayerInfoCmd.UserProfile.NonRefundable < command.BetPlayerActionInfo.Amount) {
                getPlayerInfoCmd.UserProfile.Refundable -= command.BetPlayerActionInfo.Amount - getPlayerInfoCmd.UserProfile.NonRefundable;
                getPlayerInfoCmd.UserProfile.NonRefundable = 0;
            }
            else if (getPlayerInfoCmd.UserProfile.NonRefundable >= command.BetPlayerActionInfo.Amount) {
                getPlayerInfoCmd.UserProfile.NonRefundable -= command.BetPlayerActionInfo.Amount;
            }


            //หักเงินผู้เล่นตามเงินที่ต้องการลงพนัน
            UpdatePlayerInfoBalanceCommand updateBalanceCmd = new UpdatePlayerInfoBalanceCommand {
                UserProfile = new UserProfile {
                    UserName = command.BetPlayerActionInfo.UserName,
                    NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable,
                    Refundable = getPlayerInfoCmd.UserProfile.Refundable,
                }
            };

            _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updateBalanceCmd);

            #endregion Update balance

            #region Create player action information

            //บันทึกข้อมูลการดำเนินงานของผู้เล่น
            CreatePlayerActionInfoCommand createPlayerActionInfoCmd = new CreatePlayerActionInfoCommand {
                PlayerActionInfo = new PlayerActionInformation {
                    UserName = command.BetPlayerActionInfo.UserName,
                    RoundID = command.BetPlayerActionInfo.RoundID,
                    Amount = command.BetPlayerActionInfo.Amount,
                    BonusChips = getPlayerInfoCmd.UserProfile.NonRefundable,
                    Chips = getPlayerInfoCmd.UserProfile.Refundable,
                    ActionType = command.BetPlayerActionInfo.ActionType,
                    ActionDateTime = DateTime.Now,
                }
            };

            _iCreatePlayerActionInfo.Create(command.BetPlayerActionInfo, createPlayerActionInfoCmd);

            #endregion Create player action information
        }
    }
}
