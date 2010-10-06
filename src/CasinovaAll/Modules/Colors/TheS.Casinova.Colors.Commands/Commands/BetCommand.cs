using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// command ลงเงินสีที่ต้องการ ระบบจะทำการหักเงินผู้เล่น และบันทึกข้อมูลการลงพนัน
    /// </summary>
    public class BetCommand
    {
        //input
        public string UserName { get; set; } //ชื่อผู้เล่นที่ลงพนัน
        public int RoundID { get; set; } //รหัสโต๊ะเกมที่ลงพนัน
        public double Amount { get; set; } //จำนวนเงินลงพนัน
        public string Color { get; set; } //สีที่ลงพนัน
        public Guid TrackingID { get; set; } //trackingId ที่ได้จากการ generate
    }
}
