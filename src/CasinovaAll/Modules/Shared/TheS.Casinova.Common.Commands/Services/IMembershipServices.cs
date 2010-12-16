using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.Common.Services
{
    public interface IMembershipServices       
    {
        /// <summary>
        /// ข้อมูลที่ผู้เล่นสมัครสมาชิก
        /// 1.UserName ชื่อของผู้เล่น
        /// 2.Password รหัสผ่าน
        /// 3.Email อีเมลล์
        /// 4.CellPhone เบอร์โทรศัพท์
        /// 5.Upline ผู้เล่นที่แนะนำ(ถ้ามี)
        /// 6.Active สถานะการใช้งาน (BS ใส่)
        /// 7.VeriflyCode รหัสยืนยันการสมัคร (BS ใส่)
        /// 8.TrackingID รหัสตรวจสอบการทำงาน (WS ใส่)
        /// </summary>
        void RegisterUser(UserProfile userProfile);

        /// <summary>
        /// ข้อมูลผู้เล่นที่ต้องการเปลี่ยนอีเมลล์
        /// 1.UserName ชื่อผู้เล่น
        /// 2.Email อีเมลล์เดิมสำหรับยืนยัน
        /// 3.NewEmail อีเมลล์ใหม่ของผู้เล่น
        /// </summary>
        void ChangeEmail(UserProfile userProfile);

        /// <summary>
        /// ข้อมูลผู้เล่นที่ต้องการเปลี่ยนรหัสผ่าน
        /// 1.UserName ชื่อผู้เล่น
        /// 2.OldPassword รหัสผ่านเดิม
        /// 3.NewPassword รหัสผ่านที่ต้องการเปลี่ยน
        /// </summary>
        void ChangePassword(UserProfile userProfile);
    }
}
