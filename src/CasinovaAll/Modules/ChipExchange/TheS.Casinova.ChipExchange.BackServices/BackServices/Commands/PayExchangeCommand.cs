using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.BackServices.Commands
{
    public class PayExchangeCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการแลกชิป
        /// </summary>
        public ExchangeInformation ExchangeInfo { get; set; }
    }
}
