using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลการลงพนัน
    /// </summary>
    public class GetBetInfoCommand
    {
        //input
        /// <summary>
        /// รหัสมือที่ต้องการดึงข้อมูล
        /// </summary>
        public int HandID { get; set; }

        /// <summary>
        /// โต๊ะเกมของข้อมูลที่ลงพนัน
        /// </summary>
        public int RoundID { get; set; }

        //output
        /// <summary>
        /// ข้อมูลการลงพนันที่ต้องการ
        /// </summary>
        public BetInformation BetInfo { get; set; }
    }
}
