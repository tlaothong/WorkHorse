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
        IGetUserProfile,
        IGetBetInfo,
        IListBetInfoByRoundID,
        IGetRoundWinnerInfo,
        IListBetInfoByBetAmount,
        IGetSettingInfo
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

    /// <summary>
    /// ดึงข้อมูลการลงพนัน
    /// </summary>
    public interface IGetBetInfo
        : IFetchSingleData<BetInformation, GetBetInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลการลงพนันทั้งหมดของโต๊ะเกม
    /// </summary>
    public interface IListBetInfoByRoundID
        : IFetchData<BetInformation, ListBetInfoByRoundIDCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลผู้ชนะในโต๊ะเกม
    /// </summary>
    public interface IGetRoundWinnerInfo
        : IFetchSingleData<RoundWinnerInformation, GetRoundWinnerCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลการลงพนันด้วยจำนวนที่ลงพนัน
    /// </summary>
    public interface IListBetInfoByBetAmount
        : IFetchData<BetInformation, ListBetInfoByBetAmountCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลการตั้งค่า
    /// </summary>
    public interface IGetSettingInfo
        : IFetchSingleData<SettingInformation, GetSettingInfoCommand>
    { }
}
