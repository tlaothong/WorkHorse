using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Models;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.TwoWins.DAL
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
        : IFetchSingleData<PlayerInformation, GetBalanceCommand>
    { }

    public interface IGetGameRoundConfigurations
        : IFetchSingleData<GameRoundConfiguration,GetGameRoundConfigurationCommand> 
    {}
}
