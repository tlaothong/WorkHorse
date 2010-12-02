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
    /// ดึงข้อมูลบัญชีผู้เล่น
    /// </summary>
    public class GetPlayerAccountExecutor
        : SynchronousCommandExecutorBase<GetPlayerAccountCommand>
    {
        private IGetPlayerAccount _iGetPlayerAccount;
        private IDependencyContainer _container;

        public GetPlayerAccountExecutor(IPlayerAccountModuleDataQuery dqr, IDependencyContainer container) 
        {
            _iGetPlayerAccount = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(GetPlayerAccountCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.PlayerAccountInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command = new GetPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = command.PlayerAccountInfo.UserName,
                    Active = true
                }
            };
            command.PlayerAccountInformation = _iGetPlayerAccount.Get(command);
        }
    }
}
