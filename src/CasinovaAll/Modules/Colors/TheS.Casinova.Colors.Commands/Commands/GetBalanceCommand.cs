using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
   public class GetBalanceCommand
    {
       //input
       public string UserName { get; set; } //username ของผู้เล่น

       //output
       public PlayerInformation Balance { get; set; } //ยอดเงินในบัญชีของผู้เล่น
    }
}
