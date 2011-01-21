using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MLN.Models
{
    /// <summary>
    /// ข้อมูล Bonus ทั้งหมด และข้อมูล upline
    /// </summary>
    public partial class MLNInformation
    {
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนโบนัสทั้งหมดที่สามารถนำไปใช้ในเกมได้
        /// </summary>
        public double UseableBonus { get; set; }

        /// <summary>
        /// ชื่อ upline ชั้นที่ 1
        /// </summary>
        public string UplineLevel1 { get; set; }

        /// <summary>
        /// ชื่อ upline ชั้นที่ 2
        /// </summary>
        public string UplineLevel2 { get; set; }

        /// <summary>
        /// ชื่อ upline ชั้นที่ 3
        /// </summary>
        public string UplineLevel3 { get; set; }

        /// <summary>
        /// จำนวนโบนัสทั้งหมดที่ได้รับในเดือนปัจจุบัน
        /// </summary>
        public double BonusThisMonth { get; set; }

        /// <summary>
        /// จำนวนโบนัสทั้งหมดที่ได้รับในเดือนที่แล้ว
        /// </summary>
        public double BonusLastMonth { get; set; }

        /// <summary>
        /// จำนวน downLine ทั้งหมดในระดับ1
        /// </summary>
        public int TotalDownLineLevel1 { get; set; }

        /// <summary>
        /// จำนวน downLine ทั้งหมดในระดับ2
        /// </summary>
        public int TotalDownLineLevel2 { get; set; }

        /// <summary>
        /// จำนวน downLine ทั้งหมดในระดับ3
        /// </summary>
        public int TotalDownLineLevel3 { get; set; }

        /// <summary>
        /// จำนวนโบนัสทั้งหมดที่ได้รับ
        /// </summary>
        public double TotalBonus { get; set; }

        /// <summary>
        /// จำนวน downline ทั้งหมดที่มีใน level 1
        /// </summary>
        public int GroupCount { get; set; }

    }
}
