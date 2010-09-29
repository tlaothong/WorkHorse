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
        IPayForColorsWinnerInfo,
        IUpdateOnGoingTrackingID
    { }

    /// <summary>
    /// หักเงินผู้เล่นค่าดูข้อมูลผู้ชนะในเวลานั้น
    /// </summary>
    public interface IPayForColorsWinnerInfo
        : IDataAction<PlayerInformation, PayForColorsWinnerInfoCommand>
    { }

    /// <summary>
    /// บันทึกรหัส TrackingID สำรวจตรวจสอบการทำงาน
    /// </summary>
    public interface IUpdateOnGoingTrackingID
        : IDataAction<GamePlayInformation, PayForColorsWinnerInfoCommand>
    { }
}
