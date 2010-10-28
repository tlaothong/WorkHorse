using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.ChipExchange.DAL
{
    public interface IChipExchangeDataBackQuery:
        IGetExchangeSetting,
        IGetPlayerAccountInfo
    { }

    public interface IGetExchangeSetting
        : IFetchSingleData<ExchangeSetting, GetExchangeSettingCommand>
    { }

    public interface IGetPlayerAccountInfo
        : IFetchSingleData<PlayerAccountInformation, GetPlayerAccountInfoCommand>
    { }
}
