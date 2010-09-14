using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;

namespace TheS.Casinova.ColorsGame.DAL
{
    public interface IColorsGameDataAccess :
        IPayForColorsWinnerInfo,
        IUpdateWinnerToGamePlayInfo
    { }

    //หักเงินผู้เล่น
    public interface IPayForColorsWinnerInfo
        : IDataAction<PlayerInformation, PayForColorsWinnerInfoCommand>
    { }

    //อัพเดทข้อมูล game information โต๊ะที่เสียเงินดู Winner (TrackingID, OnGoingTrackingID, Winner, LastUpdate)
    public interface IUpdateWinnerToGamePlayInfo
        : IDataAction<GamePlayInformation, PayForColorsWinnerInfoCommand>
    { }
}
