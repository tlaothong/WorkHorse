using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.Command;
using TheS.Casinova.PlayerProfile.DAL;

namespace TheS.Casinova.PlayerProfile.Validator
{
    using PerfEx.Infrastructure.LotUpdate;

    public class UserProfile_RegisterUserValidators
           : ValidatorBase<UserProfile, RegisterUserCommand>
    {
        private ICheckUserName _iCheckUserName;
        private ICheckEmail _iCheckEmail;
        private ICheckUpline _iCheckUpline;

        public UserProfile_RegisterUserValidators(IPlayerProfileDataQuery dqr)
        {
            _iCheckUserName = dqr;
            _iCheckEmail = dqr;
            _iCheckUpline = dqr;

        }

        public override void Validate(UserProfile entity, RegisterUserCommand command, ValidationErrorCollection errors)
        {

            CheckUserNameCommand checkUserName = new CheckUserNameCommand {
                UserName = entity.UserName
            };
            CheckEmailCommand checkEmail = new CheckEmailCommand {
                Email = entity.Email
            };
            CheckUplineCommand checkUpline = new CheckUplineCommand {
                Upline = entity.Upline
            };

            checkUserName.PlayerProfile = _iCheckUserName.Get(checkUserName);
            checkEmail.PlayerProfile = _iCheckEmail.Get(checkEmail);
            checkUpline.PlayerProfile = _iCheckUpline.Get(checkUpline);

            //ตรวจสอบ username ว่าซ้ำหรือไม่
            if (checkUserName.PlayerProfile.UserName == entity.UserName) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "UserName นี้มีผู้ใช้งานแล้ว",
                });
            }

            //ตรวจสอบ email ว่าซ้ำหรือไม่
            if (checkEmail.PlayerProfile.Email == entity.Email) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "Email นี้มีผู้ใช้งานแล้ว",
                });
            }

            //ตรวจสอบ upline ว่ามีข้อมูลหรือไม่
            if (command.RegisterUserInfo.Upline != null) {
                if (checkUpline.PlayerProfile.Upline != entity.UserName) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "กรอกข้อมูล Upline ไม่ถูกต้อง",
                    });
                }
            }
        }
    }
}
