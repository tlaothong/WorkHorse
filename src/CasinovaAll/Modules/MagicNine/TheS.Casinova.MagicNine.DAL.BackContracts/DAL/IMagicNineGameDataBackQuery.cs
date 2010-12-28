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
        IGetAutoBetInfo,
        IGetGameRoundInfo
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
        : IFetchSingleData<double, GetGameRoundPotCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลการลงพนันอัตโนมัติ
    /// </summary>
    public interface IGetAutoBetInfo
        : IFetchSingleData<GamePlayAutoBetInformation, StopAutoBetCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลโต๊ะเกม
    /// </summary>
    public interface IGetGameRoundInfo
        : IFetchSingleData<GameRoundInformation, GetGameRoundInfoCommand>
    { }
}
