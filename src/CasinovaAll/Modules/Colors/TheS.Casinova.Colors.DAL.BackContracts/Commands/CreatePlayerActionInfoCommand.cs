using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// เพิ่มประวัติการดำเนินการของผู้เล่น
    /// </summary>
    public class CreatePlayerActionInfoCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมที่ถูกดำเนินการ
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่นที่ดำเนินการ
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนเงินค่าดำเนินการ
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// ประเภทการดำเนินการ
        /// </summary>
        public string ActionType { get; set; }
    }
}
