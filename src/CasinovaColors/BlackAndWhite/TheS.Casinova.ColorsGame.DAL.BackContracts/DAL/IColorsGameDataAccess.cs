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
        IUpdateWinnerToGamePlayInfo,
        ISaveTableConfiguration,
        ICreateGameRound
    { }

    //หักเงินผู้เล่น
    public interface IPayForColorsWinnerInfo
        : IDataAction<PlayerInformation, PayForColorsWinnerInfoCommand>
    { }

    //อัพเดทข้อมูล game information โต๊ะที่เสียเงินดู Winner (TrackingID, OnGoingTrackingID, Winner, LastUpdate)
    public interface IUpdateWinnerToGamePlayInfo
        : IDataAction<GamePlayInformation, PayForColorsWinnerInfoCommand>
    { }

    //บันทึกข้อมูล TableConfiguration ใหม่
    public interface ISaveTableConfiguration
        : ICreateData<TableConfiguration, SaveTableConfigurationCommand>
    { }

    //บันทึกข้อมูลก GameRound ใหม่
    public interface ICreateGameRound
        : ICreateData<GameRoundInformation, CreateGameRoundCommand>
    { }
}
