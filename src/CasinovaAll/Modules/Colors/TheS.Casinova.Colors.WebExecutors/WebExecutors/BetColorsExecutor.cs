using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.BackServices;
using TheS.Casinova.Colors.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.WebExecutors
{
    /// <summary>
    /// ลงเดิมพัน
    /// </summary>
    public class BetColorsExecutor
        : SynchronousCommandExecutorBase<BetCommand>
    {
        private IBet _iBet;
        private IDependencyContainer _container;
        public BetColorsExecutor(IColorsGameBackService dac, IDependencyContainer container) 
        {
            _iBet = dac;
            _container = container;
        }

        protected override void ExecuteCommand(BetCommand command) 
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.PlayerActionInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
            //TODO: Generate TrackingID
            _iBet.PlayerBet(command);
        }
    }
}
