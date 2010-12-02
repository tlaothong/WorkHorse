using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.Commands;
using TheS.Casinova.MagicNine.BackServices;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.MagicNine.WebExecutors
{
    /// <summary>
    /// เริ่มลงเดิมพันแบบอัตโนมัติ 
    /// </summary>
    public class StartAutoBetExecutor
        : SynchronousCommandExecutorBase<StartAutoBetCommand>
    {
        private IStartAutoBet _iStartAutoBet;
        private IDependencyContainer _container;

        public StartAutoBetExecutor(IMagicNineGameBackService dac, IDependencyContainer container) 
       {
           _iStartAutoBet = dac;
           _container = container;
       }

        protected override void ExecuteCommand(StartAutoBetCommand command)
       {
           //Validation
           var errors = ValidationHelper.Validate(_container, command.GamePlayAutoBetInfo, command);
           if (errors.Any()) {
               throw new ValidationErrorException(errors);
           }
            //TODO: Generate BetTrackingID
           _iStartAutoBet.StartAutoBet(command);
       }
    }
}
