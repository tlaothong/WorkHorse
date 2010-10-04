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
        IUpdatePlayerInfo,
        ICreatePlayerActionInfo,
        IUpdateRoundWinner
    { }

    /// <summary>
    /// หักเงินผู้เล่นค่าดูข้อมูลผู้ชนะในเวลานั้น
    /// </summary>
    public interface IUpdatePlayerInfo
        : IDataAction<PlayerInformation, PayForColorsWinnerInfoCommand>
    { }

    /// <summary>
    /// เพิ่มข้อมูลการดูข้อมูลผู้ชนะในเวลานั้น หลังจากหักเงินผู้เล่น
    /// </summary>
    public interface ICreatePlayerActionInfo
        : ICreateData<PlayerActionInformation, PayForColorsWinnerInfoCommand>
    { }

    /// <summary>
    /// บันทึกรหัส TrackingID สำรวจตรวจสอบการทำงาน
    /// </summary>
    public interface IUpdateOnGoingTrackingID
        : IDataAction<GamePlayInformation, PayForColorsWinnerInfoCommand>
    { }

    /// <summary>
    /// บันทึกข้อมูล Winner และ TrackingID 
    /// </summary>
    public interface IUpdateRoundWinner
        : IDataAction<GamePlayInformation, PayForColorsWinnerInfoCommand>
    { }

}
