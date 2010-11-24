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
    /// ลงเดิมพันแบบปกติ
    /// </summary>
    public  class SingleBetExecutor
         : SynchronousCommandExecutorBase<SingleBetCommand>
    {
        private ISingleBet _iSingleBet;
        private IDependencyContainer _container;

        public SingleBetExecutor(IMagicNineGameBackService dac, IDependencyContainer container)
        {
            _iSingleBet = dac;
            _container = container;
        }

        protected override void ExecuteCommand(SingleBetCommand command) 
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.BetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
            //TODO: Generate TrackingID
            _iSingleBet.SingleBet(command);
        }
    }
}
