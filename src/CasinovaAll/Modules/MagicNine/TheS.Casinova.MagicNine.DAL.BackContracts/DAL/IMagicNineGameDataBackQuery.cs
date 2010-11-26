using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.MagicNine.DAL
{
    public interface IMagicNineGameDataBackQuery :
        IGetPlayerInfo,
        IGetGameRoundPot,
        IGetAutoBetInfo
    { }

    /// <summary>
    /// ดึงข้อมูลผู้เล่น
    /// </summary>
    public interface IGetPlayerInfo
        : IFetchSingleData<UserProfile, GetPlayerInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลเงินในกองของโต๊ะเกม
    /// </summary>
    public interface IGetGameRoundPot
        : IFetchSingleData<int, GetGameRoundPotCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลการลงพนันอัตโนมัติ
    /// </summary>
    public interface IGetAutoBetInfo
        : IFetchSingleData<GamePlayAutoBetInformation, StopAutoBetCommand>
    { }
}
