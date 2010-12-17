using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลโต๊ะเกม
    /// </summary>
    public class GetRoundInfoCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมที่ต้องการข้อมูล
        /// </summary>
        public int RoundID { get; set; }

        //output
        /// <summary>
        /// ข้อมูลโต๊ะเกมที่ต้องการ
        /// </summary>
        public RoundInformation RoundInfo { get; set; }
    }
}
