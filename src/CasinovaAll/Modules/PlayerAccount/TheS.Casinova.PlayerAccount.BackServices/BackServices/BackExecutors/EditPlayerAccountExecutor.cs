using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.DAL;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.PlayerAccount.BackServices.BackExecutors
{
    public class EditPlayerAccountExecutor
        : SynchronousCommandExecutorBase<EditPlayerAccountCommand>
    {
        private IEditPlayerAccount _iEditPlayerAccount;

        public EditPlayerAccountExecutor(IPlayerAccountDataAccess dac)
        {
            _iEditPlayerAccount = dac;
        }

        protected override void ExecuteCommand(EditPlayerAccountCommand command)
        {
            PlayerAccountInformation playerAccountInfo = new PlayerAccountInformation {
                PlayerAccoundID = command.PlayerAccoundID,
                UserName = command.UserName,
                AccountType = command.AccountType,
                AccountNo = command.AccountNo,
                CVV = command.CVV,
                ExpireDate = command.ExpireDate,
            };

            _iEditPlayerAccount.ApplyAction(playerAccountInfo, command);
        }
    }
}
