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

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        /// <summary>
        /// การตั้งค่าที่ต้องการดึงข้อมูล
        /// 1.Name ชื่อการตั้งค่า
        /// </summary>
        public ExchangeSettingInformation ExchangeSettingInput { get; set; }
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        //output
        /// <summary>
        /// ข้อมูลการตั้งค่า
        /// </summary>       
        public ExchangeSettingInformation ExchangeSetting { get; set; }
    }
}
