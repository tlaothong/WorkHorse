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
    public class RegisterUserExecutor
        : SynchronousCommandExecutorBase<RegisterUserCommand>
    {
        private IRegisterUser _iRegisterUser;
        private IDependencyContainer _container;
        private IEmailSender _iEmailSender;

        public RegisterUserExecutor(IDependencyContainer container, IEmailSender svc, IPlayerProfileDataAccess dac)
        {
            _iEmailSender = svc;
            _iRegisterUser = dac;
            _container = container;
        }

        protected override void ExecuteCommand(RegisterUserCommand command)
        {
            command.UserProfile.Active = false;

            ValidationErrorCollection errorsValidation = new ValidationErrorCollection();

            if (!string.IsNullOrEmpty(command.UserProfile.Upline)) { //สมัครสมาชิกโดยมีผู้แนะนำ
                //ตรวจสอบ upline ที่ระบุมาว่ามีอยู่จริง
                ValidationHelper.Validate(_container, command.UserProfile, command, errorsValidation);
                if (errorsValidation.Any()) {
                    throw new ValidationErrorException(errorsValidation);
                }

                //บันทึกข้อมูลการสมัคร
                _iRegisterUser.Create(command.UserProfile, command);

                //TODO: ขาดการบันทึกชื่อผู้เล่นเป็น donwline ให้กับคนที่แนะนำ(MLN module)
            }
            else { //สมัครสมาชิกโดนไม่มีผู้แนะนำ
                //บันทึกข้อมูลการสมัคร
                command.UserProfile.Upline = null;
                _iRegisterUser.Create(command.UserProfile, command);
            }

            //ส่งอีเมลล์สำหรับยืนยันการสมัครให้ผู้เล่น
            _iEmailSender.SendingValidationEmail(command.UserProfile, command);
        }
    }
}
