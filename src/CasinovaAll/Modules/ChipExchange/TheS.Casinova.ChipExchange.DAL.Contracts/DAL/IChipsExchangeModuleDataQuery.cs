using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.ChipExchange.Command;

namespace TheS.Casinova.ChipExchange.DAL
{
    public interface IChipsExchangeModuleDataQuery :
        IGetVoucherCode,
        IGetPlayerBalance,
        IGetPlayerAccountInfo,
        IGetMultiLevelNetworkInfo,
        IGetVoucherInfo
    {}

    /// <summary>
    /// ดึงข้อมูลหมายเลขคูปอง
    /// </summary>
    public interface IGetVoucherCode
         : IFetchSingleData<VoucherInformation, GetVoucherCodeCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลจำนวนชิพเป็น ชิพตาย
    /// </summary>
    public interface IGetPlayerBalance
         : IFetchSingleData<UserProfile, GetPlayerBalanceCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลบัญชีบัตรเครดิต
    /// </summary>
    public interface IGetPlayerAccountInfo
         : IFetchSingleData<PlayerAccountInformation, GetPlayerAccountInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลจำนวนโบนัส
    /// </summary>
    public interface IGetMultiLevelNetworkInfo
         : IFetchSingleData<MultiLevelNetworkInformation, GetMultiLevelNetworkInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลคูปอง
    /// </summary>
    public interface IGetVoucherInfo
         : IFetchSingleData<VoucherInformation, GetVoucherInfoCommand>
    { }
}
