using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;

namespace TheS.Casinova.PlayerAccount.DAL
{
    public interface IPlayerAccountModuleDataQuery:
        IGetPlayerAccount,
        IListPlayerAccount
    {}

    /// <summary>
    /// ดึงข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public interface IGetPlayerAccount
        : IFetchSingleData<PlayerAccountInformation, GetPlayerAccountCommand>
    { }

     /// <summary>
    /// ลิสต์ข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public interface IListPlayerAccount
        : IFetchData<PlayerAccountInformation, ListPlayerAccountCommand>
    { }
}
