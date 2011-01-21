using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MLN.Models
{
    /// <summary>
    /// อัตราการคืนโบนัสให้ upline
    /// </summary>
    public class MLNSetting
    {
        /// <summary>
        /// ชื่อการตั้งค่า
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// อัตราการให้โบนัสจากตัวเอง
        /// </summary>
        public double SelfRate { get; set; }

        /// <summary>
        /// อัตราการให้โบนัส upline ระดับชั้นที่ 1
        /// </summary>
        public double Level1Rate { get; set; }

        /// <summary>
        /// อัตราการให้โบนัส upline ระดับชั้นที่ 2
        /// </summary>
        public double Level2Rate { get; set; }

        /// <summary>
        /// อัตราการให้โบนัส upline ระดับชั้นที่ 3
        /// </summary>
        public double Level3Rate { get; set; }
    }
}
