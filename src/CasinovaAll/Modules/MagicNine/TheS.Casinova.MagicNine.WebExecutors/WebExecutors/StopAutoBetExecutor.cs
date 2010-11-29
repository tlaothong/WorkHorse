using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.Commands;
using TheS.Casinova.MagicNine.BackServices;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;


namespace TheS.Casinova.MagicNine.WebExecutors
{
    /// <summary>
    /// หยุดการลงเดิมพันแบบอัตโนมัติ
    /// </summary>
   public class StopAutoBetExecutor
   : SynchronousCommandExecutorBase<StopAutoBetCommand>
    {
        private IStopAutoBet _iStopAutoBet;
        private IDependencyContainer _container;

        public StopAutoBetExecutor(IMagicNineGameBackService dac, IDependencyContainer container)
        {
            _iStopAutoBet = dac;
            _container = container;
        }

        protected override void ExecuteCommand(StopAutoBetCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.GamePlayAutoBetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
            //TODO : Generate BetTrackingID
            _iStopAutoBet.StopAutoBet(command);
        }
    }
}
