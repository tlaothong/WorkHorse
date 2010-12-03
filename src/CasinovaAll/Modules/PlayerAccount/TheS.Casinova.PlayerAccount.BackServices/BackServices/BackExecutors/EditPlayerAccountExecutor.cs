using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.DAL;
using TheS.Casinova.PlayerAccount.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.BackServices.BackExecutors
{
    public class EditPlayerAccountExecutor
        : SynchronousCommandExecutorBase<EditPlayerAccountCommand>
    {
        private IEditPlayerAccount _iEditPlayerAccount;
        private IDependencyContainer _container;

        public EditPlayerAccountExecutor(IDependencyContainer container, IPlayerAccountDataAccess dac)
        {
            _iEditPlayerAccount = dac;
            _container = container;
        }

        protected override void ExecuteCommand(EditPlayerAccountCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            //ตรวจสอบประเภทบัตร
            ValidationHelper.Validate(_container, command.PlayerAccountInfo, command, errorValidations);
            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //บันทึกข้อมูลบัญชีที่แก้ไข
            _iEditPlayerAccount.ApplyAction(command.PlayerAccountInfo, command);
        }
    }
}
