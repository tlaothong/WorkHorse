using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.DAL
{
    public interface IChipExchangeDataAccess:
        IIncreasePlayerChipsByMoney,
        IIncreasePlayerBonusChipsByMoney,
        IIncreasePlayerBonusChipsByVoucher,
        IUpdateUserProfile,
        IUpdateUsedVoucher,
        ICreateVoucherInformation
    { }

    public interface IIncreasePlayerChipsByMoney
        : IDataAction<ExchangeInformation, MoneyToChipsCommand>
    { }

    public interface IIncreasePlayerBonusChipsByVoucher
        : IDataAction<ExchangeInformation, VoucherToBonusChipsCommand>
    { }

    public interface IIncreasePlayerBonusChipsByMoney
        : IDataAction<ExchangeInformation, MoneyToBonusChipsCommand>
    { }

    public interface IUpdateUserProfile
        : IDataAction<UserProfile, PayVoucherCommand>
    { }

    public interface IUpdateUsedVoucher
        : IDataAction<VoucherInformation, UpdateUsedVoucherCommand>
    { }

    public interface ICreateVoucherInformation
        : ICreateData<VoucherInformation, PayVoucherCommand>
    { }
}
