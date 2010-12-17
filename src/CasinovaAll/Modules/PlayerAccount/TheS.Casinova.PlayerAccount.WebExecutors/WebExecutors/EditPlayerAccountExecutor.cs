using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.BackServices;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.PlayerAccount.WebExecutors
{
    /// <summary>
    /// แก้ไขข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public class EditPlayerAccountExecutor
         : SynchronousCommandExecutorBase<EditPlayerAccountCommand>
    {
        private IEditPlayerAccount _iEditPlayerAccount;
        private IDependencyContainer _container;

        public EditPlayerAccountExecutor(IPlayerAccountModuleBackService dac, IDependencyContainer container)
        {
            _iEditPlayerAccount = dac;
            _container = container;
        }

        protected override void ExecuteCommand(EditPlayerAccountCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.PlayerAccountInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            _iEditPlayerAccount.EditPlayerAccount(command);
        }
    }
}
