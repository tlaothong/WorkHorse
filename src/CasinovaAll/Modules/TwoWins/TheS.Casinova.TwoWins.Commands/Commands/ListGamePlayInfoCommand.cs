using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// command ดึงข้อมูลจำนวนเงินรวมแต่ละโต๊ะที่ผู้เล่นเคยเล่นไว้
    /// </summary>
    public class ListGamePlayInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อลิสต์จำนวนเงินรวมทั้งหมดที่ลงเดิมพัน
        /// 1. UserName ชื่อผู้เล่น
        /// </summary>
        public TotalBetInformation TotalBetInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลจำนวนเงินรวมทั้งหมดในแต่ละโต๊ะที่ผู้เล่นเคยลงไว้
        /// </summary>
        public IEnumerable<TotalBetInformation> GamePlayInfo { get; set; }
    }
}
