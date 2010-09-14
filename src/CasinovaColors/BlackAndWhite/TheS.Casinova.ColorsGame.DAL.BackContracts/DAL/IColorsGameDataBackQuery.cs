using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;

namespace TheS.Casinova.ColorsGame.DAL
{
    public interface IColorsGameDataBackQuery :
        IGetRoundWinnerQuery
    { }

    public interface IGetRoundWinnerQuery
        : IFetchSingleData<string, PayForColorsWinnerInfoCommand>
    { }
}
