using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.BackServices.Validators
{
    public class PlayerAccountInfo_EditPlayerAccountInfoValidators
        : ValidatorBase<PlayerAccountInformation, EditPlayerAccountCommand>
    {
        

        public override void Validate(PlayerAccountInformation entity, EditPlayerAccountCommand command, ValidationErrorCollection errors)
        {

        }
    }
}
