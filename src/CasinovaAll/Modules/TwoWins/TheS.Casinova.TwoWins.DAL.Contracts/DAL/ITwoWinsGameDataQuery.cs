using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Command;

namespace TheS.Casinova.TwoWins.DAL
{
    public interface ITwoWinsGameDataQuery :
        IGetGameStatus,
        IListBetLogInfo,
        IListGamePlayInfo,
        IListGameRoundInfo,
        IListRangeActionLog,
        IListSingleActionLog,
        IListBetData,
        IGetRoundWinnerAmount
    { }

    /// <summary>
    /// ดึงข้อมูลผลผู้ชนะระหว่างเกม
    /// </summary>
    public interface IGetGameStatus
        : IFetchSingleData<RoundInformation, GetGameStatusCommand>
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
       : IFetchData<TotalBetInformation, ListGamePlayInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลโต๊ะเกมที่ active
    /// </summary>
    public interface IListGameRoundInfo
       : IFetchData<RoundInformation, ListGameRoundInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลสถิติการลงพนันแบบเป็นช่วง โดยจะสรุปข้อมูลผู้ชนะ
    /// </summary>
    public interface IListRangeActionLog
       : IFetchData<ActionLogInformation, ListRangeActionLogCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลสถิติการลงพนันแบบเป็นโต๊ะโดยละเอียด
    /// </summary>
    public interface IListSingleActionLog
       : IFetchData<ActionLogInformation, ListSingleActionLogCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลสถิติการลงพนันแบบเป็นช่วงโดยละเอียด
    /// </summary>
    public interface IListBetData
       : IFetchData<ActionLogInformation, ListBetDataCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลสถิติการลงพนันแบบเป็นช่วงโดยละเอียด
    /// </summary>
    public interface IGetRoundWinnerAmount
       : IFetchSingleData<RoundWinnerInformation, GetRoundWinnerAmountCommand >
    { }
}
