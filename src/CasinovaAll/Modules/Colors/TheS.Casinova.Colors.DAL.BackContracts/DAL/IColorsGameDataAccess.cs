using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.TwoWins.DAL
{
    public interface IColorsGameDataAccess :
        IUpdatePlayerInfoBalance,
        ICreatePlayerActionInfo,
        IUpdateOnGoingTrackingID,
        IUpdateRoundWinner,
        ICreateGameRoundConfigurations,
        ICreateGameRound
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
    /// บันทึกการตั้งค่าสำหรับสร้างโต๊ะเกมใหม่
    /// </summary>
    public interface ICreateGameRoundConfigurations
        : ICreateData<GameRoundConfiguration, CreateGameRoundConfigurationCommand>
    { }

    /// <summary>
    /// สร้างโต๊ะเกมใหม่
    /// </summary>
    public interface ICreateGameRound
        : ICreateData<GameRoundInformation, CreateGameRoundCommand>
    { }
}
