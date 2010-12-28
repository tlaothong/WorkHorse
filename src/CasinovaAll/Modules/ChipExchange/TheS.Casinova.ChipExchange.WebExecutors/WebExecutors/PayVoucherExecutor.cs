using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.DAL;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// ซื้อคูปอง
    /// </summary>
   public class PayVoucherExecutor
   : SynchronousCommandExecutorBase<PayVoucherCommand>
    {
        private IPayVoucher _iPayVoucher;
        private IDependencyContainer _container;
        private IGenerateTrackingID _svc;

        public PayVoucherExecutor(IChipsExchangeModuleBackService dac, IDependencyContainer container, IGenerateTrackingID svc)
        {
            _iPayVoucher = dac;
            _container = container;
            _svc = svc;

        }

        protected override void ExecuteCommand(PayVoucherCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.VoucherInformation, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.VoucherInformation.TrackingID = _svc.GenerateTrackingID();
            _iPayVoucher.PayVoucher(command);
        }
    }
}
