using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;

namespace TheS.Casinova.ColorsGame.DAL
{
    public interface IColorsGameDataBackQuery :
        IGetRoundWinnerQuery,
        IListGameTableConfigurations,
        IListActiveGameRounds
    { }

    //ดึงข้อมูล Winner ที่ผู้เล่นเสียเงินโต๊ะที่ดู
    public interface IGetRoundWinnerQuery
        : IFetchSingleData<string, PayForColorsWinnerInfoCommand>
    { }

    //ดึงข้อมูล Table configuration ที่ตั้งค่าไว้
    public interface IListGameTableConfigurations
        : IFetchData<TableConfiguration, ListGameTableConfigurationCommand>
    { }

    //ดึงข้อมูล Game round ที่ยังไม่หมดเวลา
    public interface IListActiveGameRounds
        : IFetchData<GameRoundInformation, ListActiveGameRoundsCommand>
    { }
}
