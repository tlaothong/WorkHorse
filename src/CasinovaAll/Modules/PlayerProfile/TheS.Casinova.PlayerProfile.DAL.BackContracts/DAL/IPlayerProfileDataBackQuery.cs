using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.PlayerProfile.DAL
{
    public interface IPlayerProfileDataBackQuery :
        IGetUserProfile,
        IGetUserProfileByEmail
    { }

    /// <summary>
    /// ดึงข้อมูลผู้เล่น
    /// </summary>
    public interface IGetUserProfile
        : IFetchSingleData<UserProfile, GetUserProfileCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลผู้เล่นจากอีเมลล์
    /// </summary>
    public interface IGetUserProfileByEmail
        : IFetchSingleData<UserProfile, GetUserProfileByEmailCommand>
    { }
}
