using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.MagicNine.DAL
{
    public interface IMagicNineGameDataQuery :
                       IListBetLog,
                       IListActiveGameRound
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
    public interface IListActiveGameRound
         : IFetchData<GameRoundInformation, ListActiveGameRoundCommand>
    { }
}
