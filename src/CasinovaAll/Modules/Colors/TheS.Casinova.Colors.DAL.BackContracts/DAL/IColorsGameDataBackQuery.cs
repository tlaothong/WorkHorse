using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.DAL
{
    public interface IColorsGameDataBackQuery : 
        IGetRoundWinnerQuery,
        IGetPlayerInfoQuery,
        IListBetLogQuery
    { }
    
    /// <summary>
    /// ดึงข้อมูล Winner ที่ผู้เล่นเสียเงินโต๊ะที่ดู
    /// </summary>
    public interface IGetRoundWinnerQuery
        : IFetchSingleData<GameRoundInformation, PayForColorsWinnerInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลทั่วไปของผู้เล่น
    /// </summary>
    public interface IGetPlayerInfoQuery
        : IFetchSingleData<double, PayForColorsWinnerInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลการลงพนันของผู้เล่นในโต๊ะเกมนั้นๆ
    /// </summary>
    public interface IListBetLogQuery
        : IFetchData<BetInformation, PayForColorsWinnerInfoCommand>
    { }
}
