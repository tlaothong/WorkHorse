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
    public class CancelPlayerAccountExecutor
        : SynchronousCommandExecutorBase<CancelPlayerAccountCommand>
    {
        private ICancelPlayerAccount _iCancelPlayerAccount;

        public CancelPlayerAccountExecutor(IPlayerAccountDataAccess dac)
        {
            _iCancelPlayerAccount = dac;
        }

        protected override void ExecuteCommand(CancelPlayerAccountCommand command)
        {
            PlayerAccountInformation playerAccountInfo = new PlayerAccountInformation {
                UserName = command.UserName,
                PlayerAccoundID = command.PlayerAccoundID,
            };

            _iCancelPlayerAccount.ApplyAction(playerAccountInfo, command);
        }
    }
}
