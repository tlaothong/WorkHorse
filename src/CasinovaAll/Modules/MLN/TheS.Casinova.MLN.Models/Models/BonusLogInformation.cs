using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MLN.Models
{
    /// <summary>
    /// ข้อมูลการได้รับโบนัส
    /// </summary>
    public partial class BonusLogInformation
    {
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนโบนัสที่ส่งให้ upline
        /// </summary>
        public double BonusAmount { get; set; }

        /// <summary>
        /// ชื่อ upline ที่ได้รับโบนัส
        /// </summary>
        public string RecieverName { get; set; }

        /// <summary>
        /// เวลาที่ส่งโบนัสให้ upline
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// ระดับชั้นของ upline ที่ได้รับโบนัส
        /// </summary>
        public int RecieverLevel { get; set; }
    }
}
