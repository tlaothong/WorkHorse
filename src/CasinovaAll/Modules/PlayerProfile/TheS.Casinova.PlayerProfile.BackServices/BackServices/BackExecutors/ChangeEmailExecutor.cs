using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.PlayerProfile.BackServices.BackExecutors
{
    public class ChangeEmailExecutor
        : SynchronousCommandExecutorBase<ChangeEmailCommand>
    {
        private IChangeEmail _iChangeEmail;
        private IDependencyContainer _container;

        public ChangeEmailExecutor(IDependencyContainer container, IPlayerProfileDataAccess dac, IPlayerProfileDataBackQuery dqr)
        {
            _iChangeEmail = dac;
            _container = container;
        }

        protected override void ExecuteCommand(ChangeEmailCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            //ตรวจสอบรหัสผ่าน,อีเมลล์เดิม, อีเมลล์ใหม่ ว่าถูกต้องหรือไม่
            ValidationHelper.Validate(_container, command.UserProfile, command, errorValidations);

            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            UserProfile userProfile = new UserProfile {
                UserName = command.UserProfile.UserName,
                Email = command.UserProfile.NewEmail,
            };

            //บันทึกอีเมลล์ใหม่ให้ผู้เล่น
            _iChangeEmail.ApplyAction(userProfile, command);
        }
    }
}
