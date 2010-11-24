using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Commands;

namespace TheS.Casinova.PlayerAccount.BackServices
{
    public interface IPlayerAccountModuleBackService :
        ICreatePlayerAccount,
        IEditPlayerAccount,
        ICancelPlayerAccount
    { }

    /// <summary>
    /// ส่งค่า command เพื่อสร้างบัญชีของผู้เล่น
    /// </summary>
    public interface ICreatePlayerAccount
    {
        void CreatePlayerAccount(CreatePlayerAccountCommand cmd);
    }

    /// <summary>
    /// ส่งค่า command เพื่อแก้ไขบัญชีของผู้เล่น
    /// </summary>
    public interface IEditPlayerAccount
    {
        void EditPlayerAccount(EditPlayerAccountCommand cmd);
    }

    /// <summary>
    /// ส่งค่า command เพื่อยกเลิกบัญชีของผู้เล่น
    /// </summary>
    public interface ICancelPlayerAccount
    {
        void CancelPlayerAccount(CancelPlayerAccountCommand cmd);
    }
}
