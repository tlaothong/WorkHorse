using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.Colors.DAL
{
    public interface IColorsGameDataQuery :
        IListActiveGameRounds,
        IListGamePlayInformation,
        IGetGameResult,
        IGetBalance,
        IGetGameRoundConfigurations

    
    {}

    /// <summary>
    /// List ข้อมูลโต๊ะเกมที่ active
    /// </summary>
    public interface IListActiveGameRounds
         : IFetchData<GameRoundInformation, ListActiveGameRoundCommand>
    { }

    /// <summary>
    /// list ข้อมูลโต๊ะเกมที่ผู้เล่น เคยเล่นไว้
    /// </summary>
    public interface IListGamePlayInformation
        : IFetchData<GamePlayInformation, ListGamePlayInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลผลการเล่นเกม
    /// </summary>
    public interface IGetGameResult
        : IFetchSingleData<GameRoundInformation, GetGameResultCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลยอดเงินในบัญชี
    /// </summary>
    public interface IGetBalance
        : IFetchSingleData<UserProfile, GetBalanceCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลการ config จำนวนโต๊ะ เพื่อตรวจสอบจำนวนโต๊ะเกมที่จะสร้างเพิ่ม
    /// </summary>
    public interface IGetGameRoundConfigurations
        : IFetchSingleData<GameRoundConfiguration,GetGameRoundConfigurationCommand> 
    {}
}
