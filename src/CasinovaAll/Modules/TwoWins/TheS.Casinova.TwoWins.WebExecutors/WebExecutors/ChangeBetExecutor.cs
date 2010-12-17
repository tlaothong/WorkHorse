using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.BackServices;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    /// เปลี่ยนแปลงจำนวนเงินที่ลงเดิมพันในช่วง Normal
    /// </summary>
    public class ChangeBetExecutor
        : SynchronousCommandExecutorBase<ChangeBetInfoCommand>
    {
        private IChangeBetInfo _iChangeBet;
        private IDependencyContainer _container;

        public ChangeBetExecutor(ITwoWinsGameBackService dac, IDependencyContainer container)
        {
            _iChangeBet = dac;
            _container = container;
        }

        protected override void ExecuteCommand(ChangeBetInfoCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.BetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            //TODO: Generate BetTrackingID
            _iChangeBet.ChengeBetInfo(command);
        }
    }
}
