using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.MagicNine.DAL
{
    public interface IMagicNineGameDataAccess :
        ISingleBet
    { }

    /// <summary>
    /// บันทึกข้อมูลการลงพนันแบบด้วยผู้เลยเอง
    /// </summary>
    public interface ISingleBet
        : ICreateData<BetInformation, SingleBetCommand>
    { }

    /// <summary>
    /// อัพเดทข้อมูลผู้เล่น
    /// </summary>
    public interface IUpdatePlayerInfoBalance
        : IDataAction<PlayerInformation, UpdatePlayerInfoBalanceCommand>
    { }
}
