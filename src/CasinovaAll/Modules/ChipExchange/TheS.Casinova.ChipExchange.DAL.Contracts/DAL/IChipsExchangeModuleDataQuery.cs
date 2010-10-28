using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.ChipExchange.DAL
{
    public interface IChipsExchangeModuleDataQuery :
        IGetVoucherCode,
        IGetPlayerBalance
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
}
