using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.PlayerAccount.DAL
{
    public interface IPlayerAccountDataAccess:
        ICreatePlayerAccount,
        IEditPlayerAccount,
        ICancelPlayerAccount
    { }

    /// <summary>
    /// เพิ่มบัญชีของผู้เล่น
    /// </summary>
    public interface ICreatePlayerAccount
        : ICreateData<PlayerAccountInformation, CreatePlayerAccountCommand>
    { }

    /// <summary>
    /// แก้ไขบัญชีของผู้เล่น
    /// </summary>
    public interface IEditPlayerAccount
        : IDataAction<PlayerAccountInformation, EditPlayerAccountCommand>
    { }

    /// <summary>
    /// ยกเลิกการใช้งานบัญชีของผู้เล่น
    /// </summary>
    public interface ICancelPlayerAccount
        : IDataAction<PlayerAccountInformation, CancelPlayerAccountCommand>
    { }
}
