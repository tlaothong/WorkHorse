using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลผู้ชนะของโต๊ะเกม
    /// </summary>
    public class GetRoundWinnerCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมที่ต้องการดึงข้อมูล
        /// </summary>
        public int RoundID { get; set; }

        //output
        /// <summary>
        /// ข้อมูลผู้ชนะในโต๊ะเกม
        /// </summary>
        public RoundWinnerInformation RoundWinnerInfo { get; set; }
    }
}
