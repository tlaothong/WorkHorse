using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.Colors.DAL
{
    public interface IColorsGameDataQuery :
        IListActiveGameRounds,
        IListGamePlayInformation,
        IGetGameResult

    
    {}

    /// <summary>
    /// List ข้อมูลโต๊ะเกมที่ active
    /// </summary>
    public interface IListActiveGameRounds
         : IFetchData<ActiveGameRounds, ListActiveGameRoundsCommand>
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
}
