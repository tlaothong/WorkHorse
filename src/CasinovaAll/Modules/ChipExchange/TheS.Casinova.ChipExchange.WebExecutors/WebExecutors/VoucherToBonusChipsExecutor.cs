using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.Command;
using TheS.Casinova.Common.Services;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// แลกคูปองเป็นชิพตาย
    /// </summary>
    public class VoucherToBonusChipsExecutor
    : SynchronousCommandExecutorBase<VoucherToBonusChipsCommand>
    {
        private IVoucherToBonusChips _iVoucherToBonusChips;
        private IDependencyContainer _container;
        private IGenerateTrackingID _svc;

        public VoucherToBonusChipsExecutor(IChipsExchangeModuleBackService dac, IDependencyContainer container, IGenerateTrackingID svc)
        {
            _iVoucherToBonusChips = dac;
            _container = container;
            _svc = svc;
        }

        protected override void ExecuteCommand(VoucherToBonusChipsCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.VoucherInformation, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            //Generate trackingID
            command.VoucherInformation.TrackingID = _svc.GenerateTrackingID();
            _iVoucherToBonusChips.VoucherToBonusChips(command);
                
        }
    }
}
