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
    public class UserProfile_ChipsToMoneyValidators
        : ValidatorBase<UserProfile, ChipsToMoneyCommand>
    {
        private IGetUserProfile _iGetUserProfile;
        private double _playerBalance;
        private double _amount;

        public UserProfile_ChipsToMoneyValidators(IChipExchangeDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
        }

        public override void Validate(UserProfile entity, ChipsToMoneyCommand command, ValidationErrorCollection errors)
        {
            //Get user profile information
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserName = command.ChequeInfo.UserName,
            };
            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            _amount = command.ChequeInfo.Amount;

            //Calculate chips for update balance
            if (getUserProfileCmd.UserProfile.Refundable < _amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ชิฟเป็นไม่พอแลกเงิน",
                });
            }
        }
    }
}
