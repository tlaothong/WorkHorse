using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.PlayerAccount.WebExecutors
{
    /// <summary>
    /// ลิสต์ข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public class ListPlayerAccountExecutor 
     : SynchronousCommandExecutorBase<ListPlayerAccountCommand>       
    {
        private IListPlayerAccount _iListPlayerAccount;
        private IDependencyContainer _container;

        public ListPlayerAccountExecutor(IPlayerAccountModuleDataQuery dqr, IDependencyContainer container) 
        {
            _iListPlayerAccount = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListPlayerAccountCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.PlayerAccountInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command = new ListPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation { 
                    UserName = command.PlayerAccountInfo.UserName,
                    Active = true
                }
            };
            command.PlayerAccountInformation = _iListPlayerAccount.List(command);
        }
    }
}
