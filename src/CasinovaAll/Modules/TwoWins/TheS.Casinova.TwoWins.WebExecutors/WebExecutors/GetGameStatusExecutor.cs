using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลสถานะของโตีะเกม
    /// </summary>
    public class GetGameStatusExecutor
        : SynchronousCommandExecutorBase<GetGameStatusCommand>
    {
        private IGetGameStatus _iGetGameStatus;
        private IDependencyContainer _container;

        public GetGameStatusExecutor(ITwoWinsGameDataQuery dqr, IDependencyContainer container)
        {
            _iGetGameStatus = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(GetGameStatusCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.RoundInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.RoundInformation =  _iGetGameStatus.Get(command);
        }
    }
}
