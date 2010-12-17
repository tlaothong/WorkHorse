using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// ดึงหมายเลขคูปอง
    /// </summary>
    public class GetVoucherCodeExecutor
     : SynchronousCommandExecutorBase<GetVoucherCodeCommand>
    {
        private IGetVoucherCode _iGetVoucherCode;
        private IDependencyContainer _container;

        public GetVoucherCodeExecutor(IChipsExchangeModuleDataQuery dqr, IDependencyContainer container)
        {
            _iGetVoucherCode = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(GetVoucherCodeCommand command)
        {
            bool canUse = true;
            //Validation
            var errors = ValidationHelper.Validate(_container, command.VoucherInformation, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            //TODO: Generate trackingID
            command = new GetVoucherCodeCommand {
                VoucherInformation = new VoucherInformation { 
                    UserName = command.VoucherInformation.UserName,
                    CanUse = canUse,
                }
            };

           command.VoucherCode = _iGetVoucherCode.Get(command);
        }
    }
}
