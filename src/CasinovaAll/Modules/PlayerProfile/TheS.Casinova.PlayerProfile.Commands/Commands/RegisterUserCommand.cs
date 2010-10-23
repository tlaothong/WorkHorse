using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Commands
{
    /// <summary>
    /// command บันทึกข้อมูลการสมัครสมาชิกของผู้เล่น
    /// </summary>
   public class RegisterUserCommand
    {
        //input
        /// <summary>
        /// ชื่อของผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสผ่าน
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// อีเมลล์
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// เบอร์โทรศัพท์
        /// </summary>
        public int CellPhone { get; set; }

        /// <summary>
        /// username ของคนแนะนำเกม
        /// </summary>
        public string Upline { get; set; }

        /// <summary>
        /// สถานะการเปิดใช้งาน account
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// รหัสยืนยันการสมัคร
        /// </summary>
        public string VeriflyCode { get; set; }

        /// <summary>
        /// รหัสตรวจสอบการทำงาน
        /// </summary>
        public Guid TrackingID { get; set; }
    }
}
