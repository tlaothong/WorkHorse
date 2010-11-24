using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.Colors.Commands
{
   public class GetBalanceCommand
    {
       //input
       /// <summary>
       /// ชื่อผู้เล่นที่ต้องการข้อมูลยอดเงินในบัญชี
       /// 1. username ของผู้เล่น
       /// </summary>
       public UserProfile UserProfile { get; set; } 

       //output
       /// <summary>
       /// ยอดเงินในบัญชีของผู้เล่น
       /// </summary>
       public UserProfile UserProfileBalance { get; set; } 
    }
}
