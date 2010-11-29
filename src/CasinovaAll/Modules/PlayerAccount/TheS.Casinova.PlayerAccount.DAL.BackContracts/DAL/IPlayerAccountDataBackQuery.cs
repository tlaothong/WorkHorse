using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerAccount.DAL
{
    public interface IPlayerAccountDataBackQuery :
        IGetPlayerAccountInfo,
        IGetUserProfile,
        IGetPlayerAccountInfoByAccountType
    { }

    /// <summary>
    /// ดึงข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public interface IGetPlayerAccountInfo
        : IFetchSingleData<PlayerAccountInformation, GetPlayerAccountCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลผู้เล่น
    /// </summary>
    public interface IGetUserProfile
        : IFetchSingleData<UserProfile, GetUserProfileCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลบัญชีของผู้เล่นจากประเภทบัญชี
    /// </summary>
    public interface IGetPlayerAccountInfoByAccountType
        : IFetchSingleData<PlayerAccountInformation, GetPlayerAccountInfoByAccountTypeCommand>
    { }
}
