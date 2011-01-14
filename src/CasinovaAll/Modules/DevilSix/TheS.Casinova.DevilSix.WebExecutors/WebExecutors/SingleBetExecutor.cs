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
    /// ลงเดิมพันแบบปกติ
    /// </summary>
    public  class SingleBetExecutor
         : SynchronousCommandExecutorBase<SingleBetCommand>
    {
        private ISingleBet _iSingleBet;
        private IDependencyContainer _container;
        private IGenerateTrackingID _svc;

        public SingleBetExecutor(IDevilSixGameBackService dac, IDependencyContainer container, IGenerateTrackingID svc)
        {
            _iSingleBet = dac;
            _container = container;
            _svc = svc;
        }

        protected override void ExecuteCommand(SingleBetCommand command) 
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.BetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.TrackingID = command.BetInfo.BetTrackingID = _svc.GenerateTrackingID();
            _iSingleBet.SingleBet(command);
        }
    }
}
