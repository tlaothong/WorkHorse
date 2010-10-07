using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.Colors.Models
{
    /// <summary>
    /// ข้อมูลโต๊ะเกม
    /// </summary>
    public partial class GameRoundInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// เวลาเริ่มเกม
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// เวลาจบเกม
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// เงินในกองสีดำ
        /// </summary>
        public double BlackPot { get; set; }

        /// <summary>
        /// เงินในกองสีขาว
        /// </summary>
        public double WhitePot { get; set; }

        /// <summary>
        /// จำนวน hand ทั้งหมดที่ลง
        /// </summary>
        public int HandCount { get; set; }
    }

    [MetadataType(typeof(MD))]
    partial class GameRoundInformation
    {
        public class MD
        {
            [Required]
            public int RoundID { get; set; }

            public DateTime StartTime { get; set; }

            public DateTime EndTime { get; set; }

            public double BlackPot { get; set; }

            public double WhitePot { get; set; }

            public int HandCount { get; set; }
        }
    }
}
