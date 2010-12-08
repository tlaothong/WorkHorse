using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    public class ListGamePlayInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อลิสต์จำนวนเงินรวมทั้งหมดที่ลงเดิมพัน
        /// 1. UserName ชื่อผู้เล่น
        /// </summary>
        public BetInformation GamePlayInfo { get; set; }

        //output
        public IEnumerable<BetInformation> GamePlayInformation { get; set; }
    }
}
