using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Commands;

namespace TheS.Casinova.PlayerProfile.BackServices
{
    public interface IPlayerProfileBackService :
        IRegisterUser,
        IChangePassword,
        IChangeEmail
    {}

    /// <summary>
    /// ส่งค่า command เพื่อ register ข้อมูลของผู้เล่นที่สมัครสมาชิก
    /// </summary>
    public interface IRegisterUser
    {
        void RegisterUser(RegisterUserCommand cmd);
    }

    /// <summary>
    /// ส่งค่า command เพื่อเปลี่ยนรหัสผ่าน
    /// </summary>
    public interface IChangePassword
    {
        void ChangePassWord(ChangePasswordCommand cmd);
    }

    /// <summary>
    /// ส่งค่า command เพื่อเปลี่ยนอีเมล
    /// </summary>
    public interface IChangeEmail 
    {
        void ChangeEmail(ChangeEmailCommand cmd);
    }
}
