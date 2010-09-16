using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ColorsGame.Models
{
    /// <summary>
    /// The GamePlay Information of the Player for the given round.
    /// </summary>
    public class GamePlayInformation
    {
        //input
        public string UserName { get; set; }
        public int TableID { get; set; }
        public int RoundID { get; set; }

        //output
        public Guid TrackingID { get; set; }
        public Guid OnGoingTrackingID { get; set; }
        public double TotalBetAmounfOfBlack { get; set; }
        public double TotalBetAmountOfWhite { get; set; }
        public string Winner { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
