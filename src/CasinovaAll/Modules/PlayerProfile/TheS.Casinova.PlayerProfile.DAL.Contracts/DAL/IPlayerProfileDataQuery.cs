using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.PlayerProfile.Command;

namespace TheS.Casinova.PlayerProfile.DAL
{
    public interface IPlayerProfileDataQuery :
        IGetUserProfile,
        IListActionLog,
        ICheckUserName,
        ICheckUpline,
        ICheckEmail,
        IGetPlayerEmail,
        IGetPlayerPassword
    
    {}

    /// <summary>
    /// ดึงข้อมูลโปรไฟล์ของผู้เล่น
    /// </summary>
    public interface IGetUserProfile
        : IFetchSingleData<UserProfile, GetUserProfileCommand>
    { }

    /// <summary>
    /// ดึงข้อมูล action log ของผู้เล่น
    /// </summary>
    public interface IListActionLog
        : IFetchData<ActionLog, ListActionLogCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลชื่อของผู้เล่น เพื่อตรวจสอบว่ามีอยุ่แล้วหรือไม่
    /// </summary>
    public interface ICheckUserName
        : IFetchSingleData<UserProfile, CheckUserNameCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลชื่อของผู้เล่น เพื่อตรวจสอบชื่อ upline
    /// </summary>
    public interface ICheckUpline
        : IFetchSingleData<UserProfile, CheckUplineCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลอีเมลของผู้เล่น
    /// </summary>
    public interface IGetPlayerEmail
        : IFetchSingleData<UserProfile, GetPlayerEmailCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลรหัสผ่านของผู้เล่น
    /// </summary>
    public interface IGetPlayerPassword
        : IFetchSingleData<UserProfile, GetPlayerPasswordCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลโปรไฟล์ของผู้เล่น โดยใช้อีเมล
    /// </summary>
    public interface ICheckEmail
        : IFetchSingleData<UserProfile, CheckEmailCommand>
    { }
}
