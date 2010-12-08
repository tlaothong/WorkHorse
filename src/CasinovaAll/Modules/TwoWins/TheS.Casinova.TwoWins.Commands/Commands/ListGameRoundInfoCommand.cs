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
        /// ข้อมูลการลิสต์โต๊ะเกมที่ active
        /// 1. Active สถานะโต๊ะเกม
        /// </summary>
        public RoundInformation RoundInfo { get; set; }

        //output
        public IEnumerable<RoundInformation> RoundInformation { get; set; }

    }
}
