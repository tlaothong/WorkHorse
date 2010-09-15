using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Models;

namespace TheS.Casinova.ColorsGame.Commands
{
    //command สำหรับ หักเงินผู้เล่น, อัพเดทข้อมูล game information, และดึงข้อมูล Winner โต๊ะที่เลือก
    public class PayForColorsWinnerInfoCommand
    {
        public string UserName { get; set; } //ชื่อผู้เล่น
        public int TableID { get; set; } //รหัสโต๊ะเกม
        public int RoundID { get; set; } //รหัสรอบโต๊ะ
        public Guid TrackingID { get; set; } //รหัส TrackingID สำหรับตรวจสอบผลลัพธ์ Winner
        public PlayerInformation PlayerInformation { get; set; } //ข้อมูลผู้เล่นสำหรับหักเงิน
        public GamePlayInformation GamePlayInformation { get; set; } //ข้อมูลเกมสำหรับอัพเดท
    }
}
