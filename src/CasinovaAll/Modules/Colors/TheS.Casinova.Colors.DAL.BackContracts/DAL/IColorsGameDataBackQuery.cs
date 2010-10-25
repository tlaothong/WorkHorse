using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.DAL
{
    public interface IColorsGameDataBackQuery : 
        IGetRoundInfo,
        IListPlayerActionInfoQuery,
        IGetPlayerInfo,
        IListActiveGameRounds,
        IGetGameRoundConfiguration
    { }
    
    /// <summary>
    /// ดึงข้อมูลผู้เล่น
    /// </summary>
    public interface IGetPlayerInfo
        : IFetchSingleData<PlayerInformation, GetPlayerInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูล Winner ที่ผู้เล่นเสียเงินโต๊ะที่ดู
    /// </summary>
    public interface IGetRoundInfo
        : IFetchSingleData<GameRoundInformation, GetRoundInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลการลงพนันของผู้เล่นในโต๊ะเกมนั้นๆ
    /// </summary>
    public interface IListPlayerActionInfoQuery
        : IFetchData<PlayerActionInformation, PayForColorsWinnerInfoCommand>
    { }

    /// <summary>
    /// List ข้อมูลโต๊ะเกมที่ active
    /// </summary>
    public interface IListActiveGameRounds
        : IFetchData<GameRoundInformation, ListActiveGameRoundCommand>
    { }

    /// <summary>
    /// ดึงข้อมูล config ของการสร้างโต๊ะเกม
    /// </summary>
    public interface IGetGameRoundConfiguration
        : IFetchSingleData<GameRoundConfiguration, GetGameRoundConfigurationCommand>
    { }
}
