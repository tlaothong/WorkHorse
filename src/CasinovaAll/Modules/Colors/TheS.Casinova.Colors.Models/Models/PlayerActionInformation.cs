using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.Colors.Models
{
    /// <summary>
    /// ข้อมูลการลงพนันของผู้เล่นแต่ละครั้ง
    /// </summary>
    public partial class PlayerActionInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกมที่ลงพนัน
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่นที่ลงพนัน
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// ประเภทของการดำเนินการ
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// จำนวนเงินที่ใช้ดำเนินการ
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// trackingID use to verify
        /// </summary>
        public Guid TrackingID { get; set; }
    }

    [MetadataType(typeof(MD))]
    partial class PlayerActionInformation
    {
        public class MD
        {
            [Required]
            public int RoundID { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public string ActionType { get; set; }
            [Required]
            public double Amount { get; set; }

            public Guid TrackingID { get; set; }
        }
    }
}
