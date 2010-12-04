using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    /// <summary>
    /// ข้อมูลเกมแต่ละโต๊ะ
    /// </summary>
    public class RoundInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// เวลาเริ่มเกม
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// เวลาจบเกม
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// เวลาช่วง Critical
        /// </summary>
        public DateTime CriticalDateTime { get; set; }
    }
}
