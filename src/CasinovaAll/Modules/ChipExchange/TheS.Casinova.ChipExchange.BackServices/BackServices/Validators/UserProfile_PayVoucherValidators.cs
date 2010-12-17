using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.DAL;

namespace TheS.Casinova.ChipExchange.BackServices.Validators
{
    public class UserProfile_PayVoucherValidators
        : ValidatorBase<UserProfile, PayVoucherCommand>
    {
        private IGetUserProfile _iGetUserProfile;
        private double _playerBalance;
        private double _amount;

        public UserProfile_PayVoucherValidators(IChipExchangeDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
        }

        public override void Validate(UserProfile entity, PayVoucherCommand command, ValidationErrorCollection errors)
        {
            //Get user profile information
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserName = command.VoucherInformation.UserName,
            };
            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            _playerBalance = getUserProfileCmd.UserProfile.Refundable + getUserProfileCmd.UserProfile.NonRefundable;
            _amount = command.VoucherInformation.Amount;

            //Calculate chips for update balance
            if (_playerBalance < _amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ชิฟไม่พอแลกคูปอง",
                });
            }
        }
    }
}
