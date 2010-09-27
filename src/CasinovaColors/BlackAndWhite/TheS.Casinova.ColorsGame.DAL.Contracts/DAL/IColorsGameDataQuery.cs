using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;

namespace TheS.Casinova.ColorsGame.DAL
{
    public interface IColorsGameDataQuery :
        IGetGamePlayInfoQuery
    //IGetRoundWinnerQuery
    { }

    public interface IGetGamePlayInfoQuery
        : IFetchData<GamePlayInformation, GetGamePlayInfoCommand>
    {
        IEnumerable<GamePlayInformation> Get(GetGamePlayInfoCommand cmd);
    }

    //public interface IGetRoundWinnerQuery
    //{
    //    IEnumerable<GamePlayInformation> Get(GetGamePlayInfoCommand cmd);
    //}
}
