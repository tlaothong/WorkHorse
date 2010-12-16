using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.BackServices;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.Common.Services;

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
        private IGenerateTrackingID _svc;

        public ChangeBetExecutor(ITwoWinsGameBackService dac, IDependencyContainer container, IGenerateTrackingID svc)
        {
            _iChangeBet = dac;
            _container = container;
            _svc = svc;
        }

        protected override void ExecuteCommand(ChangeBetInfoCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.BetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.BetTrackingID = command.BetInfo.BetTrackingID = _svc.GenerateTrackingID();
            _iChangeBet.ChengeBetInfo(command);
        }
    }
}
