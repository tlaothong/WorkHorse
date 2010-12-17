using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.ChipExchange.BackServices.BackExecutors
{
    public class ChipsToMoneyExecutor
        : SynchronousCommandExecutorBase<ChipsToMoneyCommand>
    {
        private IGetUserProfile _iGetUserProfile;
        private IUpdateUserProfile _iUpdateUserProfile;
        private ICreateChequeInformation _iCreateChequeInfo;
        private IDependencyContainer _container;

        public ChipsToMoneyExecutor(IDependencyContainer container, IChipExchangeDataAccess dac, IChipExchangeDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
            _iUpdateUserProfile = dac;
            _iCreateChequeInfo = dac;
            _container = container;
        }

        protected override void ExecuteCommand(ChipsToMoneyCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            //ตรวจสอบจำนวนเงินขั้นต่ำที่แลกได้
            ExchangeSettingInformation exchangeSettingInfo = new ExchangeSettingInformation { Name = "Exchange1"};
            ValidationHelper.Validate(_container, exchangeSettingInfo, command, errorValidations);

            //ตรวจสอบชิฟเป็นของผู้เล่นว่าพอหรือไม่
            UserProfile userProfile = new UserProfile { UserName = command.ChequeInfo.UserName };
            ValidationHelper.Validate(_container, userProfile, command, errorValidations);

            //ตรวจสอบข้อมูลที่อยู่
            ValidationHelper.Validate(_container, command.ChequeInfo, command, errorValidations);

            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //Get user profile information
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserName = command.ChequeInfo.UserName,
            };
            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            //Update user profile(balance)
            UpdateUserProfileCommand updateUserProfileCmd = new UpdateUserProfileCommand {
                UserProfile = new UserProfile {
                    UserName = getUserProfileCmd.UserProfile.UserName,
                    NonRefundable = getUserProfileCmd.UserProfile.NonRefundable,
                    Refundable = getUserProfileCmd.UserProfile.Refundable,
                },
            };
            _iUpdateUserProfile.ApplyAction(getUserProfileCmd.UserProfile, updateUserProfileCmd);

            //Create cheque information
            _iCreateChequeInfo.Create(command.ChequeInfo, command);
        }
    }
}
