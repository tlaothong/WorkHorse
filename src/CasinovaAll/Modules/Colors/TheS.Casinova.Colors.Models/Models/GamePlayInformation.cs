using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.TwoWins.Models
{
    /// <summary>
    /// The GamePlay Information of the Player for the given round.
    /// </summary>
    public partial class GamePlayInformation
    {
        /// <summary>
        /// username of player
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// tableID of the gmae playable
        /// </summary>
        public int TableID { get; set; }

        /// <summary>
        /// roundID of the game playable
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// trackingID use to verify
        /// </summary>
        public Guid TrackingID { get; set; }

        /// <summary>
        /// the trackingID of winner information when user request for get information
        /// </summary>
        public Guid OnGoingTrackingID { get; set; }

        /// <summary>
        /// total amont of black bet
        /// </summary>
        public double TotalBetAmountOfBlack { get; set; }

        /// <summary>
        /// total amount of white bet
        /// </summary>
        public double TotalBetAmountOfWhite { get; set; }

        /// <summary>
        /// the winner of color on that time when player request winner
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// the last update time of player request winner information
        /// </summary>
        public DateTime LastUpdate { get; set; }
    }

    [MetadataType(typeof(MD))]
    partial class GamePlayInformation
    {
        public class MD
        {
            [Required]
            public string UserName { get; set; }
           
            public int TableID { get; set; }
            
            public int RoundID { get; set; }
           
            public Guid TrackingID { get; set; }
           
            public Guid OnGoingTrackingID { get; set; }
           
            public double TotalBetAmountOfBlack { get; set; }
           
            public double TotalBetAmountOfWhite { get; set; }
            
            public string Winner { get; set; }

            public DateTime LastUpdate { get; set; }
        }
    }
}
