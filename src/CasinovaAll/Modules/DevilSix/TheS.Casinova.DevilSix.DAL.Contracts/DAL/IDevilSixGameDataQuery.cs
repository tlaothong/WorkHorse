using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.DevilSix.Models;
using TheS.Casinova.DevilSix.Commands;

namespace TheS.Casinova.DevilSix.DAL
{
    public interface IDevilSixGameDataQuery :
                       IListBetLog,
                       IListActiveGameRoundInfo,
                       IListGamePlayAutoBetInfo,
                       IListSingleActionLog,
                       IListRangeActionLog
    { }

    /// <summary>
    /// ดึงข้อมูลผลการลงเดิมพันของผู้เล่น
    /// </summary>
    public interface IListBetLog
         : IFetchData<BetInformation, ListBetLogCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลโต๊ะเกมที่กำลัง active
    /// </summary>
    public interface IListActiveGameRoundInfo
         : IFetchData<GameRoundInformation, ListActiveGameRoundInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลการลงเดิมพันแบบอัตโนมัติของผู้เล่นที่ลงไว้
    /// </summary>
    public interface IListGamePlayAutoBetInfo
         : IFetchData<GamePlayAutoBetInformation, ListGamePlayAutoBetInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูล log การลงเดิมพันที่ชนะในโต๊ะเกมนั้น ๆ ตามวันที่ผู้เล่นเลือกดู
    /// </summary>
    public interface IListSingleActionLog
         : IFetchData<BetInformation, ListSingleActionLogCommand>
    { }

    /// <summary>
    /// ดึงข้อมูล log การลงเดิมพันที่ชนะในโต๊ะเกมนั้น ๆ ตามช่วงวันที่ผู้เล่นเลือกดู
    /// </summary>
    public interface IListRangeActionLog
         : IFetchData<BetInformation, ListRangeActionLogCommand>
    { }
}
