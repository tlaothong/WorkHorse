using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.DAL;
using TheS.Casinova.PlayerAccount.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.PlayerAccount.BackServices.BackExecutors
{
    public  class CreatePlayerAccountExecutor
        : SynchronousCommandExecutorBase<CreatePlayerAccountCommand>
    {
        private ICreatePlayerAccount _iCreatePlayerAccount;
        private IDependencyContainer _container;

        public CreatePlayerAccountExecutor(IDependencyContainer container, IPlayerAccountDataAccess dac)
        {
            _iCreatePlayerAccount = dac;
            _container = container;
        }

        protected override void ExecuteCommand(CreatePlayerAccountCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();
            ValidationHelper.Validate(_container, command.PlayerAccountInfo, command, errorValidations);
            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //สร้างข้อมูลบัญชีของผู้เล่น(Primary)
            command.PlayerAccountInfo.Active = true;
            command.PlayerAccountInfo.AccountType = "Primary";
            _iCreatePlayerAccount.Create(command.PlayerAccountInfo, command);

            //สร้างข้อมูลบัญชีของผู้เล่น(Secondary)
            PlayerAccountInformation secondaryAccountInfo = new PlayerAccountInformation {
                UserName = command.PlayerAccountInfo.UserName,
                AccountType = "Secondary",
                Active = false,
            };
            _iCreatePlayerAccount.Create(secondaryAccountInfo, command);
        }
    }
}
