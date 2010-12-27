using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// ดึงข้อมูลเงินในกองของโต๊ะเกม
    /// </summary>
    public class GetGameRoundPotCommand
    {
        //intput
        
        /// <summary>
        /// รหัสโต๊ะเกมที่ต้องการข้อมูลเงินในกอง
        /// </summary>
        public int RoundID { get; set; }

        //output

        /// <summary>
        /// เงินในกอง ที่ต้องการ
        /// </summary>
        public double Pot { get; set; }
    }
}
