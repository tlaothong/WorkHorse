using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    public class CreatePlayerActionInfoCommand
    {
        //input
        public int RoundID { get; set; }

        public string UserName { get; set; }

        public double Amount { get; set; }

        public string ActionType { get; set; }
    }
}
