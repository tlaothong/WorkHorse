using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerAccount.Commands
{
    public class GetUserProfileCommand
        : CancelPlayerAccountCommand
    {
        //input
        /// <summary>
        /// ผู้เล่นที่ต้องการดึงข้อมูล
        /// 1.UserName ชื่อผู้เล่น
        /// </summary>
        public UserProfile UserProfileInput { get; set; }

        //output
        public UserProfile UserProfileOutput { get; set; }
    }
}
