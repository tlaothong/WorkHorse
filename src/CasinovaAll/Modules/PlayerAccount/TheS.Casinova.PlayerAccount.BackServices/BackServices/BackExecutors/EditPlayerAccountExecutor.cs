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
                CardType = command.PlayerAccountInfo.CardType,
                UserName = command.PlayerAccountInfo.UserName,
                AccountType = command.PlayerAccountInfo.AccountType,
                AccountNo = command.PlayerAccountInfo.AccountNo,
                CVV = command.PlayerAccountInfo.CVV,
                ExpireDate = command.PlayerAccountInfo.ExpireDate,
            };

            _iEditPlayerAccount.ApplyAction(playerAccountInfo, command);
        }
    }
}
