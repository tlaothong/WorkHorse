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
        IGetGameRoundInfoQuery,
        IGetPlayerInfoQuery,
        IListPlayerActionInfoQuery
    { }
    
    /// <summary>
    /// ดึงข้อมูล Winner ที่ผู้เล่นเสียเงินโต๊ะที่ดู
    /// </summary>
    public interface IGetGameRoundInfoQuery
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
    public interface IListPlayerActionInfoQuery
        : IFetchData<PlayerActionInformation, PayForColorsWinnerInfoCommand>
    { }
}
