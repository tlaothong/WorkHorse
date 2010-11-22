using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// command ดึงข้อมูลสีที่ชนะเมื่อชำระเงิน
    /// </summary>
    public class PayForColorsWinnerInfoCommand       
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมที่ขอข้อมูล
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่นที่ทำรายการ
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสตรวจสอบ
        /// </summary>
        public Guid OnGoingTrackingID { get; set; }

        /// <summary>
        /// จำนวนเงินค่าทำรายการ
        /// </summary>
        public double Amount { get; set; }

        ////ข้อมูลผู้เล่นสำหรับหักเงินค่าดูข้อมูลผู้ชนะขณะนั้น
        //public PlayerInformation PlayerInfo { get; set; }

        ////ข้อมูลการลงพนันของผู้เล่น
        //public GamePlayInformation GamePlayInfo { get; set; }

        ////ข้อมูลทั่วไปของโต๊ะเกม
        //public GameRoundInformation GameRoundInfo { get; set; }
    }
}
