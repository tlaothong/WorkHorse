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
        /// ข้อมูลการขอดูสีที่ชนะ
        /// </summary>
        public PlayerActionInformation PlayerActionInfoUserName { get; set; }

        //out
        /// <summary>
        /// รหัสตรวจสอบ
        /// </summary>
        public Guid OnGoingTrackingID { get; set; }

    }
}
