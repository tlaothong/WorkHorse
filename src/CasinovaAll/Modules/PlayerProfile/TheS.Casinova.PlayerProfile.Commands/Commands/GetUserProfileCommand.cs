using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Commands
{
    /// <summary>
    /// command ดึงข้อมูล profile ของผู้เล่น
    /// </summary>
   public class GetUserProfileCommand
    {
       //input
       /// <summary>
       /// ข้อมูลการดึงข้อมูลโปรไฟล์
       /// 1. UserName ชื่อผู้เล่น
       /// </summary>
       public UserProfile GetUserProfileInfo { get; set; }

       //output
       /// <summary>
       /// ข้อมูล profile ของผู้เล่น
       /// </summary>
       public UserProfile PlayerProfile { get; set; }

    }
}
