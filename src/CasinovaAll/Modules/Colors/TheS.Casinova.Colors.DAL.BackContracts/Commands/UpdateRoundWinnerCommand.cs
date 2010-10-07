using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.Commands
{
    public class UpdateRoundWinnerCommand : PayForColorsWinnerInfoCommand
    {
        //input
        public Guid TrackingID { get; set; }

        public DateTime LastUpdate { get; set; }

        public string Winner { get; set; }
    }
}
