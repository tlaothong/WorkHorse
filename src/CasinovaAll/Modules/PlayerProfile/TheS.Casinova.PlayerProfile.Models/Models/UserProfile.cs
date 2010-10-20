using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerProfile.Models
{
    /// <summary>
    /// ข้อมูล profile ของผู้เล่น
    /// </summary>
    public class UserProfile
    {
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
        public string CallPhone { get; set; }

        /// <summary>
        /// username ของคนแนะนำเกม
        /// </summary>
        public string Upline { get; set; }

        /// <summary>
        /// จำนวนชิพเป็น
        /// </summary>
        public int Refundable { get; set; }

        /// <summary>
        /// จำนวนชิพตาย
        /// </summary>
        public int NonRefundable { get; set; }

        /// <summary>
        /// สถานะการเปิดใช้งาน account
        /// </summary>
        public bool Active { get; set; }
    }
}
