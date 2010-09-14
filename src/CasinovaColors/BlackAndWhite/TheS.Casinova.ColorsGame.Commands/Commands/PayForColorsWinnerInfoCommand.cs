using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ColorsGame.Commands
{
    
    public class PayForColorsWinnerInfoCommand
    {
        //Generate TrackID input
        public string UserName { get; set; }
        public int TableID { get; set; }
        public int RoundID { get; set; }

        //Generate TrackID output
        public Guid TrackingID { get; set; }
    }
}
