using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;

namespace TheS.Casinova.TwoWins.DAL
{
    public interface ITwoWinsGameDataQuery :
        IGetGameStatus,
        IListBetLogInfo,
        IListGamePlayInfo,
        IListGameRoundInfo,
        IListRangeActionLog,
        IListSingleActionLog
    { }

    /// <summary>
    /// ดึงข้อมูลผลผู้ชนะระหว่างเกม
    /// </summary>
    public interface IGetGameStatus
        : IFetchSingleData<RoundWinnerInformation,GetGameStatusCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลประวัติการลงพนันในเกมของตัวผู้เล่นเอง
    /// </summary>
    public interface IListBetLogInfo
        : IFetchData<BetInformation, ListBetLogInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลเงินรวมของทุกโต๊ะเกมที่ผู้เล่นเคยลงพนันไว้
    /// </summary>
    public interface IListGamePlayInfo
       : IFetchData<BetInformation, ListGamePlayInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลโต๊ะเกมที่ active
    /// </summary>
    public interface IListGameRoundInfo
       : IFetchData<RoundInformation, ListGameRoundInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลประวัติการลงพนันแบบเป็นช่วง
    /// </summary>
    public interface IListRangeActionLog
       : IFetchData<ActionLogInformation, ListRangeActionLogCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลประวัติการพนันแบบเป็นโต๊ะ
    /// </summary>
    public interface IListSingleActionLog
       : IFetchData<ActionLogInformation, ListSingleActionLogCommand>
    { }
}
