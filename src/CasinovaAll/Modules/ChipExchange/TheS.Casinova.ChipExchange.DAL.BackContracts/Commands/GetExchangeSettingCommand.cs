using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// ดึงข้อมูลการตั้งค่า
    /// </summary>
    public class GetExchangeSettingCommand
    {
        // input
        /// <summary>
        /// ชื่อการตั้งค่าที่จะดึงข้อมูล
        /// </summary>
        public string Name{ get; set; }

        //output
        /// <summary>
        /// ข้อมูลการตั้งค่า
        /// </summary>       
        public ExchangeSetting ExchangeSetting { get; set; }
    }
}
