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
        /// ข้อมูลการขอดูข้อมูลผู้ชนะ
        /// 1. RoundID รอบของโต๊ะเกมที่ต้องการ
        /// 2. UserName ชื่อผู้เล่น
        /// 3. ActionType สิ่งที่ทำ
        /// </summary>
        public PlayerActionInformation PlayerActionInfo { get; set; }

        //output
        /// <summary>
        /// รหัสตรวจสอบ
        /// </summary>
        public Guid OnGoingTrackingID { get; set; }

    }
}
