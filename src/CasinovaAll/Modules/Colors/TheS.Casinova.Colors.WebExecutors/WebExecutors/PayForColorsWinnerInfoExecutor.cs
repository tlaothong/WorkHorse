using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.BackServices;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.Colors.WebExecutors
{ 
    /// <summary>
    /// สร้าง TrackingID ส่งให้ client และส่ง command ไปยัง back server
    /// </summary>
    public class PayForColorsWinnerInfoExecutor
        : SynchronousCommandExecutorBase<PayForColorsWinnerInfoCommand>
    {
        private IPayForWinner _iPayForWinner;
        private IDependencyContainer _container;
        private IGenerateTrackingID _svc;
       
        public PayForColorsWinnerInfoExecutor(IColorsGameBackService dac, IDependencyContainer container, IGenerateTrackingID svc)
        {
            _iPayForWinner = dac;
            _container = container;
            _svc = svc;
        }

        protected override void ExecuteCommand(PayForColorsWinnerInfoCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.PlayerActionInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.OnGoingTrackingID = command.PlayerActionInfo.TrackingID = _svc.GenerateTrackingID();
            _iPayForWinner.PayForWinnerInfo(command);
            
        } 
    }
}
