using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.MagicNine.DAL
{
    public interface IMagicNineGameDataBackQuery :
        IListBetLog,
        IGetPlayerInfo,
        IListGameRoundInfo
    { }

    /// <summary>
    /// ดึงข้อมูลการลงพนันทั้งหมดในโต๊ะเกมที่ผู้เล่นลงพนันไว้    
    /// </summary>
    public interface IListBetLog
        : IFetchData<BetInformation, ListBetLogCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลผู้เล่น
    /// </summary>
    public interface IGetPlayerInfo
        : IFetchSingleData<PlayerInformation, GetPlayerInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลโต๊ะเกมทั้งหมด
    /// </summary>
    public interface IListGameRoundInfo
        : IFetchData<GameRoundInformation, ListGameRoundCommand>
    { }
}
