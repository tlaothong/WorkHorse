using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.BackServices.BackExecutors
{
    public class PayVoucherExecutor
        : SynchronousCommandExecutorBase<PayVoucherCommand>
    {
        private IGetUserProfile _iGetUserProfile;
        private IUpdateUserProfile _iUpdateUserProfile;
        private ICreateVoucherInformation _iCreateVoucherInfo;
        private IGenerateVoucherCode _iGenVoucherCode;
        private IDependencyContainer _container;

        private double _playerBalance;
        private double _amount;

        public PayVoucherExecutor(IDependencyContainer container, IGenerateVoucherCode svc, IChipExchangeDataAccess dac, IChipExchangeDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
            _iUpdateUserProfile = dac;
            _iCreateVoucherInfo = dac;
            _iGenVoucherCode = svc;
            _container = container;
        }

        protected override void ExecuteCommand(PayVoucherCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            UserProfile userProfile = new UserProfile { UserName = command.VoucherInformation.UserName };
            ValidationHelper.Validate(_container, userProfile, command, errorValidations);
            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //Get user profile information
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserName = command.VoucherInformation.UserName,
            };
            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            _amount = command.VoucherInformation.Amount;

            //If bonus chip less than voucher amount
            if (getUserProfileCmd.UserProfile.NonRefundable < command.VoucherInformation.Amount) { 
                getUserProfileCmd.UserProfile.Refundable -= command.VoucherInformation.Amount - getUserProfileCmd.UserProfile.NonRefundable;
                getUserProfileCmd.UserProfile.NonRefundable = 0;
            }
            else if(getUserProfileCmd.UserProfile.NonRefundable >= command.VoucherInformation.Amount) {
                getUserProfileCmd.UserProfile.NonRefundable -= command.VoucherInformation.Amount;
            }

            //Update user profile(balance)
            _iUpdateUserProfile.ApplyAction(getUserProfileCmd.UserProfile, command);

            //Call GenerateVoucherCode service for generate voucher code
            command.VoucherInformation.VoucherCode = _iGenVoucherCode.GenerateVoucherCode();
            command.VoucherInformation.CanUse = true;

            _iCreateVoucherInfo.Create(command.VoucherInformation, command);
        }
    }
}
