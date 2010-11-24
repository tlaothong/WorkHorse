using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.Colors.Models
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
        /// roundID of the game playable
        /// </summary>
        public int Round { get; set; }

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
        public double TotalBetBlack { get; set; }

        /// <summary>
        /// total amount of white bet
        /// </summary>
        public double TotalBetWhite { get; set; }

        /// <summary>
        /// the winner of color on that time when player request winner
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// the last update time of player request winner information
        /// </summary>
        public DateTime WinnerLastUpdate { get; set; }
    }
}
