using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    public class ListBetLogInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อลิสต์ข้อมูลการลงพนัน
        /// 1.UserName ชื่อผู้เล่น
        /// 2.RoundID รหัสโต๊ะเกม
        /// </summary>
        public BetInformation BetInfo { get; set; }

        //ouput
        /// <summary>
        /// ข้อมูลการลงพนันของผู้เล่น
        /// </summary>
        public IEnumerable<BetInformation> BetInformation { get; set; }
    }
}
    