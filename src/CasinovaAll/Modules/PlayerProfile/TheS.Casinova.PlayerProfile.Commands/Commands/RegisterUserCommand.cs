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

        /// <summary>
        /// ข้อมูลที่ผู้เล่นสมัครสมาชิก
        /// 1.UserName ชื่อของผู้เล่น
        /// 2.Password รหัสผ่าน
        /// 3.Email อีเมลล์
        /// 4.CellPhone เบอร์โทรศัพท์
        /// 5.Upline ผู้เล่นที่แนะนำ(ถ้ามี)
        /// 6.Active สถานะการใช้งาน
        /// 7.VeriflyCode รหัสยืนยันการสมัคร
        /// 8.TrackingID รหัสตรวจสอบการทำงาน
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
