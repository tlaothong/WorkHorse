using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// บันทึกข้อมูลการลงพนันหลายมือ
    /// </summary>
    public class CreateRangeBetInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการลงพนันหลายมือที่จะบันทึก
        /// </summary>
        public RangeBetInformation RangeBetInfo { get; set; }
    }
}
