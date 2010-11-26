using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.BackServices.Commands;

namespace TheS.Casinova.ChipExchange.BackServices
{
    public interface IPayExchangeEngine
    {
        bool PayExchange(PayExchangeCommand command);
    }
}
