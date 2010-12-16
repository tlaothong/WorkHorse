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
    /// ลงเดิมพันแบบทีละหลาย ๆ มือพร้อมกัน
    /// </summary>
    public class RangeBetExecutor
        : SynchronousCommandExecutorBase<RangeBetCommand>
    {
        private IRangeBet _iRangeBet;
        private IDependencyContainer _container;
        private IGenerateTrackingID _svc;

        public RangeBetExecutor(ITwoWinsGameBackService dac, IDependencyContainer container, IGenerateTrackingID svc)
        {
            _iRangeBet = dac;
            _container = container;
            _svc = svc;
        }

        protected override void ExecuteCommand(RangeBetCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.RangeBetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.BetTrackingID = command.RangeBetInfo.BetTrackingID = _svc.GenerateTrackingID();
            _iRangeBet.RangeBet(command);
        }
    }
}
