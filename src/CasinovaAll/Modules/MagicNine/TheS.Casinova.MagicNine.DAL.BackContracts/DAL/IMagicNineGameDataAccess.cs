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
    public interface IMagicNineGameDataAccess :
        ISingleBet,
        ICreateAutoBetInfo,
        IUpdatePlayerInfoBalance,
        IUpdateGameRoundPot,
        IUpdateAutoBetInfo
    { }

    /// <summary>
    /// บันทึกข้อมูลการลงพนันแบบด้วยผู้เลยเอง
    /// </summary>
    public interface ISingleBet
        : ICreateData<BetInformation, SingleBetCommand>
    { }

    /// <summary>
    /// บันทึกข้อมูลการลงพนันอัตโนมัติ
    /// </summary>
    public interface ICreateAutoBetInfo
        : ICreateData<GamePlayAutoBetInformation, StartAutoBetCommand>
    { }

    /// <summary>
    /// อัพเดทข้อมูลผู้เล่น
    /// </summary>
    public interface IUpdatePlayerInfoBalance
        : IDataAction<UserProfile, UpdatePlayerInfoBalanceCommand>
    { }

    /// <summary>
    /// อัพเดทเงินกองกลางในโต๊ะเกม
    /// </summary>
    public interface IUpdateGameRoundPot
        : IDataAction<GameRoundInformation, UpdateGameRoundPotCommand>
    { }

    /// <summary>
    /// อัพเดทข้อมูล stop trackingID เมื่อมีการหยุด autobet
    /// </summary>
    public interface IUpdateAutoBetInfo
        : IDataAction<GamePlayAutoBetInformation, StopAutoBetCommand>
    { }
}
