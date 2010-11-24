using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.MagicNine.DAL
{
    public interface IMagicNineGameDataBackQuery :
        IGetPlayerInfo,
        IGetGameRoundPot
    { }

    /// <summary>
    /// ดึงข้อมูลผู้เล่น
    /// </summary>
    public interface IGetPlayerInfo
        : IFetchSingleData<PlayerInformation, GetPlayerInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลเงินในกองของโต๊ะเกม
    /// </summary>
    public interface IGetGameRoundPot
        : IFetchSingleData<int, GetGameRoundPotCommand>
    { }
}
