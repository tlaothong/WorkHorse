using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// อัพเดทข้อมูลผู้ชนะในโต๊ะเกมที่ผู้เล่นลงพนันไว้
    /// </summary>
    public class UpdateRoundWinnerCommand 
        : PayForColorsWinnerInfoCommand
    {
        //input
        /// <summary>
        /// รหัสสำหรับตรวจสอบความถูกต้อง
        /// </summary>
        public Guid TrackingID { get; set; }

        /// <summary>
        /// เวลาที่อัพเดทข้อมูล
        /// </summary>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// ข้อมูลผู้ชนะ
        /// </summary>
        public string Winner { get; set; }
    }
}
