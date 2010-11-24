using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.ChipExchange.DAL
{
    public interface IChipExchangeDataBackQuery:
        IGetExchangeSetting,
        IGetPlayerAccountInfo,
        IGetMLNInfo,
        IGetVoucherInfo
    { }

    public interface IGetExchangeSetting
        : IFetchSingleData<ExchangeSetting, GetExchangeSettingCommand>
    { }

    public interface IGetPlayerAccountInfo
        : IFetchSingleData<PlayerAccountInformation, GetPlayerAccountInfoCommand>
    { }

    public interface IGetMLNInfo
        : IFetchSingleData<MultiLevelNetworkInformation, GetMLNInfoCommand>
    { }

    public interface IGetVoucherInfo
        : IFetchSingleData<VoucherInformation, GetVoucherInfoCommand>
    { }
}
