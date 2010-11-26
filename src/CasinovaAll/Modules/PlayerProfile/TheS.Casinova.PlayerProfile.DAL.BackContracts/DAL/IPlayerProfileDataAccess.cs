using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.PlayerProfile.DAL
{
    public interface IPlayerProfileDataAccess :
        IRegisterUser,
        IVeriflyUser,
        IChangePassword,
        IChangeEmail
    { }

    /// <summary>
    /// สร้างผู้เล่นใหม่
    /// </summary>
    public interface IRegisterUser
        : ICreateData<UserProfile, RegisterUserCommand>
    { }

    /// <summary>
    /// ยืนยันการสมัครของผู้เล่น
    /// </summary>
    public interface IVeriflyUser
        : IDataAction<UserProfile, VerifyUserCommand>
    { }

    /// <summary>
    /// เปลี่ยนรหัสผ่าน
    /// </summary>
    public interface IChangePassword
        : IDataAction<UserProfile, ChangePasswordCommand>
    { }

    /// <summary>
    /// เปลี่ยนอีเมลล์
    /// </summary>
    public interface IChangeEmail
        : IDataAction<UserProfile, ChangeEmailCommand>
    { }
}
