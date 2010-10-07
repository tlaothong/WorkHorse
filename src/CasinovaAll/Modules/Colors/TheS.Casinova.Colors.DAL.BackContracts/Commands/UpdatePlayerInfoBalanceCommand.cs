using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    public class UpdatePlayerInfoBalanceCommand
    {
        //input
        public string UserName { get; set; }

        public double Balance { get; set; }
    }
}
