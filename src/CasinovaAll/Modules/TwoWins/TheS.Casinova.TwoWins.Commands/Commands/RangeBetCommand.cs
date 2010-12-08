using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    public class RangeBetCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการลงเดิมพันแบบทีละมือ
        /// 1.UserName ชื่อผู้เล่น
        /// 2.FromAmount จำนวนเงินเริ่มต้นที่ลงเดิมพัน
        /// 3.ThruAmount จำนวนเงินสิ้นสุดที่ลงเดิมพัน
        /// 4.RoundID รหัสโต๊ะเกม
        /// 5.DateTime เวลาที่ทำการลงเดิมพัน
        /// </summary>
        public RangeBetInformation RangeBetInfo { get; set; }

        //output
        /// <summary>
        /// รหัสตรวจสอบ
        /// </summary>
        public Guid TrackingID { get; set; }
    }
}
