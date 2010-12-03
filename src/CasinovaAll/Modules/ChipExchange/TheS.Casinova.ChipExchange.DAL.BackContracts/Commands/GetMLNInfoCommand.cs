using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// ดึงข้อมูล MLN ของผู้เล่น
    /// </summary>
    public class GetMLNInfoCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        /// <summary>
        /// ข้อมูล MLN ของผู้เล่นที่ต้องการดึงข้อมูล
        /// 1.UserName ชื่อผู้เล่น
        /// </summary>
        public MultiLevelNetworkInformation MLNInfoInput { get; set; }
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        //output
        /// <summary>
        /// ข้อมูล MLN ที่ต้องการ
        /// </summary>
        public MultiLevelNetworkInformation MLNInfo { get; set; }
    }
}
