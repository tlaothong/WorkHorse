using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.TwoWins.DAL
{
    public interface ITwowinsDataBackQuery :
        IGetRoundInfo,
        IGetUserProfile
    { }

    /// <summary>
    /// ดึงข้อมูลโต๊ะเกม
    /// </summary>
    public interface IGetRoundInfo
        : IFetchSingleData<RoundInformation, GetRoundInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลของผู้เล่น
    /// </summary>
    public interface IGetUserProfile
        : IFetchSingleData<UserProfile, GetUserProfileCommand>
    { }
}
