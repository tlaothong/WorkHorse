using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.Common.Services;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.BackServices;

namespace TheS.Casinova.DevilSix.WebExecutors
{
    /// <summary>
    /// เริ่มลงเดิมพันแบบอัตโนมัติ 
    /// </summary>
    public class StartAutoBetExecutor
        : SynchronousCommandExecutorBase<StartAutoBetCommand>
    {
        private IStartAutoBet _iStartAutoBet;
        private IDependencyContainer _container;
        private IGenerateTrackingID _svc;

        public StartAutoBetExecutor(IDevilSixGameBackService dac, IDependencyContainer container, IGenerateTrackingID svc) 
       {
           _iStartAutoBet = dac;
           _container = container;
           _svc = svc;
       }

        protected override void ExecuteCommand(StartAutoBetCommand command)
       {
           //Validation
           var errors = ValidationHelper.Validate(_container, command.GamePlayAutoBetInfo, command);
           if (errors.Any()) {
               throw new ValidationErrorException(errors);
           }

           command.StartTrackingID = command.GamePlayAutoBetInfo.AutoBetTrackingID = _svc.GenerateTrackingID();
           command.GamePlayAutoBetInfo.BetTrackingID = _svc.GenerateTrackingID();

           _iStartAutoBet.StartAutoBet(command);
       }
    }
}
