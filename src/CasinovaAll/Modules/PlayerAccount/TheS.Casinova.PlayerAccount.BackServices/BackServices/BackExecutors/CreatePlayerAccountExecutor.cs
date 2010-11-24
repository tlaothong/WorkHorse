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
    public  class CreatePlayerAccountExecutor
        : SynchronousCommandExecutorBase<CreatePlayerAccountCommand>
    {
        private ICreatePlayerAccount _iCreatePlayerAccount;

        public CreatePlayerAccountExecutor(IPlayerAccountDataAccess dac)
        {
            _iCreatePlayerAccount = dac;
        }

        protected override void ExecuteCommand(CreatePlayerAccountCommand command)
        {
            PlayerAccountInformation playerAccountInfo = new PlayerAccountInformation {
                UserName = command.UserName,
                AccountType = command.AccountType,
                AccountNo = command.AccountNo,
                CVV = command.CVV,
                ExpireDate = command.ExpireDate,
                Active = true,
            };

            _iCreatePlayerAccount.Create(playerAccountInfo, command);
        }
    }
}
