using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// ดึงข้อมูลการลงพนันของโต๊ะเกม
    /// </summary>
    public class ListPlayerActionInfoCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        //output
        /// <summary>
        /// ข้อมูลการลงพนันในโต๊ะเกม
        /// </summary>
        public IEnumerable<PlayerActionInformation> PlayerActionInfoList { get; set; }
    }
}
