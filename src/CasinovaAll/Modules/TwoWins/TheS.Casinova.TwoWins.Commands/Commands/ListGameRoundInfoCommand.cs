using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    public class ListGameRoundInfoCommand
    {
        //input
        /// <summary>
        /// เวลาปัจจุบันที่ผู้เล่นเข้าห้องเกม
        /// </summary>
        public DateTime FromTime { get; set; } 

        //output
        /// <summary>
        /// ข้อมูลโต๊ะเกมที่ active
        /// </summary>
        public IEnumerable<RoundInformation> RoundInformation { get; set; }

    }
}
