using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// คืนเงินรางวัลให้ผู้ชนะเมื่อโต๊ะเกมหมดเวลา
    /// </summary>
    public class EndGameReturnRewardCommand
    {
        /// <summary>
        /// รหัสโต๊ะเกมที่หมดเวลา
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อการตั้งค่า
        /// </summary>
        public string SettingName { get; set; }
    }
}
