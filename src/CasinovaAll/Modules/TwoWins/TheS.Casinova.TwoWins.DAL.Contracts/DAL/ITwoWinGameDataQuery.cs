using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;

namespace TheS.Casinova.TwoWins.DAL
{
    public interface ITwoWinGameDataQuery
    { }

    public interface IGetGameStatus
        : IFetchSingleData<RoundWinnerInformation,GetGameStatusCommand>
    { }

    public interface IListBetLogInfo
        : IFetchData<BetInformation, ListBetLogInfoCommand>
    { }
}
