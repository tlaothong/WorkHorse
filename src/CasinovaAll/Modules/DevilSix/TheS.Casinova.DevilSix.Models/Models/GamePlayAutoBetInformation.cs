using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.DevilSix.Models
{ /// <summary>
    /// ข้อมูลการลงเดิมพันแบบอัตโนมัติ
    /// </summary>
    public partial class GamePlayAutoBetInformation
    {
        /// <summary>
        /// ชื่อผู้เล่นที่ลงเดิมพัน
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสโต๊ะเกมที่ลงพนัน
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// จำนวนเงินที่ลงเดิมพันแบบอัตโนมัติแต่ละครั้ง
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// จำนวนเงินทั้งหมดที่ลงเดิมพันแบบอัตโนมัติ
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// จำนวนชิพตาย
        /// </summary>
        public double BonusChips { get; set; }

        /// <summary>
        /// จำนวนชิพเป็น
        /// </summary>
        public double Chips { get; set; }

        /// <summary>
        /// ระยะห่างของเวลาในการลงเดิมพันแต่ละครั้ง เป็นวินาที
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// จำนวนเงินที่ได้คืน
        /// </summary>
        public double MoneyRefund { get; set; }

        /// <summary>
        /// รหัสตรวจสอบใช้บอกว่ามีการลงเดิมพันแบบอัตโนมัติ
        /// </summary>
        public Guid AutoBetTrackingID { get; set; }

        /// <summary>
        /// รหัสตรวจสอบการหยุดการลงเดิมพัน
        /// </summary>
        public Guid StopTrackingID { get; set; }

        /// <summary>
        /// รหัสที่ใช้ตรวจสอบการการลงเดิมพัน
        /// </summary>
        public Guid BetTrackingID { get; set; }

        /// <summary>
        /// เวลาเริ่มการลงเดิมพันแบบอัตโนมัติ
        /// </summary>
        public DateTime FromDateTime { get; set; }

        /// <summary>
        /// เวลาสิ้นสุดการลงเดิมพันแบบอัตโนมัติ
        /// </summary>
        public DateTime ?ThruDateTime { get; set; }

        /// <summary>
        /// หมายเลข Lot
        /// </summary>
        public int LotNo { get; set; }


    }
}
