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
        public string UserName { get; set; } //username of player
        public int TableID { get; set; } // tableID of the gmae playable
        public int RoundID { get; set; } //roundID of the game playable

        public Guid TrackingID { get; set; } // trackingID
        public Guid OnGoingTrackingID { get; set; } //the trackingID of winner information when user request for get information
        public double TotalBetAmounfOfBlack { get; set; } // total amont of black bet
        public double TotalBetAmountOfWhite { get; set; } // total amount of white bet
        public string Winner { get; set; } // the winner of color on that time when player request winner
        public DateTime LastUpdate { get; set; } //the last update time of player request winner information
    }
}
