using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
   public class GetBalanceCommand
    {
       //input
       public string UserName { get; set; } //username ของผู้เล่น

       //output
       public PlayerInformation Balance { get; set; } //ยอดเงินในบัญชีของผู้เล่น
    }
}
