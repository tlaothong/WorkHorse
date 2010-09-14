using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ColorsGame.Commands
{
    public class PayForColorsWinnerInfoCommand
    {
        public string UserName { get; set; }
        public int TableID { get; set; }
        public int RoundID { get; set; }

        public Guid TrackingID { get; set; }
    }
}
