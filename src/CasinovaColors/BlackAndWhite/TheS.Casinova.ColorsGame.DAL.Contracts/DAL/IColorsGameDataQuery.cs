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
        IGetGamePlayerInfoQuery
    { }

    public interface IGetGamePlayerInfoQuery : IFetchData<GamePlayInformation, GetGamePlayInfoCommand>
    { }
}
