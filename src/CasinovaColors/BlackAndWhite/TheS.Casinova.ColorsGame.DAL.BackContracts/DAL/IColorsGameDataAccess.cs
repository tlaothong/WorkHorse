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

    public interface IPayForColorsWinnerInfo : IDataAction<PlayerInformation, PayForColorsWinnerInfoCommand>
    { }

    public interface IUpdateWinnerToGamePlayInfo : IDataAction<GamePlayInformation, PayForColorsWinnerInfoCommand>
    { }
}
