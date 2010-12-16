using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// สร้างประวัติการดำเนินการ(ลงพนัน, แก้ไขจำนวนเงิน)
    /// </summary>
    public class CreateActionLogInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการดำเนินการที่จะบันทึก
        /// 1.RoundID รหัสโต๊ะเกม
        /// 2.UserName ชื่อผู้เล่นที่ดำเนินการ
        /// 3.ActionType ประเภทการดำเนินการ
        /// 4.Amount จำนวนเงิน
        /// 5.ActionDateTime วันเวลาที่ดำเนินการ
        /// </summary>
        public ActionLogInformation ActionLogInfo { get; set; }
    }
}
