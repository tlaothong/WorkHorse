using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.Colors.DAL
{
    public interface IColorsGameDataAccess :
        IUpdatePlayerInfoBalance,
        ICreatePlayerActionInfo,
        IUpdateOnGoingTrackingID,
        IUpdateRoundWinner,
        ICreateGameRoundConfiguration
    { }

    /// <summary>
    /// อัพเดทข้อมูลผู้เล่น
    /// </summary>
    public interface IUpdatePlayerInfoBalance
        : IDataAction<PlayerInformation, UpdatePlayerInfoBalanceCommand>
    { }

    /// <summary>
    /// เพิ่มประวัติการดำเนินงานของผู้เล่น
    /// </summary>
    public interface ICreatePlayerActionInfo
        : ICreateData<PlayerActionInformation, CreatePlayerActionInfoCommand>
    { }

    /// <summary>
    /// บันทึกรหัส TrackingID สำรวจตรวจสอบการทำงาน
    /// </summary>
    public interface IUpdateOnGoingTrackingID
        : IDataAction<GamePlayInformation, UpdateOnGoingTrackingIDCommand>
    { }

    /// <summary>
    /// บันทึกข้อมูล Winner และ TrackingID 
    /// </summary>
    public interface IUpdateRoundWinner
        : IDataAction<GamePlayInformation, UpdateRoundWinnerCommand>
    { }

    /// <summary>
    /// สร้างโต๊ะเกมใหม่
    /// </summary>
    public interface ICreateGameRoundConfiguration
        : ICreateData<GameRoundConfiguration, CreateGameRoundConfigurationsCommand>
    { }
}
