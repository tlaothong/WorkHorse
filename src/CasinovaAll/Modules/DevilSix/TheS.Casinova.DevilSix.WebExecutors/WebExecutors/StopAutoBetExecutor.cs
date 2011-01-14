﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.Common.Services;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.BackServices;


namespace TheS.Casinova.DevilSix.WebExecutors
{
    /// <summary>
    /// หยุดการลงเดิมพันแบบอัตโนมัติ
    /// </summary>
   public class StopAutoBetExecutor
   : SynchronousCommandExecutorBase<StopAutoBetCommand>
    {
        private IStopAutoBet _iStopAutoBet;
        private IDependencyContainer _container;
        private IGenerateTrackingID _svc;

        public StopAutoBetExecutor(IDevilSixGameBackService dac, IDependencyContainer container, IGenerateTrackingID svc)
        {
            _iStopAutoBet = dac;
            _container = container;
            _svc = svc;
        }

        protected override void ExecuteCommand(StopAutoBetCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.GamePlayAutoBetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.StopTrackingID = command.GamePlayAutoBetInfo.StopTrackingID = _svc.GenerateTrackingID();
            _iStopAutoBet.StopAutoBet(command);
        }
    }
}
