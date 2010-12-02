using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.MagicNine.BackServices.BackExecutors
{
    public class StartAutoBetExecutor
        : SynchronousCommandExecutorBase<StartAutoBetCommand>
    {
        private IAutoBetEngine _iAutoBetEngine;
        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private IGetPlayerInfo _iGetPlayerInfo;
        private ICreateAutoBetInfo _iCreateAutoBetInfo;
        private IDependencyContainer _container;

        public StartAutoBetExecutor(IDependencyContainer container, IAutoBetEngine svc, IMagicNineGameDataAccess dac, IMagicNineGameDataBackQuery dqr)
        {
            _iAutoBetEngine = svc;

            _iUpdatePlayerInfoBalance = dac;
            _iCreateAutoBetInfo = dac;

            _iGetPlayerInfo = dqr;

            _container = container;
        }

        protected override void ExecuteCommand(StartAutoBetCommand command)
        {
            //ดึงข้อมูลชิฟของผู้เล่น
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.GamePlayAutoBetInfo.UserName,
            };

            getPlayerInfoCmd.UserProfile = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            ValidationErrorCollection errorsValidation = new ValidationErrorCollection();
            ValidationHelper.Validate(_container, getPlayerInfoCmd.UserProfile, command, errorsValidation);

            if (errorsValidation.Any()) {
                throw new ValidationErrorException(errorsValidation);
            }

            UpdatePlayerInfoBalanceCommand updatePlayerInfoBalanceCmd = new UpdatePlayerInfoBalanceCommand();

            //คำนวณชิฟที่ต้องหักจากผู้เล่น
            if (getPlayerInfoCmd.UserProfile.NonRefundable < command.GamePlayAutoBetInfo.Amount) {
                getPlayerInfoCmd.UserProfile.Refundable -= command.GamePlayAutoBetInfo.Amount - getPlayerInfoCmd.UserProfile.NonRefundable;
                getPlayerInfoCmd.UserProfile.NonRefundable = 0;
            }
            else if (getPlayerInfoCmd.UserProfile.NonRefundable >= command.GamePlayAutoBetInfo.Amount) {
                getPlayerInfoCmd.UserProfile.NonRefundable -= command.GamePlayAutoBetInfo.Amount;
            }

            //หักชิฟผู้เล่นตามเงินที่ต้องการลงพนัน
            updatePlayerInfoBalanceCmd.UserProfile = new UserProfile {
                UserName = command.GamePlayAutoBetInfo.UserName,
                NonRefundable = command.GamePlayAutoBetInfo.BonusChips = getPlayerInfoCmd.UserProfile.NonRefundable,
                Refundable = command.GamePlayAutoBetInfo.Chips = getPlayerInfoCmd.UserProfile.Refundable,
            };

            _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updatePlayerInfoBalanceCmd);

            //ส่งข้อมูลให้ AutoBet Engine ทำงานต่อ
            _iAutoBetEngine.StartAutoBet(command.GamePlayAutoBetInfo, command);

            //บันทึกประวัติการลงพนัน
            command.GamePlayAutoBetInfo.FromDateTime = DateTime.Now;
            _iCreateAutoBetInfo.Create(command.GamePlayAutoBetInfo, command);
        }
    }
}
